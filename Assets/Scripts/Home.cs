using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{

    public AudioSource errorSound;

    public void LoadLevel()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        if (name == "Menu")
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            int levels = PlayerPrefs.GetInt("levels");
            levels = levels == 0 ? 1 : levels;
            char charLevelNo = name[name.Length - 1];
            int levelNo = charLevelNo - '0';
            levelNo = levelNo == 0 ? 10 : levelNo;
            if (levels >= levelNo)
            {
                SceneManager.LoadScene(name);
            }
            else
            {
                errorSound.Play();
            }
        }
    }
}
