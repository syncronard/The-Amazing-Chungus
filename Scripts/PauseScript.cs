using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenu;
    private bool pausedGame = false;
    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausedGame == false)
            {
                PauseGame();
                pausedGame = true;
            }
            else
            {
                ResumeGame();
                pausedGame = false;
            }
        }
    }

    void PauseGame()
    {
    
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
