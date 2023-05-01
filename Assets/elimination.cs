using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elimination : MonoBehaviour
{
    public bool playerDead = false;

    public Vector3 lockPos = new Vector3(-.5f,.5f,0f);
 
    void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.tag.Equals("Projectile")) {
            gameObject.GetComponent<Transform>().position = lockPos;
            gameObject.GetComponent<MovementTest>().enabled=false;
            gameObject.GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezeAll;
            gameObject.GetComponent<BoxCollider2D>().enabled=false;
            Destroy(coll.gameObject);
            playerDead = true;
        }
    }


}
