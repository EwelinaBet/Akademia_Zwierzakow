using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scenariusz", menuName = "VisualNovel/Scenariusz")]
public class Scenariusz : ScriptableObject
{
    [SerializeField] private BazowyDialog pierwszyDialog;

    public BazowyDialog PierwszyDialog => pierwszyDialog;
}
