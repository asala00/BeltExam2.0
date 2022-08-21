using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifeSpan;
    private Rigidbody rb; //will be used to AddForce and move the projectile
    
    //calling the script that has the health to makae the bullet effect it 
     private interactions playerHPscript;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward *bulletSpeed );
        Invoke("Delete",lifeSpan);
    }
    private void Delete()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHPscript = collision.gameObject.GetComponent<interactions>();
            playerHPscript.HP -=0.2f;
            
            Destroy(gameObject);
        }
    }
}
