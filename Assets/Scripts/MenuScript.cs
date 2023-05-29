using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public bool hoverPlay = false;
    public bool hoverQuit = false;
    public bool hoverHowTo = false;

    private void Awake()
    {

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Click");
            Debug.Log("hoverPlay: " + hoverPlay);
            if (hoverPlay)
            {
                Debug.Log(" click Play");
                PlayGame();
            }
            else if (hoverQuit)
            {
                Debug.Log(" click Quit");
                QuitGame();
            }
            else if (hoverHowTo)
            {
                Debug.Log(" click HowTo");
                SceneManager.LoadScene("HowTo");
            }
        }
    }
}
