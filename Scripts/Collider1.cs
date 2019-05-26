using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Collider1 : MonoBehaviour
{
    private Vector3 position;
    private Transform myTransform;
    private Rigidbody rb;
    private Camera cam;
    private float lastTime;
    private float offset = 2f;
    private Vector3 randomPos;
    void Awake()
    {
        cam = Camera.main;
    }
    void Start()
    {
        
        float randomR = Random.Range(-15, 15);
          rb =GetComponent<Rigidbody>();
        randomPos = new Vector3(randomR, 0f, 0f);
    }

    void Update()
    {
        // moving asteroids 
        //float randomPos = Random.Range(-3, 3);
       // Vector3 randomPos = new Vector3(Random.Range(-3, 3), 0f, 0f);
        transform.position += (randomPos * Time.deltaTime * 0.2f);
    }
    void OnCollisionEnter(Collision col)
    {

        
        if (col.gameObject.tag == "Bullet")
        {
            
            GameMasterScript.currentScore += 1;
            GameMasterScript.KillCollider(this);

            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else
        {
            GameMasterScript.KillCollider(this);

            Destroy(col.gameObject);
            Destroy(gameObject);
        }

    }


}
