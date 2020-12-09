using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBut : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Generator");
    }
}
