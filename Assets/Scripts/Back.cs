using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public AudioSource QuitClickSound;

    public void QuitGame()
    {
        StartCoroutine(QuitGameCon());
    }

    private IEnumerator QuitGameCon()
    {
        QuitClickSound.Play();
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Menu");
    }
}
