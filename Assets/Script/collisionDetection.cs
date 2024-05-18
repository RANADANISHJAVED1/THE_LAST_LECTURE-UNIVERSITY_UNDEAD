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
            GameObject.Find("Game Manager").GetComponent<UIManager>().GameLooseFunction();
            this.gameObject.GetComponent<CharacterController>().enabled = false;

        }
        else if (hit.gameObject.CompareTag("Win"))
        {
            this.gameObject.GetComponent<CharacterController>().enabled = false;
            GameObject.Find("Game Manager").GetComponent<UIManager>().gameWin.SetActive(true);
            GameObject.Find("Game Manager").GetComponent<UIManager>().MissionCompleteSoundEffect();
        }
    }
}
