using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public UnityEvent OnLoseGame;
    public UnityEvent OnFinishedGame;

    public bool debug_CannotLose;

    public RockFreezer rockFreezer; //Variable set by rockFreezer on start
    
    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    public void FinishedGame()
    {
        OnFinishedGame.Invoke();
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


