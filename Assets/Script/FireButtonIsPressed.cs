using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireButtonIsPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressed = false;
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float fireRate = 1f;
    public float laserDuration = 0.05f;
    public float fireTimer;
    public float timedelta;
    public void OnPointerDown(PointerEventData eventData)
    {
       
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
        isPressed = false;
    }
    private void Update()
    {
        if(isPressed)
        {
            if (timedelta>fireTimer)
            {
                Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
                {
                    Destroy(hit.transform.gameObject);
                    fireTimer = timedelta + fireRate;
                }
            }
        }
        timedelta += Time.deltaTime;
    }

}
