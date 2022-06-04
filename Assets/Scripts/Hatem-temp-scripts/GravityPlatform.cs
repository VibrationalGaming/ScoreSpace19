using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatform : MonoBehaviour
{
    // [SerializeField]
    // string playerTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.rigidbody.velocity = new Vector2(0, 0);

            // Set playerscript inAir bool to false, too allow jumping again
            collision.gameObject.GetComponent<PlayerController>().inAir = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Set playerscript inAir bool to true, too signify it is jumping
        if (collision.collider.tag == "Player")
            collision.gameObject.GetComponent<PlayerController>().inAir = true;
    }

}
