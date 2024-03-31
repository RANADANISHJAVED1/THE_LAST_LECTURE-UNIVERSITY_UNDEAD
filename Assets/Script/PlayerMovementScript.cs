using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]private Joystick joystick;
    public float speed = 2.0f;
    private CharacterController characterController;
    void Start()
    {
        characterController = this.gameObject.GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;
        Vector3 movementDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        Vector3 rotationAngles = transform.rotation.eulerAngles;
        movementDirection = Quaternion.Euler(0, rotationAngles.y, 0) * movementDirection;
        characterController.Move(movementDirection * speed * Time.deltaTime);
        Vector3 gravityForce = Vector3.down * Physics.gravity.magnitude;
        characterController.Move(gravityForce * Time.deltaTime);
        //Vector3 movementDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        //movementDirection.Normalize();
        //characterController.Move(Vector3.right * horizontalInput * speed * Time.deltaTime);
        //characterController.Move(Vector3.forward * verticalInput * speed * Time.deltaTime);
        //this.transform.Translate();
        //this.transform.Translate();
    }
}
