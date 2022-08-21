using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move3d : MonoBehaviour
{
    public CharacterController _controller; //puvlic to plug it in and use it for the last .move command
    [SerializeField] public float Playerspeed;
    //ref for our cam so we can use it to change where our GO's forward is (the way the camera is facing)
    [SerializeField] Transform MovementCam;
    
    //for jump
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] public float jumpHeight = 2.0f;
    private float gravityValue = -9.81f;
    void Start()
    {
        
    }

    
    void Update()
    {
        float Hinput = Input.GetAxisRaw("Horizontal") * Playerspeed;
        float Vinput = Input.GetAxisRaw("Vertical") * Playerspeed;
        Vector3 _direction = new Vector3(Hinput, 0f, Vinput).normalized;
        
        //for jump
        groundedPlayer = _controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        if (_direction != Vector3.zero)
        {
            gameObject.transform.forward = _direction;
        }
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        _controller.Move(playerVelocity * Time.deltaTime);
        //telling the player to move according to the input
        //for local direction moevement (from the old script)
        if (_direction.magnitude >= 0.1f)
        {
            float _targetAngel = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg+ MovementCam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, _targetAngel, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, _targetAngel, 0f) * Vector3.forward;

            _controller.Move(moveDirection.normalized * Playerspeed * Time.deltaTime);
        }
    }
}
