﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour {
    public GameObject menu;
    public GameObject cutscenes;
    public GameObject gameUI;
    public GameObject gameplay;

	// Use this for initialization
	void Start () {
        //Set all scenes but the Menu to be inactive
        menu.SetActive(true);
        cutscenes.SetActive(false);
        gameUI.SetActive(false);
        gameplay.SetActive(false);
    }

    public void StartOpening()
    {
        menu.SetActive(false);
        cutscenes.SetActive(true);
        cutscenes.GetComponent<CutsceneManager>().OpeningCutscenes();
    }

    public void StartGame()
    {
        cutscenes.SetActive(false);
        gameUI.SetActive(true);
        gameplay.SetActive(true);
        gameplay.GetComponent<MainLoop>().StartGame();
    }
}