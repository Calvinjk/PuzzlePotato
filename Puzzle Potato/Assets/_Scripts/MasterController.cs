﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;

namespace com.aaronandco.puzzlepotato {
    public class MasterController : MonoBehaviour{
        public List<GameObject> puzzleOptions;

        public bool ____________________________;  // Separation between public and "private" variables in the inspector

        Timer timerScript;
        GameManager gameManagerScript;

        void Awake() {
            timerScript = (Timer)GameObject.FindGameObjectWithTag("Timer").GetComponent("Timer");
            gameManagerScript = (GameManager)GameObject.Find("GameManager").GetComponent("GameManager");

            timerScript.SetTimer(gameManagerScript.maxTime);
            timerScript.StartTimer();
            StartNewGame();
        }

        // TODO -- Called after a game is completed.  Must cleanup and start a new puzzle.  
        // Cleanup idea: re-load scene and give gameManager current time?
        public void CurrentGameCompleted() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // TODO
        public void StartNewGame() {
            // Decide on what puzzle and start it
            GameObject curPuzzle = Instantiate(puzzleOptions[Random.Range(0, puzzleOptions.Count - 1)]);
            Puzzle curPuzzleScript = (Puzzle)curPuzzle.GetComponent("Puzzle");
            Debug.Log("Attempting to start game: " + curPuzzle.name);
            curPuzzleScript.StartGame();
        }

        // This gets called by the timer when it hits zero
        public void TimeOut() {

        }

        public void Quit() {
            gameManagerScript.players.Clear();
            SceneManager.LoadScene(0);
        }
    }
}