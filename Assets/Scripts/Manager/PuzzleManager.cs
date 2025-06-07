using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    public Torch[] torches;
    public GameObject doorToOpen;

    private void Awake()
    {
        Instance = this;
    }

    public void CheckSolution()
    {
        foreach (Torch torch in torches)
        {
            if ((torch.isCorrectTorch && !torch.isLit) || (!torch.isCorrectTorch && torch.isLit))
            {
                return;
            }
        }

        OpenDoor();
    }

    void OpenDoor()
    {
        Debug.Log("¡Puzzle resuelto!");
        doorToOpen.SetActive(false); // o jugar animación
    }
}