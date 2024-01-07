using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]private Joystick joystick;
    public float speed = 5.0f;
    void Start()
    {
    }
    void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;
        Vector3 movementDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        movementDirection.Normalize();
        this.transform.Translate(Vector3.right*horizontalInput*speed*Time.deltaTime);
        this.transform.Translate(Vector3.forward*verticalInput*speed*Time.deltaTime);
    }
}
