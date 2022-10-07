using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        int selectedLevel = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        if (selectedLevel == 1)
        {
            SceneManager.LoadScene("LevelOne");
        } else if (selectedLevel == 2)
        {
            SceneManager.LoadScene("LevelTwo");
        }

    }
}
