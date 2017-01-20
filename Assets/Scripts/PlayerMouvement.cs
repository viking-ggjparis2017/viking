using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour {

    [SerializeField]
    float mouvementSpeed = 20;

    [SerializeField]
    float mouvementReduction = -10;

    Rigidbody rb;
    
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {}

    private void FixedUpdate()
    {
        Mouvement();

        var currentVelocity = rb.velocity;
        var oppositeForce = -currentVelocity;
        rb.AddRelativeForce(oppositeForce.x, oppositeForce.y, oppositeForce.z);

    }

    void Mouvement()
    {
        if (Input.GetKey("up"))
        {
            Vector3 n = new Vector3(0, 0, mouvementSpeed * Time.deltaTime);
            rb.AddForce(n, ForceMode.Force);
        }
        if (Input.GetKey("down"))
        {
            Vector3 n = new Vector3(0, 0, -mouvementSpeed * Time.deltaTime);
            rb.AddForce(n, ForceMode.Force);
        }
        if (Input.GetKey("left"))
        {
            Vector3 n = new Vector3(-mouvementSpeed * Time.deltaTime, 0, 0);
            rb.AddForce(n, ForceMode.Force);
        }
        if (Input.GetKey("right"))
        {
            Vector3 n = new Vector3(mouvementSpeed * Time.deltaTime, 0, 0);
            rb.AddForce(n, ForceMode.Force);
        }
    }
}