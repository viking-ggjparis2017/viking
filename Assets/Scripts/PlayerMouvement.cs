using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour {

    [SerializeField]
    float mouvementSpeed = 20;

    [SerializeField]
    float mouvementReduction = 10;

    [Range(1, 2), SerializeField]
    int playerNumber = 1;

    string horizontalAxisName;
    string verticalAxisName;

    Rigidbody rb;
    
	void Start () {
        rb = GetComponent<Rigidbody>();

        horizontalAxisName = "Horizontal_P" + playerNumber.ToString(); 
        verticalAxisName = "Vertical_P" + playerNumber.ToString();
    }
	
	void Update () {}

    private void FixedUpdate()
    {
        Mouvement();

        var currentVelocity = rb.velocity;
        var oppositeForce = -currentVelocity * mouvementReduction;
        rb.AddRelativeForce(oppositeForce.x, oppositeForce.y, oppositeForce.z);
    }

    void Mouvement()
    {
        rb.AddForce(new Vector3(Input.GetAxis(horizontalAxisName) * mouvementSpeed * Time.deltaTime, 0, Input.GetAxis(verticalAxisName) * mouvementSpeed * Time.deltaTime)
                    , ForceMode.Force);

       // rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * mouvementSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * mouvementSpeed * Time.deltaTime)
         //   , ForceMode.Force);
    }
}