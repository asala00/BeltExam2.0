using UnityEngine;

public class GunRotation : MonoBehaviour
{
    private float _gunAngel = 0.9f;

    void Update()
    {
        transform.Rotate(transform.up, 360 * _gunAngel * Time.deltaTime);
    }
}

