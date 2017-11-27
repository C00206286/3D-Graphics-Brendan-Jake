using UnityEngine;
using System.Collections;

public class RandomRotate : MonoBehaviour
{


    public float tumble;

    void Start()
    {

        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }



}