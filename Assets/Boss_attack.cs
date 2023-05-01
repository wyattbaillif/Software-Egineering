using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_attack : MonoBehaviour
{

    public float force;
    public float randomRange;
    public GameObject prefab;
    public float attackDelay = 1f; // interval between attacks

    public float duration = 5f; // duration of projectile before deleted

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot_projectile", 0f, attackDelay);
    }

    void Shoot_projectile()
    {
        Vector3 centerPosition = new Vector3(0, 0, 0);

        // Create an instance of the prefab at the center position
        GameObject instance = Instantiate(prefab, centerPosition, Quaternion.identity);

        // Generate a random direction vector
        Vector3 randomDirection = Random.insideUnitSphere * randomRange;

        // Add the force to the instance
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        rb.AddForce(randomDirection * force);
        
        // Start the coroutine to destroy the clone after a set duration
        StartCoroutine(DestroyTimer(duration, instance));
    }

    IEnumerator DestroyTimer(float duration, GameObject clone)
    {
        yield return new WaitForSeconds(duration);

        // Destroy the clone
        Destroy(clone);
    }

    private void OnTriggerEnter(Collider other) 
    {
        // Destroy the clone if it collides with another gameobject
        if (other.gameObject.tag != "Boss")
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
