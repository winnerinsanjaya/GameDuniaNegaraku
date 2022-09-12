using UnityEngine;
using System.Collections;
[System.Serializable]
public class QuestionAndAnswer
{
    [TextArea]
    public string Question;
    public string[] Answers;
    public int CorrectAnswer;

    public int soalNomor;
}
