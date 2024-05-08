using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text score;
    public float scoreCount;

    public GameObject playerState;

    // Update is called once per frame
    void Update()
    {
        scoreCount = playerState.GetComponent<PlayerStatus>().score;
        score.text = "Score: " + scoreCount;
    }
}
