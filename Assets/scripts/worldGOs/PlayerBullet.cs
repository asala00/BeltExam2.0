using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifeSpan;
    private Rigidbody _rb;
    private GameObject _enemy;
   
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.right * bulletSpeed );//replaced vector3 with transform so it rotates wherever the player is facing+used right instead of forward cuz the guns orientation was based on the global and coldnt be changed
        
        Invoke("Delete",lifeSpan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            _enemy = collision.gameObject;
            Destroy(_enemy); //prefabs cant be destroyed so deactivate
            Destroy(gameObject);
        }
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
}
