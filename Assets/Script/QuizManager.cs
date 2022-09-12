using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public int jumlahSoal;
    public Text _jumlahBenar;
    public int jumlahBenar;
    public GameObject QuizPanel;
    public GameObject SeleaiPanel;
    public TMP_Text QuestionText;
    public Text SoalNumber;
    public int Number;
    public static float mainTimer;
    public float setTimer;
    public Text timerText;

    public bool isImage;
    public bool isLevel3;

    public string SOAL;

    [SerializeField]
    private bool playAfterSound;
    [SerializeField]
    private string afterSound;

    public List<Sprite> spriteList;

    // Start is called before the first frame update
    private void Start()
    {

        for (int i = 0; i < QnA.Count; i++)
        {
            QnA[i].soalNomor = i + 1;
        }
        jumlahSoal = QnA.Count;
        Number = 1;

        generateQuestion();
        
        mainTimer = setTimer;


    }

    // Update is called once per frame
    void Update()
    {
      

        _jumlahBenar.text = jumlahBenar.ToString() + " / " + jumlahSoal.ToString();
        SoalNumber.text = "SOAL " + Number.ToString();
        
    }



    public void Next()
    {

        var audioPlayer = FindObjectOfType<AudioPlayer>();
        QnA.RemoveAt(currentQuestion);
        for (int i = 0; i < options.Length; i++)
        {
            spriteList.RemoveAt(((currentQuestion + 1) * 4) - 4);
        }

        if (isLevel3)
        {
            Level3Script level3script = gameObject.GetComponent<Level3Script>();
            level3script.panelsoal[currentQuestion].SetActive(false);
            level3script.panelsoal.RemoveAt(currentQuestion);
        }


        Number += 1;
        generateQuestion();
    }

    public void benar()
    {
        jumlahBenar += 1;
    }

    void SetAnswers(int index)
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            if (isImage)
            {
                options[i].transform.GetChild(1).GetComponent<Image>().sprite = spriteList[i + (((currentQuestion + 1) * 4) -4)];
                Debug.Log(Number);
            }

            if(QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                

            }
        }
    }


    void generateQuestion()
    {

        if (QnA.Count > 0)
        {
            var audioPlayer = FindObjectOfType<AudioPlayer>();

            currentQuestion = Random.Range(0, QnA.Count);

            Debug.Log(SOAL + QnA[currentQuestion].soalNomor.ToString());


            QuestionText.text = QnA[currentQuestion].Question;
            SetAnswers(currentQuestion);

            audioPlayer.PlayTone(SOAL + QnA[currentQuestion].soalNomor.ToString());
            
            if (isLevel3)
            {
                Level3Script level3script = gameObject.GetComponent<Level3Script>();
                level3script.panelsoal[currentQuestion].SetActive(true);
            }
            
        }
       
        if(QnA.Count <= 0)
        {
            if (playAfterSound)
            {
                var audioPlayer = FindObjectOfType<AudioPlayer>();
                audioPlayer.PlayTone(afterSound);
            }
            QuizPanel.SetActive(false);
            SeleaiPanel.SetActive(true);
            
            Debug.Log("SoalHabis");

        }

    }
}
