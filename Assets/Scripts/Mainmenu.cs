using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //för att byta scener
//Ossian
public class Mainmenu : MonoBehaviour
{
    public void Start()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene("World(no graphics)"); // Laddar main spelscen med scenemanager
    }

    public void Quit()
    {
        Application.Quit();// quittar spelet
        Debug.Log("player has exited the most epic game ever.");
    }


}