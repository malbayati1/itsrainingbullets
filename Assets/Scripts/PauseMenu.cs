using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool isPaused = false;
	public GameObject pauseMenu;
	public GameObject player;

	void Start(){
		pauseMenu.SetActive(false);
	}

    void Update() {
    	if (Input.GetKeyDown(KeyCode.P)){
    		if (isPaused) {
    			pauseMenu.SetActive(false);
        		Time.timeScale = 1f;
        		isPaused = false;
        	}
        	else{	
        		pauseMenu.SetActive(true);
       			Time.timeScale = 0f;
       			isPaused = true;
        	}
    	}
    }

    public void Resume() {
    	pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenu() {
    	SceneManager.LoadScene("MainMenu");
    	Resume();
    }
}
