using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorBola : MonoBehaviour
{
    public Rigidbody bola; // Drag & drop la bola en el Inspector

    private bool activado = false;

    void OnTriggerEnter(Collider other)
    {
        if (!activado && other.CompareTag("Player"))
        {
            activado = true;
            bola.useGravity = true;
            bola.isKinematic = false;
        }
    }
}