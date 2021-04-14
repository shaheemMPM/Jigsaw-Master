using UnityEngine;
using UnityEngine.Rendering;

public class Pieces : MonoBehaviour
{

    private Vector3 rightPosition;
    private Vector3 targetPosition;
    public bool inRightPosition;
    public bool selected;
    DragAndDrop dragAndDrop;

    // Start is called before the first frame update
    void Start()
    {
        rightPosition = transform.position;
        targetPosition = new Vector3(Random.Range(-1.5f, 18f), Random.Range(-7.75f, 5f), 0);

        transform.position = targetPosition;

        dragAndDrop = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DragAndDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, rightPosition) < 0.9f)
        {
            if (!selected)
            {
                if (!inRightPosition)
                {
                    transform.position = rightPosition;
                    inRightPosition = true;
                    dragAndDrop.CorrectPiece();
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }   
    }
}
