using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour
{
    #region Game Dialogs
    [Header("Game Components")]
    public bool isRunning;
    public int playerScore;
    public GameObject playerObj;
    private Player player;
    private PlayerController pc;
    public int timePerDistanceUnit;
    public int pointsPerDistanceUnit;
    public int MAX_SPEED;
    private float distanceTimer;
    public int distanceTraveled;
    public string SceneName;
    public string SceneOne;
    public string SceneTwo;
    public GameObject LifeImage1;
    public GameObject LifeImage2;
    public GameObject LifeImage3;
    #endregion

    void Start()
    {
        player = playerObj.GetComponent<Player>();
        pc = playerObj.GetComponent<PlayerController>();
        // Game status
        isRunning = true;
        // Base player speed
        playerScore = 0;
        // Max player speed
        MAX_SPEED = 15;
    }

    void Update()
    {
        //Check end game status

        //Add to distance chungy has moved
        distanceTimer += Time.deltaTime;
        if(distanceTimer > timePerDistanceUnit)
        {
            distanceTraveled += 1;
            distanceTimer = 0;
        }
        //Increases speed of chungy over time
        if(distanceTraveled % 10 == 0)
        {
            if(pc.moveSpeed < MAX_SPEED)
            {
                pc.moveSpeed += 0.017f;
            }
            
        }
        //Check status of lives
        checkLife();
    }
    //Add onto score
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
    }

    public int getScore()
    {
        return playerScore;
    }

    public int getDistance()
    {
        return distanceTraveled;
    }

    // Decreases Life-UI in accordance with player life
    void checkLife()
    {
        if (player.getHealth() == 0)
        {
            LifeImage1.gameObject.SetActive(false);
        }
        if(player.getHealth() == 1)
        {
            LifeImage2.gameObject.SetActive(false);
        }
        if(player.getHealth() == 2)
        {
            LifeImage2.gameObject.SetActive(true);
            LifeImage3.gameObject.SetActive(false);
        }
        if(player.getHealth() == 3)
        {
            LifeImage1.gameObject.SetActive(true);
            LifeImage2.gameObject.SetActive(true);
            LifeImage3.gameObject.SetActive(true);
        }
    }

    //Set up for when the game has ended
    public void endGame()
    {
        isRunning = false;
        calculateScore();
        print("Total score: " + playerScore);
        SceneManager.LoadScene(SceneName); 
    }

    //Calculate score for the end of the game
    private void calculateScore()
    {
        if(pointsPerDistanceUnit > 0)
        {
            playerScore += (distanceTraveled * pointsPerDistanceUnit);
        }
    }
    
    //For button the return to the main menu when pressed
    public void StartScreen()    
    {        
        SceneManager.LoadScene(SceneOne); 
        Time.timeScale = 1;
    }

    //For the retry button in the pause screen
    public void Retry()    
    {        
        SceneManager.LoadScene(SceneTwo); 
        Time.timeScale = 1;
    }

    //Exits the application.
    public void Exit()    
    {        
        print("Okay exiting...");
        Application.Quit();
    }
    
}
