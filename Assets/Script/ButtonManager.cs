using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public GameObject _optionPanel;
    public GameObject _mainMenu;
    public GameObject
        evaluasiPanel,
        caraMainPanel,
        tentangPanel;

    public GameObject
        hintPanel;


    [SerializeField]
    private bool PlaySoundFirst;
    [SerializeField]
    private string soundName;

    public static int Level;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Options()
    {
        _optionPanel.SetActive(true);
        _mainMenu.SetActive(false);
    }

    public void Evaluasi()
    {
        evaluasiPanel.SetActive(true);
        _mainMenu.SetActive(false);
    }

    public void Tentang()
    {
        tentangPanel.SetActive(true);
        _mainMenu.SetActive(false);
    }

    public void CaraMain()
    {
        caraMainPanel.SetActive(true);
        _mainMenu.SetActive(false);
    }

    public void MainMenu()
    {
        evaluasiPanel.SetActive(false);
        caraMainPanel.SetActive(false);
        tentangPanel.SetActive(false);
        _optionPanel.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void goMap()
    {
        SceneManager.LoadScene("MapScreen");
    }

    public void goGame(int level)
    {
        Level = level;
        Debug.Log("level = " + Level.ToString());
        SceneManager.LoadScene("Game"+level);
        
    }

  
    public void goMateri(int level)
    {
        Level = level;
        Debug.Log("Materi = " + Level.ToString());
        SceneManager.LoadScene("Materi" + level);

    }
   

    public void goMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Hint()
    {
        hintPanel.SetActive(true);
    }

    public void ExtraWaktu()
    {
        Debug.Log("extra waktu");
    }

    public void GoToScene(string scenename)
    {
        if (PlaySoundFirst)
        {
            PlayTone(soundName);
        }
        SceneManager.LoadScene(scenename);
    }

    public void PlayTone(string name)
    {
        var tonemanager = FindObjectOfType<ToneManager>();
        tonemanager.Play(name);
    }

    public void StopPlay()
    {
        var tonemanager = FindObjectOfType<ToneManager>();
        tonemanager.StopPlay();
    }

}
