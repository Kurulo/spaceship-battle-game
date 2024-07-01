using System;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject scoreBoarContainer;
    public int scorePerHit;
    public int healPoint;

    private ScoreBoard _scoreBoard;

    private void Start() {
        if (scoreBoarContainer.GetComponent<ScoreBoard>()) {
            _scoreBoard = scoreBoarContainer.GetComponent<ScoreBoard>();
        }
        AddRigidbody();
    }
    
    private void OnParticleCollision(GameObject other) {
        healPoint--;
        if (healPoint == 0) {
            _scoreBoard.AddScore(scorePerHit);
            Destroy(this.gameObject);
        }
    }
    
    private void AddRigidbody() {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
}
