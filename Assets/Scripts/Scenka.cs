using UnityEngine;

[CreateAssetMenu(fileName ="Scenka", menuName ="VisualNovel/Scenka")]
public class Scenka : ScriptableObject
{
    [SerializeField] private Sprite lokacja;
    [SerializeField] BazowyDialog liniaDialogowa;

    public Sprite Lokacja => lokacja;
}
