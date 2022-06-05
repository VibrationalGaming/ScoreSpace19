using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesPlatform : MonoBehaviour
{
    [SerializeField]
    float timeToRotate;
    float tempTime;
    
    
    private bool rotating;

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

    private void Start()
    {
        // tempTime = timeToRotate;
        timeToRotate = 4f;
        StartCoroutine(RotatePlatform(-18));
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log(transform.localEulerAngles.z > 0);


        // Rotate Anti-Clockwise
        if (transform.localEulerAngles.z >= 180 && !rotating)
            StartCoroutine(RotatePlatform(18));

        // Rotate Clockwise
        if (transform.localEulerAngles.z <= 0 && !rotating)
            StartCoroutine(RotatePlatform(-18));
    }


    private IEnumerator RotatePlatform(int rotate)
    {
        rotating = true;
        // Debug.Log("About to rotate");
        yield return new WaitForSeconds(timeToRotate);

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.002f);
            this.transform.Rotate(0,0, rotate);

            // Debug.Log(transform.localEulerAngles.z);
        }

        rotating = false;
    }

}
