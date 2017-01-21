using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    BoxCollider bc;

    // Use this for initialization
    void Start()
    {
        bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
     //   if (collision.gameObject.CompareTag("Ball"))
     //     print("Player collide with ball");
    }
}