using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int _numberSerialFild;

    public void LoadLevel()
    {
        SceneManager.LoadScene(_numberSerialFild);
    }

    public void ExitGame()
    {
        Debug.Log("Exix");
        Application.Quit();
    }
}
