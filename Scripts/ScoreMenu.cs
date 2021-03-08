using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreMenu : MonoBehaviour
{ 
    //Regular score
    public Text ScoreNum;
    public Text DistanceNum;

    //The current records
    private int HighScore;
    private int TopDistance;

    
    // Start is called before the first frame update
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
        TopDistance = PlayerPrefs.GetInt("TopDistance");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreNum.gameObject.CompareTag("HighScore"))
        {
            ScoreNum.text = ""+HighScore;
        }

        if (DistanceNum.gameObject.CompareTag("TopDistance"))
        {
            DistanceNum.text = "" + TopDistance;
        }
    }
    public void reset()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("TopDistance", 0);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
