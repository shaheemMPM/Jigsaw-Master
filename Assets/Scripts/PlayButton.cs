using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{

    private Button playButton;
    public Sprite playSprite;
    public Sprite playHighlightSprit;
    public AudioSource mouseEnterSound;

    void Start()
    {
        playButton = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseEnterSound.Play();
        playButton.image.sprite = playHighlightSprit;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseEnterSound.Play();
        playButton.image.sprite = playSprite;
    }
}
