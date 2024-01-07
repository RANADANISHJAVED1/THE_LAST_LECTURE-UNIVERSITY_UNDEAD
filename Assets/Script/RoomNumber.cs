using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomNumber : MonoBehaviour
{
    public TextMeshPro roomtext;
    public int roomNumber;
    public bool lab;
    public GameObject SizeOfPlate;
    public string labName;
    void Start()
    {
        if (!lab)
        {
            roomtext.text = "ROOM" + roomNumber;
        }
        else if (lab)
        {
            SizeOfPlate.transform.localScale = new Vector3(0.01f,0.35f,1f);
            roomtext.text = labName;
            roomtext.fontSize = 1.6f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
