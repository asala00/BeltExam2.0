using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lifeSpan;
    private Rigidbody _rb; //will be used to AddForce and move the projectile
    
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
}
