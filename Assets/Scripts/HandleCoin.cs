using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCoin : MonoBehaviour
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
            controller.handleCoin();
            Destroy(this.gameObject);

        }
    }
}
