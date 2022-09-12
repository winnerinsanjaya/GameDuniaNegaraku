using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private bool PlaySoundFirst;
    [SerializeField]
    private string soundName;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Game1A1")
        {
            PlayTone("1A");
        }

        if (scene.name == "Game1B1")
        {
            PlayTone("1B");
        }

        if (PlaySoundFirst)
        {
            PlayTone(soundName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayTone(string name)
    {
        var tonemanager = FindObjectOfType<ToneManager>();
        tonemanager.StopPlay();
        tonemanager.Play(name);
    }
    public void PlayAnswer(string name)
    {
        var answersound = FindObjectOfType<AnswerSound>();
        answersound.StopPlay();
        answersound.Play(name);
    }



}
