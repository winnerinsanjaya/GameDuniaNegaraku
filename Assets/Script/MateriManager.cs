using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MateriManager : MonoBehaviour
{

    public Text judulMateri;
    public GameObject characterAnim;
    private Animator charAnim;

    public bool isPlay;

    // Start is called before the first frame update
    void Start()
    {
        charAnim = characterAnim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        judulMateri.text = ("MATERI " + ButtonManager.Level);

        if (isPlay)
        {
            charAnim.SetBool("isMenjelaskan", true);
        }

        if (!isPlay)
        {
            charAnim.SetBool("isMenjelaskan", false);
        }
    }
}
