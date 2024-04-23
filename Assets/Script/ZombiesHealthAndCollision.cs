using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombiesHealthAndCollision : MonoBehaviour
{
    private int totalHealth=100;
    private Animator zombieAnimationController;
    private bool die = false;
    private MissionOne missionOne;
    private void Start()
    {
        missionOne = GameObject.Find("Game Manager").GetComponent<MissionOne>();
        zombieAnimationController = GetComponent<Animator>();
    }
    public void HealthDecrease(int remainingBullets)
    {
        if (!die)
        {
            totalHealth -= 50;
            if (totalHealth <= 0)
            {
                this.transform.GetChild(1).GetComponent<BoxCollider>().isTrigger=true;
                zombieAnimationController.SetTrigger("Die");
                die = true;
                if (missionOne.missionOneIsThis)
                {
                    missionOne.DicreaseEnemyOne();
                    Invoke(nameof(DestroyOnDie), 2);
                }
                else if (missionOne.missionTwoIsThis)
                {
                    missionOne.DicreaseEnemyTwo();
                    Invoke(nameof(DestroyOnDie), 2);
                }
                else if (missionOne.missionThreeIsThis)
                {
                    missionOne.DicreaseEnemyThree(remainingBullets);
                    Invoke(nameof(DestroyOnDie), 2);
                }
               
            }
        }
    }
    private void DestroyOnDie()
    {
        Destroy(this.gameObject);
    }
}
