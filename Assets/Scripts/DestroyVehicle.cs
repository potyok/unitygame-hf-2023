using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVehicle : MonoBehaviour
{
    public int damage = 0;
    public ParticleSystem explosion;
    private GameController controller;
    private float radius = 90f;
    private float destroyHeight = -1f;
    
    void Start()
    {
        controller = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

   
    void Update()
    {
        if (transform.position.y < destroyHeight) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.handleDamage(damage * ((transform.rotation.y > radius) ? 2 : 1));
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(this.gameObject);

        }
    }
}
