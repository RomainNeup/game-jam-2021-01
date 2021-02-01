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
    public GameObject spawnPoint;
    PlayerItems items;
    PlayerHealth life;
    GameManager game;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        run = GetComponent<AudioSource>();
        items = GetComponent<PlayerItems>();
        life = GetComponent<PlayerHealth>();
        game = GetComponent<GameManager>();
    }
    public void StartGame()
    {
        this.transform.position = spawnPoint.transform.position;
        game.setGameState(GameManager.STATES.INGAME);
        life.Heal();
    }

    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * moveSpeed;
        if (life.getHeal() == 0)
            game.setGameState(GameManager.STATES.DEAD);
        if (items.getCurrentItems() == items.total)
            game.setGameState(GameManager.STATES.WIN);
        if (game.GameState == GameManager.STATES.INGAME)
        {
            if ((dirX < 0 && transform.localScale.x > 0) || (dirX > 0 && transform.localScale.x < 0))
                transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
            if ((Input.GetKeyDown("space")) && (antijump == "n"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpSpeed, 0);
                antijump = "y";
                animator.SetBool("IsJumping", true);
            }
            if (GetComponent<Rigidbody2D>().velocity.y == 0)
            {
                antijump = "n";
                animator.SetBool("IsJumping", false);
            }
            if (rb.velocity.x != 0)
                isMoving = true;
            else
                isMoving = false;
            if (isMoving)
                if (!run.isPlaying)
                    run.Play();
                else
                    run.Stop();
        }
        animator.SetFloat("Movement", Mathf.Abs(dirX));
        animator.SetBool("IsAlive", life.IsAlive());
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D item)
    {
        if (item.gameObject.CompareTag("ball"))
        {
            Destroy(item.gameObject);
            items.AddItem();
        }
        if (item.gameObject.CompareTag("Die"))
            life.Die();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
            life.RemoveLife();
    }
}