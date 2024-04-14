using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MissionOne : MonoBehaviour
{
    public bool missionOneIsThis;
    public bool missionTwoIsThis;
    public bool missionThreeIsThis;
    public RoomDoorDetail ComputerLabOne;
    public RoomDoorDetail ComputerLabTwo;
    public int EnemyCount;
    public float timeLeft = 10;
    public bool gameWinStatus = false;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI remainingZombies;
    public TextMeshProUGUI remainingBulletsText;
    void Start()
    {
        if (missionOneIsThis)
        {
            EnemyCount = 2;
            ComputerLabOne.roomState = RoomState.locked;
            ComputerLabTwo.roomState = RoomState.locked;
        }
        else if (missionTwoIsThis)
        {
            EnemyCount = 10;
            timeLeft = 300;
        }
        else if (missionThreeIsThis)
        {
            EnemyCount = 10;
            timeLeft = 180;
            remainingBulletsText.text = "50";
        }
        if (!missionOneIsThis)
        {
            remainingZombies.text = EnemyCount.ToString();
        }
    }
    private void Update()
    {
        if (!missionOneIsThis)
        {
            if (timeLeft>0)
            {
                if (!gameWinStatus)
                {
                    timeLeft -= Time.deltaTime;
                    timerText.text = ((int)(timeLeft / 60)).ToString() + " : " + ((int)(timeLeft % 60)).ToString();
                }
            }
            else
            {
                this.gameObject.GetComponent<UIManager>().gameLose.SetActive(true);
            }
        }
    }
    public void DicreaseEnemyOne()
    {
        EnemyCount--;
        if (EnemyCount <= 0)
        {

            ComputerLabOne.roomState = RoomState.close;
            ComputerLabTwo.roomState = RoomState.close;
        }
        remainingZombies.text = EnemyCount.ToString();
    }
    public void DicreaseEnemyTwo()
    {
        EnemyCount--;
        if (EnemyCount <= 0)
        {
            this.gameObject.GetComponent<UIManager>().gameWin.SetActive(true);
            gameWinStatus = true;
        }
        remainingZombies.text = EnemyCount.ToString();
    }
    public void DicreaseEnemyThree(int remainingBullets)
    {
        EnemyCount--;
        if (EnemyCount <= 0 && remainingBullets > 0)
        {
            this.gameObject.GetComponent<UIManager>().gameWin.SetActive(true);
            gameWinStatus = true;
        }
        else if (remainingBullets <= 0)
        {
            this.gameObject.GetComponent<UIManager>().gameLose.SetActive(true);
            gameWinStatus = true;
        }
        remainingZombies.text = EnemyCount.ToString();
        remainingBulletsText.text = remainingBullets.ToString();
    }
}
