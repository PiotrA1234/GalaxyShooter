using UnityEngine;
using System.Collections;

public class Camera2DFollow : MonoBehaviour
{
    private Vector3 offset1;
    public GameObject player;        
    
    void Start()
    {
        offset1 = transform.position - player.transform.position;
    }

   
    void LateUpdate()
    {       
        if (player != null) transform.position = player.transform.position + offset1;
    }
}