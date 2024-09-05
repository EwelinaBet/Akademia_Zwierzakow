using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "OpcjeDialogowe", menuName = "VisualNovel/OpcjeDialogowe")]
public class OpcjeDialogowe : BazowyDialog
{
    [SerializeField] private List<OpcjaDialogowa> opcje;

    public List<OpcjaDialogowa> Opcje => opcje;
}
