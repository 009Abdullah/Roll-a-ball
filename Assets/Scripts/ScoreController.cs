using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ScoreController
{
    
    private static int m_Score = 0;

    public static int Score => m_Score;

    public static Action<int> ScoreUpdated;

    public static void ResetScore()
    {
        m_Score = 0;
        ScoreUpdated?.Invoke(m_Score);
    }

    public static void AddScore(int score)
    {
        m_Score += score;
        ScoreUpdated?.Invoke(m_Score);
    }
}
