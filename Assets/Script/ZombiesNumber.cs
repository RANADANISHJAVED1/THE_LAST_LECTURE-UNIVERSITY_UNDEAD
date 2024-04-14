using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesNumber : MonoBehaviour
{
    public bool twoZombies;
    public bool none;
    public GameObject zombieOne;
    public GameObject zombieTwo;
    // Start is called before the first frame update
    void Start()
    {
        if (none)
        {
            zombieOne.SetActive(false);
            zombieTwo.SetActive(false);
        }
        else if (twoZombies)
        {
            zombieOne.SetActive(true);
            zombieTwo.SetActive(true);
        }
        else
        {
            zombieOne.SetActive(true);
            zombieTwo.SetActive(false);
        }
    }

   
}
