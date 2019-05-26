using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShipCollider : MonoBehaviour

{


    void OnCollisionEnter(Collision col)
    {


        GameMasterScript.KillCollider(this);

    }


}
