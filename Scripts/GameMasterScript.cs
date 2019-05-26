using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMasterScript : MonoBehaviour
{
    public static GameMasterScript gm;
    public static GameObject ShipTag, BulletTag;
    public GameObject GameLost, GameRestart, Player;
    public GameObject Asteroid;

    public static int currentScore = 0;
    public Text UIScore;

    
    public Transform asteroidPrefab;
    private Camera cam;

    private float spawnDelay = 0.5f;  // spawn delays for asteroids
    private float spawnDelay2 = 1f; // using floats instead of ints just to make holding animations after player dead easier
    void Awake()
    {
        cam = Camera.main;
    }
    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMasterScript>();
        }
       
        GameRestart.SetActive(false);
        GameLost.SetActive(false);
        Vector3 spawnVector;

        for (int i = -502; i < 502; i+=4)                       // maths to place asteroids and not destroy our ship at beginning while spawning them at game start 
        {
            for (int j = -20; j < 20; j+=4)
            {
                    spawnVector = new Vector3(j, i, 0);
                
                Instantiate(Asteroid, spawnVector, Quaternion.identity);
            }
        }
        
    }
    
    public void Update()
    {
       
            UIScore.text = currentScore.ToString();
        

        if (Player == null)
        {
           
            GameRestart.SetActive(true);
            GameLost.SetActive(true);                       //setting endgame UI

            currentScore = 0;

        }
        
    }
    public void RespawnAsteroid1()   //respawning without delay time
    {
        Vector3 myVector;
        float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;
        float camVerticalExtend = cam.orthographicSize;

        int positionX = Random.Range(-17, -4);
        int positionX2 = Random.Range(4, 18);
        int positionY = Random.Range(-322, 319);
        int randomSide = Random.Range(0, 2);


        if (randomSide == 1)                                // not to respawn asteroid on Y=0 line to destroy player immediately
        {
            myVector = new Vector3(positionX, positionY, 0.0f);
        }
        else
        {
            myVector = new Vector3(positionX2, positionY, 0.0f);
        }

    }
    public IEnumerator RespawnAsteroid()   // respawn asteroid with timer
    {
        Vector3 myVector;
        float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;
        float camVerticalExtend = cam.orthographicSize;

        int positionX = Random.Range(-17, -6);
        int positionX2 = Random.Range(6, 18);
        int positionY = Random.Range(-322, 319);
        int randomSide = Random.Range(0, 2);


        if (randomSide == 1)                                // not to respawn asteroid on Y=0 line to destroy player immediately
        {
            myVector = new Vector3(positionX, positionY, 0.0f);
        }
        else {
            myVector = new Vector3(positionX2, positionY, 0.0f);
        }
    

        yield return new WaitForSeconds(spawnDelay);
        if (Player != null)                     //not respawn asteroids after player dead
        {
            yield return new WaitForSeconds(spawnDelay2);
            Instantiate(asteroidPrefab, myVector, Quaternion.identity);     //respawning after time
        }
    }
    public static void KillCollider(Collider1 collider)
    {


        if (collider.gameObject.tag == ("Player"))
        {
            ShipTag = GameObject.FindGameObjectWithTag("Ship");
            Destroy(ShipTag);

        }
        else if (collider.gameObject.tag == ("Asteroid"))
        {
            Destroy(collider);
            gm.StartCoroutine(gm.RespawnAsteroid());    // enable to respawn asteroids after 1 second (desable gm.RespawnAsteroid1()

           // gm.RespawnAsteroid1();
        }


    }
    public static void KillCollider(ShipCollider collider)
    {


        if (collider.gameObject.tag == ("Player"))
        {
            ShipTag = GameObject.FindGameObjectWithTag("Ship");
            Destroy(ShipTag);

        }
        else if (collider.gameObject.tag == ("Asteroid"))
        {
            Destroy(collider);
            gm.StartCoroutine(gm.RespawnAsteroid());    // enable to respawn asteroids after 1 second (desable gm.RespawnAsteroid1()

           // gm.RespawnAsteroid1();
        }


    }

}
