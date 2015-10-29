using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {

    public GameObject player;
    public GameObject pauseMenu;
    public GameObject buttonRetry;

    private float reloadDelay = 1.0f;

	
	void Update () {
        if (Input.GetKeyUp(KeyCode.P))
            GamePause();

        if (player == null)
            Invoke("PauseMenu", reloadDelay);
	}


    public void GamePause()
    {        
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else 
            Time.timeScale = 1;
    }

    private void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Button retry = buttonRetry.GetComponent<Button>();
        retry.onClick.AddListener(() => retryLevel());
    }


    private void retryLevel() {
        Application.LoadLevel(Application.loadedLevel);
    }
}
