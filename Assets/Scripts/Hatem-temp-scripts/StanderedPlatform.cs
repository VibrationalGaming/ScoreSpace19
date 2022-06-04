using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanderedPlatform : MonoBehaviour
{
    [SerializeField]
    string playerTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == playerTag)
        collision.rigidbody.velocity = new Vector2(0, 0);
    }
}
