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
    Rigidbody2D playerRb;


    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        followVec = targetTrans.position - transform.position;
        enemyRb.velocity = fSpeed * followVec.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(playerRb.gameObject);
            enemyRb.velocity = new(0, 0);
            gameObject.GetComponent<EnemyMovement>().enabled = false;
        }
    }
}
