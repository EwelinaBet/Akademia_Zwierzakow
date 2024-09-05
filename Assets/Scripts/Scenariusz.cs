using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scenariusz", menuName = "VisualNovel/Scenariusz")]
public class Scenariusz : ScriptableObject
{
    [SerializeField] private List<Scenka> sceny;

    public List<Scenka> Sceny => sceny;
}
