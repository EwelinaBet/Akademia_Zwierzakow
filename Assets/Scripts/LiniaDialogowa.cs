using UnityEngine;

[CreateAssetMenu(fileName = "LiniaDialogowa", menuName = "VisualNovel/LiniaDialogowa")]
public class LiniaDialogowa : BazowyDialog
{
    [SerializeField] private Sprite lokacja;
    [SerializeField] private Sprite postac;
    [SerializeField] private AudioClip dzwiek;

    [Space]
    [SerializeField] private bool kwestiaGracza;
    [SerializeField, TextArea] private string dialog;

    [SerializeField] private BazowyDialog nastepnyDialog;

    public Sprite Lokacja => lokacja;
    public Sprite Postac => postac;
    public AudioClip Dzwiek => dzwiek;

    public bool KwestiaGracza => kwestiaGracza;
    public string Dialog => dialog;
    public BazowyDialog NastepnyDialog => nastepnyDialog;
}
