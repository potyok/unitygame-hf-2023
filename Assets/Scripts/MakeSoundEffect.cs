using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSoundEffect : MonoBehaviour
{
    public AudioSource hornEffect;
    public AudioSource crashEffect;
    public AudioSource coinEffect;
    public AudioSource wrenchEffect;
    public AudioSource tankFillEffect;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {
            hornEffect.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            crashEffect.Play();

        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinEffect.Play();

        } else if (other.gameObject.CompareTag("Wrench"))
        {
            wrenchEffect.Play();
        } else if (other.gameObject.CompareTag("OilTank"))
        {
            tankFillEffect.Play();
        }
    }


}
