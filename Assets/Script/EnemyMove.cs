using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public  float speed;
    public bool MoveRight;

    void Update()
    {
        if (MoveRight) {
            transform.Translate(2 * Time.deltaTime * speed ,0,0);
        }
        else {
            transform.Translate(-2 * Time.deltaTime * speed ,0,0);
        }
    } 

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("turner"))

            transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
            if(MoveRight) {
                MoveRight = false;
            }
            else {
                MoveRight = true;
            }
    }
}
