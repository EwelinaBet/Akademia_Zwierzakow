using UnityEngine;
using System;

[Serializable]
public class OpcjaDialogowa
{
    [SerializeField, TextArea] private string tekst;
    [SerializeField] private int wymaganaCharyzma;
    [SerializeField] private int zmianaCharyzmy;

    [SerializeField] private BazowyDialog nastepnyDialog;

    public string Tekst => tekst;
    public int WymaganaCharyzma => wymaganaCharyzma;
    public int ZmianaCharyzmy => zmianaCharyzmy;
    public BazowyDialog NastepnyDialog => nastepnyDialog;
}
