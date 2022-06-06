using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// God: https://www.youtube.com/watch?v=Q-_J9S6NaC0

public class PlayerController : MonoBehaviour
{


    private Rigidbody2D rb;

    public float power;
    public Vector2 minPower;
    public Vector2 maxPower;

    private Camera cam;
    private Vector2 force;
    private Vector3 start;
    private Vector3 end;

    private LineController lineC;

    public bool inAir;

    public AudioSource audio;
    public AudioClip gettingReady;
    public AudioClip jumpingWhoosh;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        cam = Camera.main;

        power = 2f;
        minPower = new Vector2(-5f, -5f);
        maxPower = new Vector2(5f, 5f);

        lineC = GetComponent<LineController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !inAir)
        {
            // Dragging();
            start = cam.ScreenToWorldPoint(Input.mousePosition);
            start.z = 15;

            audio.clip = gettingReady;
            audio.Play();
            // Debug.Log(start);
        }

        if (Input.GetMouseButton(0) && !inAir)
        {
            Vector3 current = cam.ScreenToWorldPoint(Input.mousePosition);
            current.z = 15;

            lineC.Render(start, current);
        }

        if (Input.GetMouseButtonUp(0) && !inAir)
        {
            end = cam.ScreenToWorldPoint(Input.mousePosition);
            end.z = 15;
            // Debug.Log(end);

            force = new Vector2(Mathf.Clamp(start.x - end.x, minPower.x, maxPower.x), 
                                Mathf.Clamp(start.y - end.y, minPower.y, maxPower.y));

            if (end.y < start.y)
            {
                rb.AddForce(force * power, ForceMode2D.Impulse);
                audio.clip = jumpingWhoosh;
                audio.Play();
            }

            // inAir = true;
            lineC.UnRender();
        }
        
    }
}
