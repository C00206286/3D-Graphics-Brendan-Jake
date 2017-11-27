using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour
{

    public float constSpeed;
    public float speed;
    public Rigidbody rb;
    public float moveWait;
    private Vector3 movement;
    public bool colliding;
    bool moveDown;

    public GameObject hazard1;
    public GameObject hazard2;
    public GameObject hazard3;
    public GameObject hazard4;
    public GameObject hazard5;
    public Vector3 spawnValues1;
    public Vector3 spawnValues2;
    public Vector3 spawnValues3;
    public Vector3 spawnValues4;
    public Vector3 spawnValues5;

    public Transform target;


    private bool spawned = false;

    void Start()
    {
        moveDown = true;
        StartCoroutine(moveWaves());
    }

    void Update()
    {
        
    }
    void LateUpdate()
    {
        if (colliding == true && spawned == false)
        {
            Quaternion spawnRotation = Quaternion.identity;
            int randomNum = Random.Range(1, 5);
            if (randomNum == 1)
            {
                Vector3 spawnPosition = new Vector3(spawnValues1.x, spawnValues1.y, spawnValues1.z);
                Instantiate(hazard1, spawnPosition, spawnRotation);
                spawned = true;
            }
            else if (randomNum == 2)
            {
                Vector3 spawnPosition = new Vector3(spawnValues2.x, spawnValues2.y, spawnValues2.z);
                Instantiate(hazard2, spawnPosition, spawnRotation);
                spawned = true;
            }
            else if (randomNum == 3)
            {
                Vector3 spawnPosition = new Vector3(spawnValues3.x, spawnValues3.y, spawnValues3.z);
                Instantiate(hazard3, spawnPosition, spawnRotation);
                spawned = true;
            }
            else if (randomNum == 4)
            {
                Vector3 spawnPosition = new Vector3(spawnValues4.x, spawnValues4.y, spawnValues4.z);
                Instantiate(hazard4, spawnPosition, spawnRotation);
                spawned = true;
            }
            else if (randomNum == 5)
            {
                Vector3 spawnPosition = new Vector3(spawnValues5.x, spawnValues5.y, spawnValues5.z);
                Instantiate(hazard5, spawnPosition, spawnRotation);
                spawned = true;
            }
   
        }

    }
    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody>();

        if (colliding == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.RotateAround(target.position, Vector3.up, 90);
            }
        }
        

        if (colliding == false)
     { 
        if (moveDown == true)
        {
            movement = new Vector3(0.0f, 0.0f, constSpeed);
            moveDown = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movement = new Vector3(-constSpeed, 0.0f, 0.0f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movement = new Vector3(constSpeed, 0.0f, 0.0f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                movement = new Vector3(0.0f, 0.0f, constSpeed);
            }
         else
        {
            movement = new Vector3(0.0f, 0.0f, 0.0f);
        }


        GetComponent<Rigidbody>().velocity = movement * speed;
    }
       
    }
     IEnumerator moveWaves()
    {
        for (; ; )
        {
            if (moveDown == false)
            {
                moveDown = true;
            }
            yield return new WaitForSeconds(moveWait);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Finish")
        {
            colliding = true;
        }
        if (col.gameObject.tag == "Block")
        {
            colliding = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            colliding = true;
        }
        else if (other.gameObject.tag == "Side")
        {
          
        }
        else
        {
            //Destroy(other.gameObject);
        }
    }

}