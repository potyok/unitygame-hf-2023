using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillTank : MonoBehaviour
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
            controller.handleFillTank(10f);
            Destroy(this.gameObject);
        }
    }
}
