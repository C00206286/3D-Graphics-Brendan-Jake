using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    
    

    public GameObject cube;

    private PlayerController playerScript;
    // public GUIText scoreText;
    // public GUIText restartText;
    // public GUIText gameOverText;
    private bool colliding;

    private bool gameOver;
    private bool restart;
    private int score;

    void Start()
    {
        playerScript = cube.GetComponent<PlayerController>();
        score = 0;
        UpdateScore();

        gameOver = false;
        restart = false;
      //  restartText.text = "";
      //  gameOverText.text = "";
    }

    void Update()
    {
        colliding = playerScript.colliding;

        

        if (restart)
           {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
           }
        if (gameOver)
        {
           // restartText.text = "Press 'R' to restart";
            restart = true;
        }
    }


    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
      //  scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
     //   gameOverText.text = "GAME OVER!";
        gameOver = true;
    }
}
