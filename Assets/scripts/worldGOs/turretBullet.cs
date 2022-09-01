using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifeSpan;
    private Rigidbody _rb; //will be used to AddForce and move the projectile
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * bulletSpeed );
        Invoke("Delete",lifeSpan);
    }
    
    private void Delete()
    {
        Destroy(gameObject);
    }
}
