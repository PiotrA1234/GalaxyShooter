using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    
    void Update()
    {
        transform.Translate(0f, 4f * Input.GetAxis("Vertical") * Time.deltaTime, 0f, Space.World);
        transform.Rotate(0f, 0f, 8 * Input.GetAxis("Horizontal"));

    }

}
