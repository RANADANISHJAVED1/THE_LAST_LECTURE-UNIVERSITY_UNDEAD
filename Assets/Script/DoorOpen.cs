using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject doorOpenDialogue;
    public GameObject doorCloseDialogue;
    public GameObject doorLockedDialogue;
    public float doorDistance;
    private Animator doorAnimator;
    private bool closeDialogue = false;
    private RoomDoorDetail roomDoorDetail;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, doorDistance))
        {
            if (hit.collider.gameObject.CompareTag("Door"))
            {
                if (hit.collider.gameObject.GetComponent<RoomDoorDetail>().roomState == RoomState.close && !closeDialogue)
                {
                    roomDoorDetail = hit.collider.gameObject.GetComponent<RoomDoorDetail>();
                    doorAnimator = hit.collider.gameObject.transform.parent.transform.parent.GetComponent<Animator>();
                    doorOpenDialogue.SetActive(true);
                }
                else if(hit.collider.gameObject.GetComponent<RoomDoorDetail>().roomState == RoomState.open && !closeDialogue)
                {
                    roomDoorDetail = hit.collider.gameObject.GetComponent<RoomDoorDetail>();
                    doorAnimator = hit.collider.gameObject.transform.parent.transform.parent.GetComponent<Animator>();
                    doorCloseDialogue.SetActive(true);
                }
                else if(hit.collider.gameObject.GetComponent<RoomDoorDetail>().roomState == RoomState.locked && !closeDialogue)
                {
                    doorLockedDialogue.SetActive(true) ;
                }
            }
        }
        else if(doorCloseDialogue.activeSelf || doorOpenDialogue.activeSelf || doorLockedDialogue.activeSelf|| closeDialogue)
        {
            closeDialogue = false;
            doorOpenDialogue.SetActive(false);
            doorCloseDialogue.SetActive(false);
            doorLockedDialogue.SetActive(false);
            roomDoorDetail = null;
        }
    }
    public void OpenFoorFunction()
    {
        if (doorAnimator)
        {
            doorAnimator.SetTrigger("Open");
            if (roomDoorDetail)
            {
                roomDoorDetail.roomState = RoomState.open;
                CloseBtnClicked();
                Invoke(nameof(CloseDialogueOpen), 0.5f);
            }
        }
    }
    public void CloseDoorFunction()
    {
        if (doorAnimator)
        {
            doorAnimator.SetTrigger("Close");
            if (roomDoorDetail)
            {
                roomDoorDetail.roomState = RoomState.close;
                CloseBtnClicked();
                Invoke(nameof(CloseDialogueOpen), 0.5f);
            }
        }
    }
    public void CloseBtnClicked()
    {
        closeDialogue = true;
        doorOpenDialogue.SetActive(false);
        doorCloseDialogue.SetActive(false);
        doorLockedDialogue.SetActive(false);
        roomDoorDetail = null;
    }
    void CloseDialogueOpen()
    {
        closeDialogue = false;
    }
}
