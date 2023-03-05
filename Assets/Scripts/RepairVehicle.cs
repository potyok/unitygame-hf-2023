using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairVehicle : MonoBehaviour
{
    private GameController controller;
    
    void Start()
    {
        controller = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controller.handleRepair();
            Destroy(this.gameObject);

        }
    }
}
