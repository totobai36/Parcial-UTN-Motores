using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión con: " + other.name);
        if (other.CompareTag("Player"))
        {
            PlayerRespawn respawn = other.GetComponent<PlayerRespawn>();
            if (respawn != null)
            {
                respawn.Respawn();
            }

            // Opcional: reiniciar el puzzle si querés que también se resetee
            PuzzleManagerTile manager = FindObjectOfType<PuzzleManagerTile>();
            if (manager != null)
            {
                manager.ResetPuzzle();
            }
        }
    }
}
