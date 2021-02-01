using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public GameObject projectile;
    public Vector2 velocity;
    bool canShoot= true;
    public Vector2 offsetR = new Vector2(0.4f,0.1f);
    public Vector2 offsetL = new Vector2(-0.4f,0.1f);
    public float cooldown = 1f;
    public float ShootDestroy = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.T) && canShoot){
            GameObject go = (GameObject) Instantiate(projectile, (Vector2)transform.position + offsetR * transform.localScale.x, Quaternion.identity);
        
            go.GetComponent<Rigidbody2D>().velocity = new Vector2 (velocity.x * transform.localScale.x, velocity.y);
            Destroy(go, ShootDestroy);
        }
    }

    IEnumerator CanShoot() {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}
