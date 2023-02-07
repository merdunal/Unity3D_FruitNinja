using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject startScreen;

    private float spawnRate = 3.0f;
    private int score;
    public bool isGameActive;


    // Spawns random targets between given time interval
    IEnumerator SpawnTarget()
    {
        // Makes sure that below lines of codes works while the game is on 
        while(isGameActive)
        {
            // Makes the targets wait for the spawn
            yield return new WaitForSeconds(spawnRate);

            // Creates a random index for target which is going to be spawn
            int index = Random.Range(0, targets.Count);

            // Spawns a random target
            Instantiate(targets[index]);

        }
    }

    // Updates the score and writes it to the game screen
    public void UpdateScore(int scoreToAdd)
    {
        // updates the current score
        score += scoreToAdd;

        // writes the score to the game screen
        scoreText.text = "Score: " + score;
    }

    // Activates the game over text and restart button when it is called
    public void GameOver()
    {
        // Activates the game over text
        gameOverText.gameObject.SetActive(true);

        // Activates the restart button
        restartButton.gameObject.SetActive(true);

        // Makes the game is over
        isGameActive = false;
    }

    // Restarts the game
    public void RestartGame()
    {
        // Reloads the play scene 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        // We make sure that score is set to zero when the game is started
        score = 0;

        // changes the spawn rate by dividing the spawn rate to the given difficulty
        spawnRate /= difficulty;

        // We make sure that game is active when the game is started
        isGameActive = true;

        StartCoroutine(SpawnTarget());

        // Sets the score to zero when the game starts
        UpdateScore(0);

        // Activates the start screen
        startScreen.gameObject.SetActive(false);
    }

}
