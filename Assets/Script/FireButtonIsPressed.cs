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
    public GameObject blood;
    public bool bloodRequire;
    public ParticleSystem gunBulletFire;
    public int totalBullets;
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
                totalBullets--;
                Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
                {
                    gunBulletFire.Play();
                    Debug.Log(hit.transform.gameObject.name);
                   
                    if (hit.transform.gameObject.CompareTag("Zombie"))
                    {
                        hit.transform.gameObject.GetComponentInParent<ZombiesHealthAndCollision>().HealthDecrease(totalBullets);

                        if (bloodRequire)
                        {
                            var obj = Instantiate(blood, hit.point, hit.transform.rotation);
                            obj.transform.parent = hit.transform;
                        }
                    }
                    fireTimer = timedelta + fireRate;
                }
                else
                {
                    gunBulletFire.Play();
                }
            }
        }
        timedelta += Time.deltaTime;
    }

}
