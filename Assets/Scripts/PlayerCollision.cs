using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject player;
    GameManager gameManager; 
    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Obstacle"){
            gameManager.EndGame();
        }
    }


}
