using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBestScore : MonoBehaviour
{
    public static SetBestScore Instance;

    public Text bestScoreText;

    void Awake()
    {
        Instance = this;
        bestScoreText.text = "Best Score: " + SaveBestScore.bestScore.ToString();
    }
}
