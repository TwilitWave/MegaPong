﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void NewGameBttn(string gameLevel)
    {
        SceneManager.LoadScene(gameLevel);
    }

    public void MainMenuBttn(string mainMenu)
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void ExitBttn()
    {
        Application.Quit();
    }

    public void SetActive(GameObject item)
    {
        item.SetActive(true);
    }
    public void SetInactive(GameObject item)
    {
        item.SetActive(false);
    }
}
