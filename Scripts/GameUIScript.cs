using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUIScript : MonoBehaviour
{
    #region Game Dialogs
    [Header("Game-UI Components")]
    public Text m_MyText;
    public GameControlScript gs;
    #endregion
 
    //Updates score and distance while the game is running
    void Update()
    {
        
        if (m_MyText.gameObject.CompareTag("ScoreText"))
        {
            m_MyText.text = "Player Score: "+gs.getScore();
        }
        else if (m_MyText.gameObject.CompareTag("DistanceText"))
        {
            m_MyText.text = "Distance: "+gs.getDistance();
        } 
    }
}
