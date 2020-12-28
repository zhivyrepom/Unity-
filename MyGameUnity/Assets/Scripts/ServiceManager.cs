﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServiceManager : MonoBehaviour
{
    #region Singelton
    public static ServiceManager Instanse;
    private void Awake()
    {
        if (Instanse == null)
            Instanse = this;
        else
            Destroy(gameObject);
    }
    #endregion 
    private void Start()
    {
        Time.timeScale = 1;

        if(SceneManager.GetActiveScene().buildIndex!=0)
        {
            PlayerPrefs.SetInt(GamePrefs.LastPlayedLvl.ToString(), SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt(GamePrefs.LvlPlayed.ToString() + SceneManager.GetActiveScene().buildIndex, 1);
        }
    }
    public void Restart()
    {
        ChangeLvl(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndLevel()
    {
        ChangeLvl(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ChangeLvl(int  lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ResetProgres()
    {
        PlayerPrefs.DeleteAll();
    }
}

public enum Scenes
{
    MainMenu,
    first,
    second,
    third,
}

public enum GamePrefs
{
    LastPlayedLvl,
    LvlPlayed,
}

