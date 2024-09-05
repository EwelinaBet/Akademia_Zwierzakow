using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LiniaDialogowa", menuName = "VisualNovel/LiniaDialogowa")]
public class LiniaDialogowa : BazowyDialog
{
    [SerializeField] private Sprite postac;
    [SerializeField, TextArea] private string dialog;

    public Sprite Postac => postac;
    public string Dialog => dialog;
}
