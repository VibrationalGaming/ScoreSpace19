using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource PlayClickSound;
    public AudioSource QuitClickSound;

    public void LeaderBoard()
    {
        StartCoroutine(LeaderBoardCon());
    }
    public void PlayGame()
    {
        PlayerPrefs.SetInt("FinalScore", 0);
        StartCoroutine(PlayGameCon());
    }
    public void QuitGame()
    {
        StartCoroutine(QuitGameCon());
    }
    private IEnumerator PlayGameCon()
    {
        PlayClickSound.Play();
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Level1");
    }

    private IEnumerator QuitGameCon()
    {
        QuitClickSound.Play();
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Quit!");
        Application.Quit();
    }

    private IEnumerator LeaderBoardCon()
    {
        PlayClickSound.Play();
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("LeaderBoard");
    }
}
