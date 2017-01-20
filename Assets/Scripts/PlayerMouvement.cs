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
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * mouvementSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * mouvementSpeed * Time.deltaTime)
                    , ForceMode.Force);
    }
}