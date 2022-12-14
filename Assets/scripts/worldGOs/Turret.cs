using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _player; //to use it in start to look at the player
    private bool _detected; //will keep our method from being Invoked infinitely
    public Transform bullSpwanPoint;
    public GameObject bullet;
    public SoundManager sm;
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
        Instantiate(bullet, bullSpwanPoint.position, bullSpwanPoint.rotation);
        //BullSpawnPoint.rotation instead of transform.rotation
        //cuz unlike the player and its gun this turret rotates in all directions to look at the player
    }

    //for some reason the sound manager cannot be added to the players bullet script(inspector)nso im doing it here instead
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
           sm.DefeatTurretSFX();
        }
    }
}
