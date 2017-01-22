using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fabric;

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

    Animator _animator;

    //----- reset variable
    Vector3 resetPosition;
    Quaternion resetRotation;

    private bool _noControl = false;
    private float _noControlTimer = 0f;
    private float _noControlLimit = 0f;
    
	void Start () {
        rb = GetComponent<Rigidbody>();

        horizontalAxisName = "Horizontal_P" + playerNumber.ToString(); 
        verticalAxisName = "Vertical_P" + playerNumber.ToString();

        resetPosition = transform.position;
        resetRotation = transform.rotation;

        _animator = GetComponentInParent<Animator>();

    }
	
	void Update () {
        if (_noControl)
        {
            _noControlTimer += Time.deltaTime;
            if (_noControlTimer >= _noControlLimit)
            {
                _noControl = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Mouvement();

        var currentVelocity = rb.velocity;
        var oppositeForce = -currentVelocity * mouvementReduction;
        rb.AddRelativeForce(oppositeForce.x, oppositeForce.y, oppositeForce.z);
    }

    void Mouvement()
    {
        if(_noControl)
        {
            return;
        }

        rb.AddForce(new Vector3(Input.GetAxis(horizontalAxisName) * mouvementSpeed * Time.deltaTime, 0, -Input.GetAxis(verticalAxisName) * mouvementSpeed * Time.deltaTime)
                    , ForceMode.VelocityChange);

        //        print("horizontalAxisName : " + Input.GetAxis(horizontalAxisName));
        //        print("verticalAxisName : " + Input.GetAxis(verticalAxisName));

        _animator.GetBool("Test");

        //_animator.GetFloat("X_Axis_Mouvement");

//        _animator.SetFloat("X_Axis_Mouvement", 1);
   //     _animator.SetFloat("Y_Axis_Mouvement", Input.GetAxis(verticalAxisName));

    }

    public void Reset()
    {
        transform.position = resetPosition;
        transform.rotation = resetRotation;

        StopControl(0.25f);
    }

    public void StopControl(float time)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Input.ResetInputAxes();

        _noControlTimer = 0f;
        _noControlLimit = time;
        _noControl = true;
    }
}