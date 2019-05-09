using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondaryMenu : MonoBehaviour
{
    public Button backToMenu;

    // Start is called before the first frame update
    void Start()
    {
        backToMenu.onClick.AddListener(ReturnToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
