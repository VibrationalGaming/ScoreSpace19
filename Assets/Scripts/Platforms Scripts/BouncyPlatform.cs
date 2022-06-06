using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    // [SerializeField]
    // string playerTag;

    public int counter;

    public AudioSource audio;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            audio.Play();

            // Set playerscript inAir bool to false, too allow jumping again
            collision.gameObject.GetComponent<PlayerController>().inAir = false;

            
            // counter++;
            // if (counter > 1)
            // {
            //     collision.rigidbody.velocity = new Vector2(0, 0);  
            //     counter = 0;
            // }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Set playerscript inAir bool to true, too signify it is jumping
        if (collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().inAir = true;
            // if (counter > 1)
            // {
            //     counter = 0;
            // }
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().color = Color.grey;
            StartCoroutine(ResetBouncy());
        }
    }


    private IEnumerator ResetBouncy()
    {
        yield return new WaitForSeconds(5f);
        this.GetComponent<SpriteRenderer>().color = Color.green;
        this.GetComponent<Collider2D>().enabled = true;
    }
}
