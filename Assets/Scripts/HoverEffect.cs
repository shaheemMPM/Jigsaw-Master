using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource mouseEnterSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseEnterSound.Play();
    }
}
