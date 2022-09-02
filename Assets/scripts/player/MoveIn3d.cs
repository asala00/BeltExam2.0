using UnityEngine;
using UnityEngine.Serialization;

public class MoveIn3d : MonoBehaviour
{
    public CharacterController controller; //public to plug it in and use it for the last .move command
    public float playerSpeed;
    [SerializeField] Transform movementCam; //ref for our cam so we can use it to change where our GO's forward is (the way the camera is facing)
    
    //for jump
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public float jumpHeight = 2.0f;
    public float gravityValue = -9.81f;

    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal") * playerSpeed;
        float vInput = Input.GetAxisRaw("Vertical") * playerSpeed;
        Vector3 direction = new Vector3(hInput, 0f, vInput).normalized;
        
        //for jump
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y <= 0)
        {
            playerVelocity.y = 0f;
        }
        
        if (direction != Vector3.zero)
        {
            gameObject.transform.forward = direction;
        }
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        //telling the player to move according to the input
        //for local direction movement (from the old script)
        if (direction.magnitude >= 0.1f)
        {
            //rotates the players orientation based on the cameras rotation
            float targetAngel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg+ movementCam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngel, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngel, 0f) * Vector3.forward;

            controller.Move(moveDirection.normalized * playerSpeed * Time.deltaTime);//moves it according to last code segment
        }
    }

    private void FixedUpdate() 
    {
        controller.Move(playerVelocity * Time.deltaTime); //simulates jumping
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("JumpBlock"))
        {
            playerVelocity.y += gravityValue;
        }
    }
}
