using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public GameObject confirmPanel;
    public AudioSource testAudio;
    public AudioSource clickAudio;
    public Slider volumeSlider;
    public float musicVolume;

    void Start()
    {
        CloseDialogue();
        musicVolume = PlayerPrefs.GetFloat("volume");
        musicVolume = musicVolume == 0f ? 1f : musicVolume;
        volumeSlider.value = musicVolume;
        testAudio.volume = musicVolume;
        clickAudio.volume = musicVolume;
    }

    void Update()
    {
        testAudio.volume = musicVolume;
        clickAudio.volume = musicVolume;
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ClearGameData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("volume", musicVolume);
        CloseDialogue();
    }

    public void OpenDialogue()
    {
        confirmPanel.SetActive(true);
    }

    public void CloseDialogue()
    {
        confirmPanel.SetActive(false);
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }
}
