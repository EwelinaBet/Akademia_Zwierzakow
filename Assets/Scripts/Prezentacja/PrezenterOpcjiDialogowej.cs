using TMPro;
using UnityEngine;

public class PrezenterOpcjiDialogowej : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;

    public void UstawOpcje( OpcjaDialogowa opcja )
    {
        label.text = opcja.Tekst;
    }
}
