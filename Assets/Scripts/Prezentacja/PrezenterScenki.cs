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

    [SerializeField] private List<PrezenterOpcjiDialogowej> prezenteryOpcji;
    [SerializeField] private GameObject przyciskDalej;
    [SerializeField] private GameObject przyciskPrzeskok;

    private int nrScenki;
    private Scenka obecnaScenka;
    
    private int nrDialogu;
    private BazowyDialog obecnyDialog;
    
    private int charyzma;

    private bool koniec;

    void Start()
    {
        nrScenki = -1;
        NastêpnaScena();
    }

    private void NastêpnaScena()
    {
        nrScenki++;
      
        if (nrScenki >= scenariusz.Sceny.Count)
        {
            KoniecGry();
            return;
        }

        obecnaScenka = scenariusz.Sceny[nrScenki];
        lokacja.sprite = obecnaScenka.Lokacja;

        nrDialogu = -1;
        NastêpnyDialog();
    }

    private void NastêpnyDialog()
    {
        nrDialogu++;

        if (nrDialogu >= obecnaScenka.Dialogi.Count)
        {
            NastêpnaScena();
            return;
        }

        obecnyDialog = obecnaScenka.Dialogi[nrDialogu];
        Wyczysc();

        if(obecnyDialog is LiniaDialogowa linia )
        {
            PokazLinieDialogowa(linia);
        }
        else if(obecnyDialog is OpcjeDialogowe opcje )
        {
            PokazOpcjeDialogowe(opcje);
        }
    }

    public void PrzyciskPrzeskok()
    {
        do
        {
            NastêpnyDialog();
            if (koniec==true)
                return;
        }
        while(obecnyDialog is LiniaDialogowa);
    }

    private void PokazLinieDialogowa(LiniaDialogowa linia)
    {
        postac.sprite = linia.Postac;
        postac.gameObject.SetActive(postac.sprite != null);

        tekst.text = linia.Dialog;
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
        przyciskDalej.SetActive(false);
        przyciskPrzeskok.SetActive(false);
        foreach (var p in prezenteryOpcji)
            p.gameObject.SetActive(false);
    }

    private void KoniecGry()
    {
        koniec = true;
        Wyczysc();
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
        
        NastêpnyDialog();
        PrzyciskPrzeskok();
    }

    public void PrzyciskOpcji(int nr)
    {
        var opcjeDialogowe = obecnyDialog as OpcjeDialogowe;
        var opcja = opcjeDialogowe.Opcje[nr];

        Debug.Log( $"Wciœniêto opcjê '{opcja.Tekst}'. Zmiana Charyzmy {opcja.ZmianaCharyzmy}" );

        charyzma += opcja.ZmianaCharyzmy;
        Debug.Log($"Suma Charyzmy = {charyzma}");

        NastêpnyDialog();
    }
}