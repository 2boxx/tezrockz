using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnityEvent OnLoseGame;
    public UnityEvent OnFinishedGame;

    public bool debug_CannotLose;

    public void FinishedGame()
    {
        OnFinishedGame.Invoke();
    }
    
    public void RestartLevel()
    {
        if(debug_CannotLose) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


