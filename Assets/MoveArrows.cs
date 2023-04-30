using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrows : MonoBehaviour
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

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {  
            MovementY = 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {  
            MovementY = -1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {  
            MovementX = -1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {  
            MovementX = 1;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)){
            MovementX = 0;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)){
            MovementY = 0;
        }
        
    }
}
