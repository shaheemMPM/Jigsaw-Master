using UnityEngine;
using UnityEngine.UI;

public class ButtonShade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string levelName = gameObject.name;
        int levels = PlayerPrefs.GetInt("levels");
        if (levelName == "Gift")
        {
            if (levels <= 10)
            {
                gameObject.GetComponent<Image>().color = new Color32(51, 51, 51, 255);
            }
        }
        else
        {
            char charLevelNo = levelName[levelName.Length - 1];
            int levelNo = charLevelNo - '0';
            levelNo = levelNo == 0 ? 10 : levelNo;
            levels = levels == 0 ? 1 : levels;
            if (levelNo > levels)
            {
                gameObject.GetComponent<Image>().color = new Color32(51, 51, 51, 255);
            }
        }
    }
}
