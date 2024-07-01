using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
    public TextMeshProUGUI scoreText;

    private int _scoreNow = 0;

    private void Update() {
        Debug.Log($"Score: {_scoreNow}");
    }

    public void AddScore(int score) {
        _scoreNow += score;
        scoreText.text = _scoreNow.ToString();
    }
}
