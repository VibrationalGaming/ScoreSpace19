using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    public AudioSource audio;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            audio.Play();
            collision.rigidbody.velocity = new Vector2(0, 0);
            collision.gameObject.transform.position = new Vector3(-7f, 1.5f, 0f);
        }
    }
}
