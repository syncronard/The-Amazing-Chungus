using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseUIScript : MonoBehaviour
{
   
    public Text m_MyText;

    //Regular score
    public int Score;
    public int Distance;


    //Variables to check if a new record has been set
    public int NewScore;
    public int NewDistance;


    //The current records
    public int HighScore;
    public int TopDistance;

    // Start is called before the first frame update
    void Start()
    { 
        HighScore = PlayerPrefs.GetInt("HighScore");
        TopDistance = PlayerPrefs.GetInt("TopDistance");


        Score = PlayerPrefs.GetInt("Score");
        Distance = PlayerPrefs.GetInt("Distance");


        NewScore = PlayerPrefs.GetInt("NewScore");
        NewDistance = PlayerPrefs.GetInt("NewDistance");
    }

    // Update is called once per frame
    void Update()
    {
        if (m_MyText.gameObject.CompareTag("HighScore"))
        {
            m_MyText.text = "[High Score]: " + HighScore;
        }
        else if (m_MyText.gameObject.CompareTag("TopDistance"))
        {
            m_MyText.text = "[Top Distance]: " + TopDistance;
        }

        else if (m_MyText.gameObject.CompareTag("ScoreText"))
        {
            m_MyText.text = "Score: "+ Score;
        }
        else if (m_MyText.gameObject.CompareTag("DistanceText"))
        {
            m_MyText.text = "Distance: "+ Distance;
        } 
      
        else if (m_MyText.gameObject.CompareTag("RecordScore") && NewScore == 1)
        {
            m_MyText.text = "New Score!";
            PlayerPrefs.SetInt("NewScore", 0);
        }
        else if (m_MyText.gameObject.CompareTag("RecordDistance") && NewDistance == 1)
        {
            m_MyText.text = "New Distance!";
            PlayerPrefs.SetInt("NewDistance", 0);
        }
        PlayerPrefs.SetInt("NewScore", 0);
        PlayerPrefs.SetInt("NewDistance", 0);
    }
}
