using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzlePiecesScript : MonoBehaviour
{

    private GameObject puzzleManager;
    private PuzzleManager puzzlemanager;
    private int index;
    private bool isDragged, isMoved;
    private Vector3 orPos;
    private GameObject target;

    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        puzzleManager = GameObject.Find("PUZZLE MANAGER");
        puzzlemanager = puzzleManager.GetComponent<PuzzleManager>();
        index = puzzlemanager.puzzlePiece.IndexOf(gameObject);
        target = puzzlemanager.puzzlePlace[index];
    }

    void Update()
    {
        distance = Vector2.Distance(gameObject.transform.position, target.transform.position);
    }

    private void OnMouseDown()
    {
        orPos = transform.position;
    }

    private void OnMouseDrag()
    {
        if (!isDragged)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            isMoved = false;
        }
    }

    private void OnMouseUp()
    {
        isMoved = true;

        if (!isDragged)
        {
            if (distance <= 0.4)
            {
                isDragged = true;
                transform.position = target.transform.position;
                puzzlemanager.AddPuzzle();

            }
            else
            {
                transform.position = orPos;
                isDragged = false;
            }
        }
        
    }


}
