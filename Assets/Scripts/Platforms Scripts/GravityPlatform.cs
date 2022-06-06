using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatform : MonoBehaviour
{
    // [SerializeField]
    // string playerTag;

    public AudioSource audio;
    public AudioClip standard;
    public AudioClip gravity;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            audio.clip = standard;
            audio.Play();

            collision.rigidbody.velocity = new Vector2(0, 0);
            collision.rigidbody.gravityScale = 2.1f;

            // Set playerscript inAir bool to false, too allow jumping again
            collision.gameObject.GetComponent<PlayerController>().inAir = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Set playerscript inAir bool to true, too signify it is jumping
        if (collision.collider.tag == "Player")
        {
            audio.clip = gravity;
            audio.Play();

            collision.gameObject.GetComponent<PlayerController>().inAir = true;
            StartCoroutine(ResetGravity(collision));
        }
    }

    private IEnumerator ResetGravity(Collision2D player)
    {
        yield return new WaitForSeconds(1f);
        player.rigidbody.gravityScale = 3f;
    }
}
