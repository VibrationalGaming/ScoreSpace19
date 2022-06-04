using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyPlatform : MonoBehaviour
{
    [SerializeField]
    string playerTag;
    public float playerSlidingSpeed;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == playerTag)
            collision.rigidbody.velocity = new Vector2(playerSlidingSpeed, 0);
    }
}
