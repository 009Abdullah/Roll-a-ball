using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayHud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_ScoreText;

    private void OnEnable()
    {
        ScoreController.ScoreUpdated += OnScoreUpdated;
    }

    private void OnDisable()
    {
        ScoreController.ScoreUpdated -= OnScoreUpdated;
    }

    void OnScoreUpdated(int score)
    {
        m_ScoreText.text = score.ToString();
    }
}
