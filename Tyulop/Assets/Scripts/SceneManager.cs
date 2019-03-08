using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] string nextSceneName;
    [SerializeField] AudioClip audioClick;
    [SerializeField] AudioSource musicBackground;

    private void Start()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(musicBackground);
    }

    public void OnLoadScene()
    {
        PlayClickSound();

        //StartCoroutine(nameof(WaitBeforeExecuteMethod));

        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }

    //IEnumerator WaitBeforeExecuteMethod()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //}

    private void PlayClickSound()
    {
        AudioSource.PlayClipAtPoint(audioClick, Camera.main.transform.position);
    }

    public void OnExitGame()
    {
        PlayClickSound();
        //StartCoroutine(WaitBeforeExecuteMethod());

        Application.Quit();
    }
}
