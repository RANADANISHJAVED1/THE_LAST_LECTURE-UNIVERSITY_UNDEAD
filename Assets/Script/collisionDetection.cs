using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class collisionDetection : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Zombie"))
        {
            GameObject.Find("Game Manager").GetComponent<UIManager>().gameLose.SetActive(true);
        }
        else if (hit.gameObject.CompareTag("Win"))
        {
            GameObject.Find("Game Manager").GetComponent<UIManager>().gameWin.SetActive(true);
        }
    }
}
