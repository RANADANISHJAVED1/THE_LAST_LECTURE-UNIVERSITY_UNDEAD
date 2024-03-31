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
