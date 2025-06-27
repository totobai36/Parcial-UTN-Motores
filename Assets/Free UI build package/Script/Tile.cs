using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isCorrectTile = false; // ¿Es parte de la secuencia correcta?
    private bool hasBeenSteppedOn = false;

    public PuzzleManagerTile puzzleManagerTile;

    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenSteppedOn || !other.CompareTag("Player")) return;

        hasBeenSteppedOn = true;

        if (isCorrectTile)
        {
            puzzleManagerTile.TileSteppedCorrect(this);
        }
        else
        {
            puzzleManagerTile.TileSteppedIncorrect(this);
        }
    }


    public void ResetTile()
    {
        hasBeenSteppedOn = false;

        // Si agregaste visuales como colores o materiales, los podés resetear acá también
    }
}

