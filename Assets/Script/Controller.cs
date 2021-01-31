using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float dirX;
    [SerializeField]
    float moveSpeed = 5f;
    Rigidbody2D rb;
    AudioSource run;
    bool isMoving = false;
    public string antijump = "n";

    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        run = GetComponent<AudioSource> ();
    }

    void Update () {
        dirX = Input.GetAxis ("Horizontal") * moveSpeed;
        if((Input.GetKeyDown ("space")) && (antijump == "n"))
        {
            GetComponent<Rigidbody2D> ().velocity = new Vector3 (0,7,0);
            antijump ="y";
        }
        if (GetComponent<Rigidbody2D> ().velocity.y == 0)
            antijump = "n";
        if (rb.velocity.x != 0)
            isMoving = true;
        else 
            isMoving = false;
        if (isMoving) {
            if(!run.isPlaying)
            run.Play();
        }
        else 
            run.Stop();
    }

    void FixedUpdate() 
    {
        rb.velocity = new Vector2 (dirX, rb.velocity.y);
    }
    void GetBall(Collider2D ball)
    {
        if(ball.gameObject.CompareTag("ball"))
            Destroy(ball.gameObject);
    }
}