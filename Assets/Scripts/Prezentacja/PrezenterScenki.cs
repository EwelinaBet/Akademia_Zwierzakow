using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PrezenterScenki : MonoBehaviour
{
    [SerializeField] private Scenariusz scenariusz;
    [SerializeField] private Image lokacja;
    [SerializeField] private Image postac;
    [SerializeField] private TextMeshProUGUI tekst;
    [SerializeField] private AudioSource odtwarzaczDzwiekow;

    [Space]
    [SerializeField] private List<PrezenterOpcjiDialogowej> prezenteryOpcji;
    [SerializeField] private GameObject przyciskDalej;
    [SerializeField] private GameObject przyciskPrzeskok;
    [SerializeField] private GameObject dymekPostaci;
    [SerializeField] private GameObject dymekGracza;

    [Space]
    public BazowyDialog obecnyDialog;
    
    private int charyzma;

    private bool koniec;

    private void Start()
    {
        PokazDialog( scenariusz.PierwszyDialog );
    }

    private void Update()
    {
        // Pokaz ponownie, zeby testowac edycjê
        if (Input.GetKeyDown(KeyCode.R))
        {
            PokazDialog(obecnyDialog);
        }
    }

    private void NastepnyDialog()
    {
        if (obecnyDialog is LiniaDialogowa linia)
        {
            PokazDialog(linia.NastepnyDialog);
        }
    }

    private void PokazDialog(BazowyDialog dialog)
    {
        if( dialog == null )
        {
            KoniecGry();
            return;
        }

        obecnyDialog = dialog;
        Wyczysc();

        if (obecnyDialog is LiniaDialogowa linia)
        {
            PokazLinieDialogowa(linia);
        }
        else if (obecnyDialog is OpcjeDialogowe opcje)
        {
            PokazOpcjeDialogowe(opcje);
        }
    }

    private void PokazLinieDialogowa(LiniaDialogowa linia)
    {
        lokacja.sprite = linia.Lokacja;
        postac.sprite = linia.Postac;
        postac.gameObject.SetActive(postac.sprite != null);

        if( linia.Dzwiek != null )
        {
            odtwarzaczDzwiekow.clip = linia.Dzwiek;
            odtwarzaczDzwiekow.Play();
        }

        tekst.text = linia.Dialog;

        if( linia.KwestiaGracza )
        {   
            dymekGracza.SetActive(true);
            dymekPostaci.SetActive(false);
        }
        else
        {
            dymekPostaci.SetActive(true);
            dymekGracza.SetActive(false);
        }

        przyciskDalej.SetActive(true);
        przyciskPrzeskok.SetActive(true);
    }

    private void PokazOpcjeDialogowe(OpcjeDialogowe opcje)
    {
        int iloscOpcji = Math.Min(prezenteryOpcji.Count, opcje.Opcje.Count);

        for (int i = 0; i < iloscOpcji; i++)
        {
            var opcja = opcje.Opcje[i];

            if (charyzma >= opcja.WymaganaCharyzma )
            {
                prezenteryOpcji[i].UstawOpcje(opcja);
                prezenteryOpcji[i].gameObject.SetActive(true);
            }
        }
    }

    private void Wyczysc()
    {
        koniec = false;
        przyciskDalej.SetActive(false);
        przyciskPrzeskok.SetActive(false);
        foreach (var p in prezenteryOpcji)
            p.gameObject.SetActive(false);
    }

    private void KoniecGry()
    {
        Wyczysc();
        koniec = true;
        tekst.text = "Koniec Gry! :)";
        przyciskDalej.SetActive(true);
    }

    public void PrzyciskDalej()
    {
        if (koniec == true)
        {
            SceneManager.LoadScene("Menu");
            return;
        }
        
        NastepnyDialog();
    }

    public void PrzyciskPrzeskok()
    {
        do
        {
            NastepnyDialog();
            if (koniec == true)
                return;
        }
        while (obecnyDialog is LiniaDialogowa);
    }

    public void PrzyciskOpcji(int nr)
    {
        var opcjeDialogowe = obecnyDialog as OpcjeDialogowe;
        var opcja = opcjeDialogowe.Opcje[nr];

        Debug.Log( $"Wciœniêto opcjê '{opcja.Tekst}'. Zmiana Charyzmy {opcja.ZmianaCharyzmy}" );

        charyzma += opcja.ZmianaCharyzmy;
        Debug.Log($"Suma Charyzmy = {charyzma}");

        PokazDialog(opcja.NastepnyDialog);
    }
}