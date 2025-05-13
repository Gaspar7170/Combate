using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void salir()
    {
        SceneManager.LoadScene("Menu");
    }
}
