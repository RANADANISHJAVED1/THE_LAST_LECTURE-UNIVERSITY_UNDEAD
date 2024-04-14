using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // Reference to the touch object
    public float speed = 5.0f;
    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;
    public Transform camera;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }

            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;
                if (touchStartPosition.x > 1200)
                {
                    if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        
                        this.transform.Rotate(Vector3.up * speed * 2 * Time.fixedDeltaTime * x);
                    }

                    else
                    {
                        camera.transform.Rotate(Vector3.right * speed * -y * 2 * Time.fixedDeltaTime);
                    }
                }
            }
        }
    }
}

/*using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float speed = 5.0f;
    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;
    public Transform camera;

    // Stores the target rotation for smooth interpolation
    private Quaternion targetRotation;
    private Quaternion startRotation;

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
                startRotation = transform.rotation; // Store current rotation
            }
            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;

                if (touchStartPosition.x > 1200)
                {
                    if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        // Calculate target rotation based on swipe direction (modify as needed)
                        targetRotation = Quaternion.Euler(0f, x * speed, 0f) * startRotation;
                    }
                    else
                    {
                        targetRotation = Quaternion.Euler(y * -speed, 0f, 0f) * startRotation;
                    }
                }
            }
        }

        // Smoothly rotate towards target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.fixedDeltaTime);
        camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, targetRotation, speed * Time.fixedDeltaTime);
    }
}

*/