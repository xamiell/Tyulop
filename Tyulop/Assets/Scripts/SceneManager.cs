using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] string nextSceneName;

    public void OnLoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }

    public void OnExitGame()
    {
        Application.Quit();
    }
}
