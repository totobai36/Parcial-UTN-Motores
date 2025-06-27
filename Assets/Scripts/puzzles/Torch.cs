using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool isCorrectTorch = false;
    public bool isLit = false;
    public GameObject flameEffect;

    void Start()
    {
        flameEffect.SetActive(isLit); // sincroniza estado inicial
    }

    public void Toggle()
    {
        isLit = !isLit;
        flameEffect.SetActive(isLit);
        PuzzleManager.Instance.CheckSolution();
    }
}
