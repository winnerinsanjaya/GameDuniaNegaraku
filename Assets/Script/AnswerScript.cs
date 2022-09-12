using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Answer()
    {
        if (isCorrect)
        {

            var audioPlayer = FindObjectOfType<AudioPlayer>();
            audioPlayer.PlayAnswer("CORRECT");
            Debug.Log("Correct Answer");
            quizManager.Next();
            quizManager.benar();
        }
        else
        {
            var audioPlayer = FindObjectOfType<AudioPlayer>();
            audioPlayer.PlayAnswer("WRONG");

            Debug.Log("Wrong Answer");
            quizManager.Next();
        }
    }
}
