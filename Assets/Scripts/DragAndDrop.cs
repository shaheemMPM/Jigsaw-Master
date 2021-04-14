using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour
{

    public GameObject selectedPiece;
    public GameObject LevelWonPanel;
    int orderInLayer = 1;
    public int correctedPieces;
    public AudioSource correctPieceSound;
    public AudioSource clickSound;
    public float timeStart = 0f;
    public bool isWon = false;
    public Text timeBox;
    public Text currentTime;
    public Text highTime;
    public Text bestTimeBox;

    // Start is called before the first frame update
    void Start()
    {
        LevelWonPanel.SetActive(false);
        correctedPieces = 0;
        timeBox.text = timeStart.ToString();
        float HighScore = PlayerPrefs.GetFloat("High" + SceneManager.GetActiveScene().name);
        float hMinutes = Mathf.Floor(HighScore / 60);
        float hSeconds = HighScore - hMinutes * 60;
        string hSecondString = hSeconds.ToString();
        hSecondString = hSecondString.Length < 2 ? '0' + hSecondString : hSecondString;
        bestTimeBox.text = hMinutes.ToString() + "." + hSecondString;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWon)
        {
            timeStart += Time.deltaTime;
            float totalSeconds = Mathf.Round(timeStart);
            float minutes = Mathf.Floor(totalSeconds / 60);
            float seconds = totalSeconds - minutes * 60;
            string secondString = seconds.ToString();
            secondString = secondString.Length < 2 ? '0' + secondString : secondString;
            timeBox.text = minutes.ToString() + "." + secondString;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Piece"))
            {
                if (!hit.transform.GetComponent<Pieces>().inRightPosition)
                {
                    clickSound.Play();
                    selectedPiece = hit.transform.gameObject;
                    selectedPiece.GetComponent<Pieces>().selected = true;
                    selectedPiece.GetComponent<SortingGroup>().sortingOrder = orderInLayer;
                    orderInLayer++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (selectedPiece != null)
            {
                selectedPiece.GetComponent<Pieces>().selected = false;
                selectedPiece = null;
            }
        }

        if (selectedPiece != null)
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedPiece.transform.position = new Vector3(mousePoint.x, mousePoint.y, 0);
        }
    }

    void LevelWon()
    {
        LevelWonPanel.SetActive(true);
        float totalSeconds = Mathf.Round(timeStart);
        float minutes = Mathf.Floor(totalSeconds / 60);
        float seconds = totalSeconds - minutes * 60;
        string secondString = seconds.ToString();
        secondString = secondString.Length < 2 ? '0' + secondString : secondString;
        currentTime.text = minutes.ToString() + "." + secondString;
        float HighScore = PlayerPrefs.GetFloat("High" + SceneManager.GetActiveScene().name);
        if (HighScore == 0f)
        {
            HighScore = totalSeconds;
        }
        else
        {
            HighScore = totalSeconds < HighScore ? totalSeconds : HighScore;
        }
        PlayerPrefs.SetFloat("High" + SceneManager.GetActiveScene().name, HighScore);
        float hMinutes = Mathf.Floor(HighScore / 60);
        float hSeconds = HighScore - hMinutes * 60;
        string hSecondString = hSeconds.ToString();
        hSecondString = hSecondString.Length < 2 ? '0' + hSecondString : hSecondString;
        highTime.text = hMinutes.ToString() + "." + hSecondString;
        bestTimeBox.text = hMinutes.ToString() + "." + hSecondString;

        int levels = PlayerPrefs.GetInt("levels");
        levels = levels == 0 ? 1 : levels;
        string currentScene = SceneManager.GetActiveScene().name;
        char charCurrentSceneNo = currentScene[currentScene.Length - 1];
        int currentSceneNo = charCurrentSceneNo - '0';
        currentSceneNo = currentSceneNo == 0 ? 10 : currentSceneNo;
        if (levels < currentSceneNo+1)
        {
            PlayerPrefs.SetInt("levels", currentSceneNo + 1);
        }
    }

    public void CorrectPiece()
    {
        correctPieceSound.Play();
        correctedPieces++;
        if (correctedPieces == 36)
        {
            isWon = true;
            LevelWon();
        }
    }

    public void GoHome()
    {
        SceneManager.LoadScene("Home");
    }

}
