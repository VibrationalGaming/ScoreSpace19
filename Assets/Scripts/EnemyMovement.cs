using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform targetTrans;
    Vector2 followVec;
    public float fSpeed;
    Rigidbody2D enemyRb;
    [SerializeField]
    Rigidbody2D PlayerRb;
    public float distance;
    [SerializeField]
    AudioSource audio;

    Vector2 startPosition;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }
    void Update()
    {
        followVec = targetTrans.position - transform.position;
        if (Mathf.Abs(followVec.x) <= distance)
            enemyRb.velocity = fSpeed * followVec.normalized;
        else
            enemyRb.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audio.Play();
            PlayerRb.velocity = new Vector2(0, 0);
            collision.gameObject.transform.position = new Vector3(-7f, 1.5f, 0f);
            enemyRb.velocity = new(0, 0);
            transform.position = startPosition;
            //gameObject.GetComponent<EnemyMovement>().enabled = false;
        }
    }
}
