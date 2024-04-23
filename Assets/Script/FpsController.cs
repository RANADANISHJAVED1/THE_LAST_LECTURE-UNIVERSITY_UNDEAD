using UnityEngine;
using UnityEngine.EventSystems;

public class FpsController : MonoBehaviour
{
    [SerializeField] private float sensitivity = 5.0f; // Adjust rotation sensitivity
    [SerializeField] private Transform characterBody; // Character transform (parent)
    [SerializeField] private Transform cameraTransform; // Camera transform (child)
    [SerializeField] private bool allowXRotation = true; // Checkbox for X-axis rotation
    [SerializeField] private bool allowYRotation = true; // Checkbox for Y-axis rotation
    private Vector2 fingerStartPos;
    private Vector2 fingerStartPosSecond;
    void Start()
    {
        if (cameraTransform == null)
        {
            Debug.LogError("Please assign the camera transform in the inspector!");
            enabled = false; // Disable script if camera transform is missing
        }
    }
    private void Update()
    {
        if (Input.touchCount==1) // Handle touch input
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                fingerStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (touch.position.x > 1200 && fingerStartPos.x > 1200)
                {
                    Vector2 fingerDelta = touch.position - fingerStartPos;

                    if (allowXRotation)
                    {
                        characterBody.RotateAround(characterBody.position, Vector3.up, fingerDelta.x * sensitivity);
                    }

                    if (allowYRotation)
                    {
                        cameraTransform.RotateAround(characterBody.position, Vector3.right, -fingerDelta.y * sensitivity); // Invert Y for natural camera rotation
                    }

                    fingerStartPos = touch.position;
                }
            }
        }
        /*else if (Input.touchCount == 2) // Handle touch input
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                fingerStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved && fingerStartPos.x > 1200)
            {
                Vector2 fingerDelta = touch.position - fingerStartPos;
                if (allowXRotation)
                {
                    characterBody.RotateAround(characterBody.position, Vector3.up, fingerDelta.x * sensitivity);
                }

                if (allowYRotation)
                {
                    cameraTransform.RotateAround(characterBody.position, Vector3.right, -fingerDelta.y * sensitivity); // Invert Y for natural camera rotation
                }

                fingerStartPos = touch.position;
            }
            Touch touchSecond = Input.GetTouch(1);

            if (touchSecond.phase == TouchPhase.Began)
            {
                fingerStartPosSecond = touchSecond.position;
            }
            else if (touchSecond.phase == TouchPhase.Moved && fingerStartPosSecond.x > 1200)
            {
                Vector2 fingerDelta = touchSecond.position - fingerStartPosSecond;

                if (allowXRotation)
                {
                    characterBody.RotateAround(characterBody.position, Vector3.up, fingerDelta.x * sensitivity);
                }

                if (allowYRotation)
                {
                    cameraTransform.RotateAround(characterBody.position, Vector3.right, -fingerDelta.y * sensitivity); // Invert Y for natural camera rotation
                }

                fingerStartPosSecond = touch.position;
            }
        }*/
    }
}
