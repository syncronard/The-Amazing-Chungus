using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartScreenCtrl : MonoBehaviour
{
    #region Menu Dialogs
    [Header("Menu Components")]
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject HelpMenu;
    [SerializeField] private GameObject ScoreMenu;
    [SerializeField] private GameObject CharacterMenu;
    [SerializeField] public string SceneName;
    [SerializeField] public string SceneName2;
    #endregion


   void Update()
   {
        // Input to return to home menu from sub-menu
        if(Input.GetKey(KeyCode.Escape) && MainMenu.gameObject.activeInHierarchy == false)
        {
            HelpMenu.SetActive(false);
            ScoreMenu.SetActive(false);
            MainMenu.SetActive(true);
        }
   }
    // Changes the scene to the inputed name
    public void ChangeToScene()    
    {        
        SceneManager.LoadScene(SceneName); 
    }

    // Buttons actions for the homescreen
    public void MouseClick(string buttonType)
    {
        // Exit Application
        if (buttonType == "Exit")
        {
            print("Okay exiting...");
            Application.Quit();
        }

        // Brnig up a help menu
        if (buttonType == "Options")
        {
            if (HelpMenu.gameObject.activeInHierarchy == false)
            {
                HelpMenu.SetActive(true);
                MainMenu.SetActive(false);
            }
        }

        // Bring up the score menu
        if (buttonType == "Score")
        {
            if (ScoreMenu.gameObject.activeInHierarchy == false)
            {
                ScoreMenu.SetActive(true);
                MainMenu.SetActive(false);
            }
        }

        // Escape button for the sub-menus
        // Works like if the escape button on the keyboard was pressed
        if (buttonType == "Back")
        {
            if (HelpMenu.gameObject.activeInHierarchy == true)
            {
                HelpMenu.SetActive(false);
                MainMenu.SetActive(true);
            }
            else if (ScoreMenu.gameObject.activeInHierarchy == true)
            {
                
                ScoreMenu.SetActive(false);
                MainMenu.SetActive(true);
            }
        }
    }
}
