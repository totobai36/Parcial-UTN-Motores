using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManagerTile : MonoBehaviour
{
    public List<Tile> correctSequence; // Asignar en orden desde el Inspector
    public List<Tile> incorrectTiles;
    private int currentIndex = 0;

    public void TileSteppedCorrect(Tile tile)
    {
        if (tile != correctSequence[currentIndex])
        {
            // Baldosa correcta pero fuera de orden ? cuenta como error
            KillPlayer();
            return;
        }

        currentIndex++;

        if (currentIndex >= correctSequence.Count)
        {
            PuzzleCompleted();
        }
    }

    public void TileSteppedIncorrect(Tile tile)
    {
        StartCoroutine(HandleIncorrectStep());
    }
    private IEnumerator HandleIncorrectStep()
    {
        // Opcional: bloquear movimiento del jugador acá si querés
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Bloquear movimiento
        if (player != null)
        {
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
            if (pm != null) pm.canMove = false;
        }

        yield return new WaitForSeconds(0.5f); // Espera

        if (player != null)
        {
            PlayerRespawn respawn = player.GetComponent<PlayerRespawn>();
            if (respawn != null)
            {
                respawn.Respawn();
            }
            // Volver a permitir movimiento
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
            if (pm != null) pm.canMove = true;
        }

        ResetPuzzle();
    }
    void KillPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerRespawn respawn = player.GetComponent<PlayerRespawn>();
            if (respawn != null)
            {
                respawn.Respawn();
            }
        }

        ResetPuzzle();
    }
    public void ResetPuzzle()
    {
        currentIndex = 0;

        // Opcional: reiniciar el estado de las baldosas
        foreach (Tile tile in correctSequence)
        {
            tile.ResetTile();
        }
        foreach (Tile tile in incorrectTiles)
        {
            tile.ResetTile();
        }
    }
    void PuzzleCompleted()
    {
        Debug.Log("Puzzle completado");
        // Abrir puerta, avanzar en la historia, etc.
    }
}
