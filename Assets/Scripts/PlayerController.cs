using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// God: https://www.youtube.com/watch?v=Q-_J9S6NaC0

public class PlayerController : MonoBehaviour
{

    private float power;

    private Rigidbody2D rb;

    private Vector2 minPower;
    private Vector2 maxPower;

    private Camera cam;
    private Vector2 force;
    private Vector3 start;
    private Vector3 end;

    private LineController lineC;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        cam = Camera.main;

        power = 5f;
        minPower = new Vector2(-3f, -3f);
        maxPower = new Vector2(3f, 3f);

        lineC = GetComponent<LineController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Dragging();
            start = cam.ScreenToWorldPoint(Input.mousePosition);
            start.z = 15;
            Debug.Log(start);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 current = cam.ScreenToWorldPoint(Input.mousePosition);
            current.z = 15;

            lineC.Render(start, current);
        }

        if (Input.GetMouseButtonUp(0))
        {
            end = cam.ScreenToWorldPoint(Input.mousePosition);
            end.z = 15;

            force = new Vector2(Mathf.Clamp(start.x - end.x, minPower.x, maxPower.x), 
                                Mathf.Clamp(start.y - end.y, minPower.y, maxPower.y));
            
            rb.AddForce(force * power, ForceMode2D.Impulse);

            lineC.UnRender();
        }
    }

    private void Dragging()
    {
        // Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        start = cam.ScreenToWorldPoint(Input.mousePosition);
        start.z = 15;
        Debug.Log(start);

        // rb.position = mousePosition;
    }

    // private void OnMouseDown()
    // {
    //     pressed = true;
    //     rb.isKinematic = true;
    //     // rb.bodyType = RigidbodyType2D.Dynamic;
    // }

    // private void OnMouseUp()
    // {
    //     pressed = false;
    //     rb.isKinematic = false;
    //     StartCoroutine(Release());
    // }

    // private IEnumerator Release()
    // {
    //     yield return new WaitForSeconds(releaseDelay);
    //     sj.enabled = false;
    // }

}
