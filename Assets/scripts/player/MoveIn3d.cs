using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIn3d : MonoBehaviour
{
    public CharacterController Controller; //puvlic to plug it in and use it for the last .move command
    public float PlayerSpeed;
    
    //ref for our cam so we can use it to change where our GO's forward is (the way the camera is facing)
    [SerializeField] Transform MovementCam;
    
    //for jump
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    public float JumpHeight = 2.0f;
    private float _gravityValue = -9.81f;

    void Update()
    {
        float Hinput = Input.GetAxisRaw("Horizontal") * PlayerSpeed;
        float Vinput = Input.GetAxisRaw("Vertical") * PlayerSpeed;
        Vector3 _direction = new Vector3(Hinput, 0f, Vinput).normalized;
        
        //for jump
        _groundedPlayer = Controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y <= 0)
        {
            _playerVelocity.y = 0f;
        }
        
        if (_direction != Vector3.zero)
        {
            gameObject.transform.forward = _direction;
        }
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(JumpHeight * -3.0f * _gravityValue);
        }
        _playerVelocity.y += _gravityValue * Time.deltaTime;
        
        
        //telling the player to move according to the input
        //for local direction moevement (from the old script)
        if (_direction.magnitude >= 0.1f)
        {
            //rotates the players oriontation based on the cameras rotation
            float _targetAngel = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg+ MovementCam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, _targetAngel, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, _targetAngel, 0f) * Vector3.forward;

            Controller.Move(moveDirection.normalized * PlayerSpeed * Time.deltaTime);//moves it according to las code segment
        }
    }

    private void FixedUpdate()
    {
        Controller.Move(_playerVelocity * Time.deltaTime); //simulates jumping
    }
}
