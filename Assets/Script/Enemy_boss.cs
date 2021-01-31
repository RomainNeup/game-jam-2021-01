using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_boss : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float raycastLenght;
    public float attackDistance;
    public float mooveSpeed;
    public float timer;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    #endregion

    void Awake()
    {
        intTimer = timer;
    }

    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, raycastLenght, raycastMask);
            RaycastDebugger();
        }
        if(hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }
        if (inRange == false)
        {
            StopAttack();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if(distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }
    }

    void  OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player") 
        {
            target = trig.gameObject;
            inRange = true;
        }
    }

    void Move()
    {
        Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, mooveSpeed * Time.deltaTime);
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;
        Debug.Log("salam");  
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        Debug.Log("fin d'attaque");
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * raycastLenght, Color.red);
        }
        else if(attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * raycastLenght, Color.green);
        }
    }
}
