using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringCar : MonoBehaviour
{
    private GameController controller;
    private float leftBorder = 6f;
    private float rightBorder = -1f;

    void Start()
    {
        controller = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    void Update()
    {
        float speed = controller.SteeringSpeed;
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            
            if (transform.position.z >= leftBorder)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, leftBorder);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position -= new Vector3(0, 0, speed * Time.deltaTime);

            if (transform.position.z <= rightBorder)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, rightBorder);
                
            }
            
        }

        
    }
}
