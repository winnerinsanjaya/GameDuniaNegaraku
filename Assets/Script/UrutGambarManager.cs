using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UrutGambarManager : MonoBehaviour
{

    public List<GameObject> urutgambar;

    public List<GameObject> rightwrong;

    private int urutan;

    public string nextscene;

    [SerializeField]
    private bool playAfterSound;
    [SerializeField]
    private string afterSound;
    // Start is called before the first frame update
    void Start()
    {
        SwitchPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);


            if (hit.collider != null)
            {
                GameObject hitted = hit.collider.gameObject;

                if (hitted == urutgambar[urutan])
                {
                    Instantiate(rightwrong[0], urutgambar[urutan].transform.position, Quaternion.identity);
                    hitted.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
                    urutan += 1;
                    return;
                }

                if (hitted != urutgambar[urutan])
                {
                    Instantiate(rightwrong[1], hitted.transform.position, Quaternion.identity);
                    

                }
            }
        }
        if(urutan == 5)
        {
            NextScene();
        }
    }

    public void SwitchPos()
    {
        for (int i = 0; i < urutgambar.Count; i++)
        {
            int randomPuzzle = Random.Range(0, urutgambar.Count);
            Vector3 puzPos, ranPos;
            puzPos = urutgambar[i].transform.position;
            ranPos = urutgambar[randomPuzzle].transform.position;
            urutgambar[i].transform.position = ranPos;
            urutgambar[randomPuzzle].transform.position = puzPos;
            //  PuzlePiecesScript puzzlescript = puzzlePiece[i].GetComponent<PuzlePiecesScript>();
            //puzzlescript.SetOrPos(puzzlePiece[i].transform.position);

        }
    }


    public void NextScene()
    {
        if (playAfterSound)
        {
            var audioPlayer = FindObjectOfType<AudioPlayer>();
            audioPlayer.PlayTone(afterSound);
        }
        Debug.Log("done");
        SceneManager.LoadScene(nextscene);
    }
}
