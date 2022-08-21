using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunRotation : MonoBehaviour
{
    private float coinAngel = 0.9f;

    void Update()
    {
        //to rotate the coin using its transform
        transform.Rotate(transform.up, 360 * coinAngel * Time.deltaTime);
        

    }
    }

