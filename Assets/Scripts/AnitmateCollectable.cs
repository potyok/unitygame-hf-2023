using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnitmateCollectable : MonoBehaviour
{
    public float rotationX = 0f;
    public float rotationY = 0f;

    private float orientation = 0f;
    private float rotationSpeed = 5f;
    private float angle = 0f;
    private float amplitude = 0.2f;
    private float offset = 0f;
    private float angleSpeed = 5f;
    private float maxAngle = 360f;
    private float height = 0f;

    void Start() {
        height = this.transform.position.y;
        offset = Random.value;
    }

    void FixedUpdate()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(rotationX, orientation, rotationY));
        orientation = orientation + rotationSpeed;
        if (angle > maxAngle) {
            angle -= maxAngle;
        }
        this.transform.position = new Vector3(this.transform.position.x, height + amplitude * Mathf.Sin(angle * Mathf.Deg2Rad + offset), this.transform.position.z);
        angle += angleSpeed;
    }
}
