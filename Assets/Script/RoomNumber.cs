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
    public bool extremeModifyPlate;
    void Awake()
    {
        if (!lab)
        {
            //SizeOfPlate.transform.localScale = new Vector3(0.02f, 0.4f, 0.7f);
            roomtext.text = "ROOM" + roomNumber;
           // roomtext.transform.localScale = new Vector3(1, 1.5f, 1);
        }
        else if (lab)
        {
            //SizeOfPlate.transform.localScale = new Vector3(0.02f,0.35f,0.9f);
            roomtext.text = labName;
            if (extremeModifyPlate)
            {
                roomtext.fontSize = 1.3f;
            }
            else
            {
                roomtext.fontSize = 1.6f;
                roomtext.transform.localScale = new Vector3(1, 2.5f, 1);
            }
            //SizeOfPlate.transform.localScale = new Vector3(0.02f, 0.9f, 0.9f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
