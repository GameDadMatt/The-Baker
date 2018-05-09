﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour {
    private CutsceneManager _cutsceneManager;

    private List<GameObject> _sceneText = new List<GameObject>();
    private List<float> _textDelay = new List<float>();
    private int _nextText = 0;
    public bool isStartScene;

    private float _initialTextDelay = 1f;
    public float delaytoText2;
    public float delaytoText3;
    public float delaytoText4;
    public float delaytoText5;
    public float delaytoText6;
    public float delaytoText7;
    public float delaytoText8;
    public float delaytoText9;
    public float delaytoText10;

    public void StartCutscene(CutsceneManager man)
    {
        this.gameObject.SetActive(true);
        _cutsceneManager = man;

        _textDelay.Add(_initialTextDelay);
        _textDelay.Add(delaytoText2);
        _textDelay.Add(delaytoText3);
        _textDelay.Add(delaytoText4);
        _textDelay.Add(delaytoText5);
        _textDelay.Add(delaytoText6);
        _textDelay.Add(delaytoText7);
        _textDelay.Add(delaytoText8);
        _textDelay.Add(delaytoText9);
        _textDelay.Add(delaytoText10);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            _sceneText.Add(child.gameObject);
        }

        StartCoroutine(DelayedShowText());
    }

    //Display the next text on demand.
    public void NextText()
    {
        _sceneText[_nextText].SetActive(true);

        _nextText++;
        if (NextTextPresent())
        {
            StartCoroutine(DelayedShowText());
        }
        else
        {
            StartCoroutine(DelayedEndScene());
        }
    }

    //NextTextPresent returns False if there's no more text to read
    public bool NextTextPresent()
    {
        if(_nextText >= _sceneText.Count)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    IEnumerator DelayedShowText()
    {
        yield return new WaitForSeconds(_textDelay[_nextText]);
        NextText();
    }

    IEnumerator DelayedEndScene()
    {
        yield return new WaitForSeconds(_textDelay[_nextText]);
        if (isStartScene)
        {
            //Tell the Cutscene Manager to run the next scene
            this.gameObject.SetActive(false);
            _cutsceneManager.NextStartScene();
        }
        else
        {
            //The cutscene isn't a starting scene and it's finished, so go to gameplay
            _cutsceneManager.GoToGameplay();
        }
    }
}
