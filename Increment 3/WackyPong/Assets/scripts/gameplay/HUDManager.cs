using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    //help with scores and hits
    [SerializeField]
    Text scoreText;
    float lScore;
    float rScore;
    const string scorePrefix = " - ";
    
    [SerializeField]
    Text lHitsText;
    float lHts;
    const string lHitPrefix = "P1 Hits: ";
    
    [SerializeField]
    Text rHitsText;
    float rHts;
    const string rHitPrefix = "P2 Hits: ";
    
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = lScore.ToString() + scorePrefix + rScore.ToString();
        lHitsText.text = lHitPrefix + lHts.ToString();
        rHitsText.text = rHitPrefix + rHts.ToString();
    }

    /// <summary>
    ///  Adds hits to corresponding side
    /// </summary>
    public void AddHits(ScreenSide side, float num)
    {
        if (side == ScreenSide.Right)
        {
            rHts += num;
            rHitsText.text = rHitPrefix + rHts.ToString();
        }
        else
        {
            lHts += num;
            lHitsText.text = lHitPrefix + lHts.ToString();
        }
    }

    /// <summary>
    /// Updates game score
    /// </summary>
    public void AddScore(ScreenSide side, float num)
    {
        if (side == ScreenSide.Left)
        {
            lScore += num;
        }
        else
        {
            rScore += num;
        }

        scoreText.text = lScore.ToString() + scorePrefix + rScore.ToString();
    }
}
