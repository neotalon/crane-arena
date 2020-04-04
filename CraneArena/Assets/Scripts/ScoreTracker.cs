﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// General score tracker class.
/// Works together with ScoreUi when the score is changed
/// </summary>
public class ScoreTracker : MonoBehaviourSingleton<ScoreTracker>
{
    [SerializeField]
    private int m_player1Score, m_player2Score;

    // Start is called before the first frame update
    void Start()
    {
        m_player1Score = 0;
        m_player2Score = 0;
    }

    /// <summary>
    /// Increase the desired player score by one
    /// Could already be refactored into two individual playerScore classes with fields
    /// </summary>
    /// <param name="playerId"></param>
    public static void IncreaseScoreByOne(int playerId)
    {
        if (playerId == 0)
        {
            Instance.m_player1Score++;
            ScoreUi.UpdateScore(playerId, Instance.m_player1Score);
        }
        else if (playerId == 1)
        {
            Instance.m_player2Score++;
            ScoreUi.UpdateScore(playerId, Instance.m_player2Score);

        }
        else
        {
            Debug.LogError("ScoreTracker: Bad player ID passed");
        }
    }

    /// <summary>
    /// Increase the score of the other player
    /// </summary>
    /// <param name="sourcePlayerId"></param>
    public static void IncreaseOtherPlayer(int sourcePlayerId)
    {
        if (sourcePlayerId == 0)
        {
            IncreaseScoreByOne(1);
        }
        else if (sourcePlayerId == 1)
        {
            IncreaseScoreByOne(0);
        }
        else
        {
            Debug.LogError("ScoreTracker: Bad player ID passed");
        }
    }
}
