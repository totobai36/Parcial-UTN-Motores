using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText; // Referencia al componente TextMeshPro en el Canvas

    private void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("No se asignó el componente TextMeshProUGUI en el Inspector.");
            return;
        }

        // Actualizar el texto al inicio
        UpdateScoreText();
    }

    private void Update()
    {
        // Actualizar el texto en cada frame
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (GameManager.Instance != null)
        {
            scoreText.text = GameManager.Instance.GetScore().ToString();
        }
    }
}
