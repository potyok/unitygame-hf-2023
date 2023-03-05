using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnitmateCollectable : MonoBehaviour
{

    private float orientation = 0f;
    private float rotationSpeed = 200f;


    void Update()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, orientation, 90f));
        orientation = orientation + rotationSpeed * Time.deltaTime;
    }
}
