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
            ComputerLabOne.roomState = RoomState.locked;
            ComputerLabTwo.roomState = RoomState.locked;
        }
        else if (missionThreeIsThis)
        {
            EnemyCount = 10;
            timeLeft = 180;
            remainingBulletsText.text = "REMAINING BULLETS : 50";
            ComputerLabOne.roomState = RoomState.locked;
            ComputerLabTwo.roomState = RoomState.locked;
        }
        if (!missionOneIsThis)
        {
            remainingZombies.text = "REMAINING KILLS : "+EnemyCount.ToString();
        }
    }
    private void Update()
    {
        if (!missionOneIsThis)
        {
            if (timeLeft>0)
            {
                timeLeft -= Time.deltaTime;
                timerText.text = "TIME LEFT : " + ((int)(timeLeft / 60)).ToString() + " : " + ((int)(timeLeft % 60)).ToString();
            }
            else
            {
                this.gameObject.GetComponent<UIManager>().GameLooseFunction();
            }
        }
    }
    public void DicreaseEnemyOne()
    {
        if (!gameWinStatus)
        {
            EnemyCount--;
            if (EnemyCount <= 0)
            {

                ComputerLabOne.roomState = RoomState.close;
                ComputerLabTwo.roomState = RoomState.close;
                this.gameObject.GetComponent<UIManager>().MissionComplete();
                gameWinStatus = true;
            }
        }
        //remainingZombies.text = EnemyCount.ToString();
    }
    public void DicreaseEnemyTwo()
    {
        if (!gameWinStatus)
        {
            EnemyCount--;
            if (EnemyCount <= 0)
            {

                ComputerLabOne.roomState = RoomState.close;
                ComputerLabTwo.roomState = RoomState.close;
                this.gameObject.GetComponent<UIManager>().MissionComplete();
                gameWinStatus = true;
                remainingZombies.transform.parent.gameObject.SetActive(false);
            }
        }
        /* if (EnemyCount <= 0)
         {
             this.gameObject.GetComponent<UIManager>().gameWin.SetActive(true);
             gameWinStatus = true;
         }*/
        remainingZombies.text = "REMAINING KILLS : " + EnemyCount.ToString();
    }
    public void DicreaseEnemyThree(int remainingBullets)
    {
        if(!gameWinStatus){
            EnemyCount--;
            if (EnemyCount <= 0 && remainingBullets > 0)
            {
                /*this.gameObject.GetComponent<UIManager>().gameWin.SetActive(true);
                gameWinStatus = true;*/
                ComputerLabOne.roomState = RoomState.close;
                ComputerLabTwo.roomState = RoomState.close;
                this.gameObject.GetComponent<UIManager>().MissionComplete();
                gameWinStatus = true;
                remainingBulletsText.transform.parent.gameObject.SetActive(false);
                remainingZombies.transform.parent.gameObject.SetActive(false);
            }
            else if (remainingBullets <= 0)
            {
                this.gameObject.GetComponent<UIManager>().GameLooseFunction();

            }
            remainingZombies.text = "REMAINING KILLS : " + EnemyCount.ToString();
            remainingBulletsText.text = "REMAINING BULLETS : " + remainingBullets.ToString();
        } }
}
