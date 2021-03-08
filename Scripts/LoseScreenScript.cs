using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LoseScreenScript : MonoBehaviour
{
   
    public string SceneOne;
    public string SceneTwo;
   
  
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartScreen()    
    {        
        SceneManager.LoadScene(SceneOne); 

    }

    public void Retry()    
    {        
        SceneManager.LoadScene(SceneTwo); 

    }

    public void Exit()    
    {        
        print("Okay exiting...");
        Application.Quit();
    }
   
}
