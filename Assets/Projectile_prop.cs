using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_prop : MonoBehaviour
{
 
    void OnCollisionEnter2D(Collision2D coll) {

        if (coll.gameObject.tag=="Projectile")
        {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(),GetComponent<Collider2D>());
        }

        if(coll.gameObject.tag=="Boundry") {
            Destroy(gameObject);
        }
    }



}
