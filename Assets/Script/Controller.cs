using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Animator animator;
    float dirX;
    [SerializeField]
    public float moveSpeed = 5f;
    public float jumpSpeed = 7;
    Rigidbody2D rb;
    AudioSource run;
    bool isMoving = false;
    public string antijump = "n";
    PlayerItems items;
    PlayerHealth life;

    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        run = GetComponent<AudioSource> ();
        items = GetComponent<PlayerItems> ();
        life = GetComponent<PlayerHealth> ();
    }

    void Update () {
        dirX = Input.GetAxis ("Horizontal") * moveSpeed;
        animator.SetFloat("Movement", Mathf.Abs(dirX));
        if((Input.GetKeyDown ("space")) && (antijump == "n"))
        {
            GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, jumpSpeed, 0);
            antijump ="y";
            animator.SetBool("IsJumping", true);
        }
        if (GetComponent<Rigidbody2D> ().velocity.y == 0) 
        {
            antijump = "n";
            animator.SetBool("IsJumping", false);
        }
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
        animator.SetBool("IsAlive", life.IsAlive());
    }

    void FixedUpdate() 
    {
        rb.velocity = new Vector2 (dirX, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D item)
    {
        if(item.gameObject.CompareTag("ball")) {
            Destroy(item.gameObject);
            items.AddItem();
        }
        if(item.gameObject.CompareTag("Die"))
            life.Die();
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            life.RemoveLife()
        }
    }
}