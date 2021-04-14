using UnityEngine;

public class VolumeValueChange : MonoBehaviour {

    private AudioSource audioSrc;

	void Start () {

        audioSrc = GetComponent<AudioSource>();

        float currentVolume = PlayerPrefs.GetFloat("volume");
        audioSrc.volume = currentVolume == 0f ? 1f : currentVolume;

	}
}
