using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMotion : MonoBehaviour
{
    public bool isVehicle = false;
    private GameController controller;
    public float splitterPoint = 2f;
    
    void Start()
    {
        controller = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    void FixedUpdate() 
    {
        float speed = controller.getSpeed(isVehicle, (transform.position.z < splitterPoint));
        transform.position += Vector3.left * speed;
    }
}
