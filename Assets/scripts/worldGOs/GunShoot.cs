using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Transform bullSpwanPoint;
    public GameObject bullet;
    public SoundManager sm;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Instantiating is the command for spawning new game objects into
            //the scene that don't already exist in there, it takes:
            // What game object we want to spawn
            // Where we want to spawn the game object
            // What rotation angle we want the game object to be at when it spawns in
            Instantiate(bullet, bullSpwanPoint.position, transform.rotation);
            sm.ShootSFX();
        }
    }
}
