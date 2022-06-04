using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public string destroyTag;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == destroyTag)
            Destroy(collision.gameObject);
    }
}
