using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Finish : MonoBehaviour
{
    private Scorer scorer;
    private float finalScore;

    public string scene;
    
    void Start()
    {
        scorer = GameObject.FindGameObjectsWithTag("Scorer")[0].GetComponent<Scorer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            StartCoroutine(ShowScreen());
        }
    }
    
    IEnumerator ShowScreen()
    {
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        PlayerPrefs.SetInt("FinalScore", (int)scorer.scoreAmt);
        Debug.Log(PlayerPrefs.GetInt("FinalScore"));

        SceneManager.LoadScene(scene);
    }
}
