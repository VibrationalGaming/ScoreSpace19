using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesPlatform : MonoBehaviour
{
    [SerializeField]
    string playerTag;
    [SerializeField]
    float timeToRotate = 2;
    float tempTime;
    bool rotationBool = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == playerTag)
        collision.rigidbody.velocity = new Vector2(0, 0);
    }

    private void Start()
    {
        tempTime = timeToRotate;
    }

    void RotatePlatform()
    {

        if (rotationBool)
            transform.rotation = new Quaternion(0, 0, 180, 0);
        else
            transform.rotation = new Quaternion(0, 0, 0, 0);

        rotationBool = !rotationBool;
        timeToRotate = tempTime;
    }

    private void Update()
    {
        timeToRotate -= Time.deltaTime;
        if (timeToRotate <= 0)
            RotatePlatform();
    }
}
