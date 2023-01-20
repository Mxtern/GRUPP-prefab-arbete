using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("World(no graphics)");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("player has exited the most epic game ever.");
    }

}