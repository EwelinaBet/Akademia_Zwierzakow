using UnityEngine;
using UnityEngine.EventSystems;

public class DzwiekPrzycisku : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioSource dzwiek;

    public void OnPointerClick(PointerEventData eventData)
    {
        dzwiek.Play();
    }
}
