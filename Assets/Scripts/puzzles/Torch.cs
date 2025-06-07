using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool isCorrectTorch = false;
    public bool isLit = false;
    public GameObject flameEffect;

    public void Toggle()
    {
        isLit = !isLit;
        flameEffect.SetActive(isLit);
        PuzzleManager.Instance.CheckSolution();
    }
}
