using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesNumber : MonoBehaviour
{
    public bool twoZombies;
    public bool none;
    public GameObject zombieOne;
    public GameObject zombieTwo;
    public GameObject chairs;
    public RoomDoorDetail roomOne;
    public RoomDoorDetail roomTwo;
    // Start is called before the first frame update
    void Start()
    {
        if (none)
        {
            zombieOne.SetActive(false);
            zombieTwo.SetActive(false);
            chairs.SetActive(true);
        }
        else if (twoZombies)
        {
            zombieOne.SetActive(true);
            zombieTwo.SetActive(true);
            chairs.SetActive(false);
        }
        else
        {
            zombieOne.SetActive(true);
            zombieTwo.SetActive(false);
            chairs.SetActive(false);
        }
        if(roomOne.roomState== RoomState.locked && roomTwo.roomState == RoomState.locked)
        {
            zombieOne.SetActive(false);
            zombieTwo.SetActive(false);
            chairs.SetActive(false);
        }
    }


}
