using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public void RestartLevel()
   {
      SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
   }
}
