using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour, IResetable {

    [SerializeField]
    float mouvementSpeed = 20;

    [SerializeField]
    float mouvementReduction = 10;

    [Range(1, 2), SerializeField]
    public int playerNumber = 1;

    string horizontalAxisName;
    string verticalAxisName;

    Rigidbody rb;

    //----- reset variable
    Vector3 resetPosition;
    Quaternion resetRotation;
    
	void Start () {
        rb = GetComponent<Rigidbody>();

        horizontalAxisName = "Horizontal_P" + playerNumber.ToString(); 
        verticalAxisName = "Vertical_P" + playerNumber.ToString();

        resetPosition = transform.position;
        resetRotation = transform.rotation;
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
        rb.AddForce(new Vector3(Input.GetAxis(horizontalAxisName) * mouvementSpeed * Time.deltaTime, 0, -Input.GetAxis(verticalAxisName) * mouvementSpeed * Time.deltaTime)
                    , ForceMode.VelocityChange);
    }

    public void Reset()
    {
        transform.position = resetPosition;
        transform.rotation = resetRotation;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Input.ResetInputAxes();
    }
}