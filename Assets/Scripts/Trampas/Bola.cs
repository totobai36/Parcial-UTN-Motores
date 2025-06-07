using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bola : MonoBehaviour
{
   
   
 
    public Rigidbody rb;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

  

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                //collision.gameObject.GetComponent<PlayerVida>().Matar();
                Debug.Log("Jugador golpeado por la bola");           
        }
    }
}