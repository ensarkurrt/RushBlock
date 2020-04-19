using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scoreText;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (player.position.z/2).ToString("00");
    }
}
