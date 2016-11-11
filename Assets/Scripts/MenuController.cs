using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    //PauseMenu
    [SerializeField]
    private GameObject Pause;
    
    // Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //Loads the Main Menu.
    public void MainMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    //Loads Level 1.
    public void Level1()
    {
        Application.LoadLevel("Level1");
    }

    //Loads Level 2.
    public void Level2()
    {

    }

    //Loads Level 3.
    public void Level3()
    {

    }

    //Quits to Desktop
    public void QuitGame()
    {
        Application.Quit();
    }

    //Loads the Credit menu.
    public void Credit()
    {
        Application.LoadLevel("Credits");
    }

    //Loads the Instructions menu.
    public void Tutorial()
    {

    }

    //Loads the Pause menu.
    public void PauseMenu()
    {
            Pause.SetActive(true);
            Time.timeScale = 0;
    }

    //Closes the Pause menu.
    public void PauseClose()
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
    }
}
