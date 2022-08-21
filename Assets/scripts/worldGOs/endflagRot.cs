using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endflagRot : MonoBehaviour
{
    private float coinAngel = 0.9f;

    void Update()
    {
        //to rotate the coin using its transform
        transform.Rotate(transform.up, 360 * coinAngel * Time.deltaTime);
        //write something for the coin to be up and down transform.position()

    }
}
