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

    public string horizontalAxisName;
    public string verticalAxisName;

    Rigidbody rb;
    
    public Animator _animator;

    //----- reset variable
    Vector3 resetPosition;
    Vector3 resetParentPosition;
    Quaternion resetRotation;

    private bool _noControl = false;
    private float _noControlTimer = 0f;
    private float _noControlLimit = 0f;
    
	void Start () {
        rb = GetComponentInParent<Rigidbody>();

        horizontalAxisName = "Horizontal_P" + playerNumber.ToString(); 
        verticalAxisName = "Vertical_P" + playerNumber.ToString();

        resetPosition = transform.position;
        resetRotation = transform.rotation;
        resetParentPosition = transform.parent.parent.position;

       _animator = GetComponent<Animator>();

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

          _animator.SetFloat("X_Axis_Mouvement",  Mathf.Abs(Input.GetAxis(horizontalAxisName)));
          _animator.SetFloat("Y_Axis_Mouvement", Mathf.Abs(Input.GetAxis(verticalAxisName)));

    }

    public void Reset()
    {
        transform.position = resetPosition;
        transform.rotation = resetRotation;
        transform.parent.parent.position = resetParentPosition;

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