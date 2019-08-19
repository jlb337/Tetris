using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOver;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "你的分数是："+ TetrisGrid.score.ToString();
        //TetrisGrid.score = 0;
    }


    public void GameOver()
    {
        gameOver.SetActive(true);
    }

}
