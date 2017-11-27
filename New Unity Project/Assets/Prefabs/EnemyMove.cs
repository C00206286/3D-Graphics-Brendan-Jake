
using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    public float speedSide;
    public float speed;
    public Rigidbody rb;
    public float moveWait;
    bool moveDown = false;
    bool moveAccross = false;

    void Start()
    {
        moveAccross = true;
        StartCoroutine(moveWaves());
    }
    void FixedUpdate()
    {
        if (moveAccross == true)
        {
            rb.velocity = transform.right * speedSide;
        }
        else if (moveDown == true)
        {
            rb.velocity = transform.up * speed;
        }

    }
    IEnumerator moveWaves()
    {
        for (; ; )
        {
            if (moveAccross == true)
            {
                moveAccross = false;
                moveDown = true;
            }
            else if (moveDown == true)
            {
                moveDown = false;
                moveAccross = true;
                speedSide = speedSide * -1;
            }
            yield return new WaitForSeconds(moveWait);
        }
    }
}
