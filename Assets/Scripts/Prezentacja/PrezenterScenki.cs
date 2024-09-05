using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;

public class PrezenterScenki : MonoBehaviour
{
    [SerializeField] private Scenariusz scenariusz;
    [SerializeField] private Image lokacja;
    [SerializeField] private Image postac;
    [SerializeField] private TextMeshProUGUI tekst;

    [SerializeField] private List<PrezenterOpcjiDialogowej> prezenteryOpcji;
    [SerializeField] private GameObject przyciskDalej;

    private int nrScenki;
    private Scenka obecnaScenka;
    
    private int nrDialogu;
    private BazowyDialog obecnyDialog;
    
    private int charyzma;

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
            postac.sprite = linia.Postac;
            postac.gameObject.SetActive(postac.sprite != null);
            tekst.text = linia.Dialog;
            przyciskDalej.SetActive(true);
        }
        else if(obecnyDialog is OpcjeDialogowe opcje )
        {
            int iloscOpcji = Math.Min(prezenteryOpcji.Count, opcje.Opcje.Count);

            for( int i = 0; i < iloscOpcji; i++ )
            {
                prezenteryOpcji[i].UstawOpcje(opcje.Opcje[i]);
                prezenteryOpcji[i].gameObject.SetActive(true);
            }
        }
    }

    private void Wyczysc()
    {
        przyciskDalej.SetActive(false);
        foreach (var p in prezenteryOpcji)
            p.gameObject.SetActive(false);
    }

    private void KoniecGry()
    {
        Wyczysc();
        tekst.text = "Koniec Gry! :)";
    }

    public void PrzyciskDalej()
    {
        NastêpnyDialog();
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