using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieCollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Game Manager").GetComponent<UIManager>().GameLooseFunction();
            
            collision.gameObject.GetComponent<CharacterController>().enabled = false;
        }
    }
}
