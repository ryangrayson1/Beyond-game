using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updates : MonoBehaviour
{
    public GameObject scorePanel;
    public static bool justDied = false;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + Death.score;
    }

    // Update is called once per frame
    void Update()
    {
        if (justDied){
            scorePanel.SetActive(true);
        }

    }

    public void scoreToMenu(){
        scorePanel.SetActive(false);
        justDied = false;
    }
}
