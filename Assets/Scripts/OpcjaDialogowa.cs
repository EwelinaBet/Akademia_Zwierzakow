using UnityEngine;
using System;

[Serializable]
public class OpcjaDialogowa
{
    [SerializeField, TextArea] private string tekst;
    [SerializeField] private int zmianaCharyzmy;

    public string Tekst => tekst;
    public int ZmianaCharyzmy => zmianaCharyzmy;
}
