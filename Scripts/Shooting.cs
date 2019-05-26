using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public float fireCooldownInSecs = 0.5f;
    private float fireCountdown = 0f;

    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    private float Bullet_Forward_Force=1000f;
    

    void Start()
    {
        
    }

    void Update()
    {
        
        if (fireCountdown <= 0f) {
            Shoot();
            fireCountdown = 1f;
        }
        fireCountdown -= (1/ fireCooldownInSecs) *Time.deltaTime;
            
        
    }
    
    void Shoot()
    { 
 
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

 
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();


        // move the bullet 
        Temporary_RigidBody.AddForce(transform.up * Bullet_Forward_Force);

        // destroy the bullet
        Destroy(Temporary_Bullet_Handler, 3.0f);
  
    }
}