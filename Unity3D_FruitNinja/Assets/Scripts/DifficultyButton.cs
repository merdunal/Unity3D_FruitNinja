using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    public int difficulty;


    // Start is called before the first frame update
    void Start()
    {  
        button = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Listens that which button is clicked on
        button.onClick.AddListener(SetDifficulty);    
    }

    // Sets the difficulty when it is called
    void SetDifficulty()
    {
        // Calls the StartGame method from the GameManager script with the variable of selected difficulty
        gameManager.StartGame(difficulty);
    }
}
