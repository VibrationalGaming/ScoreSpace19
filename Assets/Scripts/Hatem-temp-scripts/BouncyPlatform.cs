using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    // [SerializeField]
    // string playerTag;

    public int counter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            // Set playerscript inAir bool to false, too allow jumping again
            collision.gameObject.GetComponent<PlayerController>().inAir = false;

            
            counter++;
            if (counter > 2)
            {
                //it will be implemented even if you're coliding multiple time by movement not just bouncyness
                collision.rigidbody.velocity = new Vector2(0, 0);  
                counter = 0;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Set playerscript inAir bool to true, too signify it is jumping
        if (collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().inAir = true;
        }
    }
}
