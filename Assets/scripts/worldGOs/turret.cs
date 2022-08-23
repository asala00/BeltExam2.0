using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _player; //to use it in start to look at the player
    private bool _detected; //will keep our method from being Invoked infinitely
    
    //similar to canon script\/ 
    public Transform BullSpwanPoint;
    public GameObject Bullet;
    public SoundManager SM;
    void Start()
    {
        _player = GameObject.Find("Player").transform;
    }    

   
    void Update()
    {
        transform.LookAt(_player);
        detectingPlayer(); //to constantly shoot at the player when in range
    }

    void detectingPlayer()
    {
        float playerDistance = Vector3.Distance(_player.transform.position, transform.position);
        if (playerDistance < 30 && _detected == false)
        {
            _detected = true;
            InvokeRepeating("Shooting",1,0.5f); //time == delay time
        }
        else if (playerDistance > 30)
        {
            _detected = false;
            CancelInvoke("Shooting");
        }
    }

    void Shooting()
    {
        Instantiate(Bullet, BullSpwanPoint.position, BullSpwanPoint.rotation);
        //BullSpwanPoint.rotation instead of transform.rotation
        //cuz unlike the player and its gun this turret rotates in all directions to look at the player
    }

    //for some reason the soundmanager cannot be added to the players bullet script(inspector)nso im doing it here instead
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
           SM.DefeatTurretSFX();
        }
    }
}
