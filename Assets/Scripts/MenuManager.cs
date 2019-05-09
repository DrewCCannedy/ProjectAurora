using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour    
{

    public Button menuStart, menuQuit, menuCC;

    // Start is called before the first frame update
    void Start()
    {
        menuStart.onClick.AddListener(StartGame);
        menuQuit.onClick.AddListener(QuitGame);
        menuCC.onClick.AddListener(GoToCC);
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void GoToCC()
    {
        SceneManager.LoadScene(2);
    }

}
