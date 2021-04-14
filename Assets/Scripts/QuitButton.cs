using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuitButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private Button quitButton;
    public Sprite quitSprite;
    public Sprite quitHighlightSprit;
    public AudioSource mouseEnterSound;

    void Start()
    {
        quitButton = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseEnterSound.Play();
        quitButton.image.sprite = quitHighlightSprit;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseEnterSound.Play();
        quitButton.image.sprite = quitSprite;
    }
}
