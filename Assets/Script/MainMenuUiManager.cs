using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUiManager : MonoBehaviour
{
    public void ExitBtnClicked()
    {
        Application.Quit();
    }
    public void MissionBtnClicked(int missionNumber)
    {
        if(missionNumber == 1)
        {
            SceneManager.LoadScene(missionNumber);
        }
        else if(missionNumber == 2)
        {
            SceneManager.LoadScene(missionNumber);
        }
        else if (missionNumber == 3)
        {
            SceneManager.LoadScene(missionNumber);
        }
    }
}
