using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lifeSpan;
    private Rigidbody _rb; //will be used to AddForce and move the projectile
    
    //calling the script that has the health to makae the bullet effect it 
     private Interactions _playerHPscript;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * _bulletSpeed );
        Invoke("Delete",_lifeSpan);
    }
    
    private void Delete()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerHPscript = collision.gameObject.GetComponent<Interactions>();
            _playerHPscript.HP -=0.2f;
            
            Destroy(gameObject);
        }
    }
}
