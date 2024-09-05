using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Scenka", menuName ="VisualNovel/Scenka")]
public class Scenka : ScriptableObject
{
    [SerializeField] private Sprite lokacja;
    [SerializeField] List<BazowyDialog> dialogi;

    public Sprite Lokacja => lokacja;
    public List<BazowyDialog> Dialogi => dialogi;
}
