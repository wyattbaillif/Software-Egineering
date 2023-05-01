using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWasd : MonoBehaviour
{
    public float Speed;

    float MovementY;
    float MovementX;

    Rigidbody2D Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        MovementX = 0;
        MovementY = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(MovementX, MovementY, 0.0f);
        transform.position += moveDirection * Speed;

        if (Input.GetKeyDown(KeyCode.W))
        {  
            MovementY = 1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {  
            MovementY = -1;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {  
            MovementX = -1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {  
            MovementX = 1;
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)){
            MovementX = 0;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)){
            MovementY = 0;
        }
        
    }
}
