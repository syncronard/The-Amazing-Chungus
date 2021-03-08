using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoScript : MonoBehaviour
{
    //The current records
    private int HighScore;
    private int TopDistance;


    //Regular score
    private int Score;
    private int Distance;


    //Variables to check if a new record has been set
    private int NewScore;
    private int NewDistance;


    private Scene currentScene;
    GameControlScript gs;
  
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        gs = GameObject.Find("GameControl").GetComponent<GameControlScript>();
        load();
      
    }
  
    // Update is called once per frame
    void Update()
    {
        if(currentScene.name == "SampleScene")
        {
            if (gs.isRunning == false)
            {
                //Gey current score from run
                Score = gs.getScore();
                Distance = gs.getDistance();
                
                //Replace record if it was beaten
                if(Score > HighScore)
                {
                    HighScore = gs.getScore();
                    PlayerPrefs.SetInt("NewScore", 1);
                }
                else if(Score < HighScore)
                {
                    PlayerPrefs.SetInt("NewScore", 0);
                }

                if(Distance > TopDistance)
                {
                    TopDistance = gs.getDistance();
                    PlayerPrefs.SetInt("NewDistance", 1);
                }  
                else if(Distance < TopDistance)
                {
                    PlayerPrefs.SetInt("NewDistance", 0);
                }
            }
            save();
        }
        
    }

    public void save()
    {
        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.SetInt("Distance", Distance);
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.SetInt("TopDistance", TopDistance);
        PlayerPrefs.Save();
    }
    public void load()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
        TopDistance = PlayerPrefs.GetInt("TopDistance");
    }
}
