using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class PrezenterScenki : MonoBehaviour
{
    [SerializeField] private Scenariusz scenariusz;
    [SerializeField] private Image lokacja;
    [SerializeField] private Image postac;
    [SerializeField] private TextMeshProUGUI tekst;

    private int nrScenki;
    private Scenka obecnaScenka;
 
    void Start()
    {
        nrScenki = 0;
        UstawScenke( scenariusz.Sceny[nrScenki] );
    }

    void Update()
    {
        if( Input.GetKeyUp(KeyCode.Space ) )
        {
            nrScenki++;
            UstawScenke(scenariusz.Sceny[nrScenki]);
        }
    }

    private void UstawScenke( Scenka nowaScenka )
    {
        obecnaScenka = nowaScenka;

        // lokacja.sprite = obecnaScenka.Lokacja;
        // postac.sprite = obecnaScenka.Postac;
        // tekst.text = obecnaScenka.Dialog;
    }
}