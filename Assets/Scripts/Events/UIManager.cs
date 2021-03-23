using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    protected GameObject[] pauseObjects;
    protected bool gameIsPaused;    

    // Use this for initialization
    void Start() {
        Time.timeScale = 0;
        gameIsPaused = true;
        //pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        //hidePaused();
    }

    // Update is called once per frame
    void Update() {
        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P)) {
            if (Time.timeScale == 1) {
                Time.timeScale = 0;
                gameIsPaused = true;
                showPaused();
            } else if (Time.timeScale == 0) {
                Debug.Log("high");
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }


    //Reloads the Level
    public void Reload() {
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene("Map_1");
    }

    //controls the pausing of the scene
    public void PauseControl() {
        if (Time.timeScale == 1) {
            Time.timeScale = 0;
            gameIsPaused = true;
            //showPaused();
        } else if (Time.timeScale == 0) {
            Time.timeScale = 1;
            gameIsPaused = false;
            //hidePaused();
        }
    }

    //controls the end turn button
    public void EndTurn() {
        StartCoroutine(EndTurnTimer(3));
    }

    public IEnumerator WaitFrame() {
        yield return new WaitForEndOfFrame();
    }

    public IEnumerator EndTurnTimer(float seconds) {
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(seconds);
        Time.timeScale = 0;
    }

    //shows objects with ShowOnPause tag
    public void showPaused() {
        if (pauseObjects != null) {
            foreach (GameObject g in pauseObjects) {
                g.SetActive(true);
            }
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused() {
        if (pauseObjects != null) {
            foreach (GameObject g in pauseObjects) {
                g.SetActive(false);
            }
        }
    }

    //loads inputted level
    public void LoadLevel(string level) {
        //Application.LoadLevel(level);
    }
}
