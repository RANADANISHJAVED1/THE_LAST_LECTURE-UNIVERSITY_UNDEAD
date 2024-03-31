using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RoomState
{
    open,close,locked,
}
public class RoomDoorDetail : MonoBehaviour
{
    public RoomState roomState;

    // Update is called once per frame
    void Update()
    {
        
    }
}
