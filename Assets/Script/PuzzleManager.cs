using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public List<GameObject> puzzlePiece;
    public List<GameObject> puzzlePlace;
    public GameObject defPosPoint;
    public float distance, distanceY;

    public string nextscene;

    [SerializeField]
    private int puzzelCount;
    // Start is called before the first frame update
    void Start()
    {
        SetDefPos();
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzelCount >= 4)
        {
            NextScene();
        }
    }

    public void SetDefPos()
    {
        float posX = defPosPoint.transform.position.x;
        float defX = posX;

        float posY = defPosPoint.transform.position.y;
        int multi = puzzlePiece.Count;
        int halfMulti = multi / 2;

        for(int i = 0; i < puzzlePiece.Count; i++)
        {
           // if(multi >= halfMulti)
            //{
                puzzlePiece[i].transform.position = new Vector3(posX, posY, 0f);
              //  PuzlePiecesScript puzzlescript = puzzlePiece[i].GetComponent<PuzlePiecesScript>();
              //  puzzlescript.SetOrPos(puzzlePiece[i].transform.position);

                multi -= 1;
                posX += distance;
            //    if(multi < halfMulti)
              //  {
                   // posX = defX;
                   // posX += distance/2;
               // }
           // }
           /* if (multi < halfMulti)
            {
                puzzlePiece[i].transform.position = new Vector3(posX, posY - distanceY, 0f);

              // PuzlePiecesScript puzzlescript = puzzlePiece[i].GetComponent<PuzlePiecesScript>();
             //   puzzlescript.SetOrPos(puzzlePiece[i].transform.position);
                multi -= 1;
                posX += distance;
            }*/



        }
        SwitchPos();
    }

    public void SwitchPos()
    {
        for (int i = 0; i < puzzlePiece.Count; i++)
        {
            int randomPuzzle = Random.Range(0, puzzlePiece.Count);
            Vector3 puzPos, ranPos;
            puzPos = puzzlePiece[i].transform.position;
            ranPos = puzzlePiece[randomPuzzle].transform.position;
            puzzlePiece[i].transform.position = ranPos;
            puzzlePiece[randomPuzzle].transform.position = puzPos;
          //  PuzlePiecesScript puzzlescript = puzzlePiece[i].GetComponent<PuzlePiecesScript>();
            //puzzlescript.SetOrPos(puzzlePiece[i].transform.position);

        }
    }

    public void AddPuzzle()
    {
        puzzelCount += 1;
    }

    public void NextScene()
    {

        Debug.Log("done");
        SceneManager.LoadScene(nextscene);
    }
}
