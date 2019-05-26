using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class ShipControls : MonoBehaviour
    {
        void Update()
        {
            transform.Translate(0f, 1f * Input.GetAxis("Vertical") * Time.deltaTime, 0f);
        }
    }
}