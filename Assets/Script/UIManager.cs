using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameWin;
    public GameObject gameLose;
    public GameObject pausePanal;
    public GameObject levelCompleteText;
    public AudioSource gameWinLoseSoundEffect;
    public AudioClip gameWinSound;
    public AudioClip gameLoseSound;
    public void GameLooseFunction()
    {
        gameLose.SetActive(true);
        gameWinLoseSoundEffect.PlayOneShot(gameLoseSound);
    }
    public void MissionCompleteSoundEffect()
    {
        gameWinLoseSoundEffect.PlayOneShot(gameWinSound);
    }
    public void MissionComplete()
    {
        levelCompleteText.SetActive(true);
    }
    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextMissionScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }public void MainMenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void PauseGame()
    {
        pausePanal.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pausePanal.SetActive(false);
        Time.timeScale = 1;
    }
    
}
