using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public void jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void salir()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
