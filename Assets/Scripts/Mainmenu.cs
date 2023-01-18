using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Ossian scen");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("playr has exited the most epic game ever.");
    }

}