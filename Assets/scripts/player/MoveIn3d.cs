using UnityEngine;


public class MoveIn3d : MonoBehaviour
{
    public CharacterController controller; //public to plug it in and use it for the last .move command
    public float playerSpeed;
    [SerializeField] Transform movementCam; //ref for our cam so we can use it to change where our GO's forward is (the way the camera is facing)
    
    //for jump
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    public float jumpHeight = 2.0f;
    private float _gravityValue = -9.81f;

    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal") * playerSpeed;
        float vInput = Input.GetAxisRaw("Vertical") * playerSpeed;
        Vector3 direction = new Vector3(hInput, 0f, vInput).normalized;
        
        //for jump
        _groundedPlayer = controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y <= 0)
        {
            _playerVelocity.y = 0f;
        }
        
        if (direction != Vector3.zero)
        {
            gameObject.transform.forward = direction;
        }
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * _gravityValue);
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;

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
        controller.Move(_playerVelocity * Time.deltaTime); //simulates jumping
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("JumpBlock"))
        {
            _playerVelocity.y += _gravityValue;
        }
    }
}
