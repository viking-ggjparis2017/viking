using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IResetable {
    
    GameObject owner = null;

    [SerializeField]
    GameObject Player01, Player02;

    [SerializeField]
    Material Player01OwnerMat, Player02OwnerMat;

    [SerializeField]
    ScoreManager scoreMgr;

    private int _hits = 0;

    Renderer rd;

    //----- reset variable
    Vector3 resetPosition;
    Quaternion resetRotation;

    void Start () {
        rd = GetComponent<Renderer>();

        resetPosition = transform.position;
        resetRotation = transform.rotation;
    }
	
	void Update () {}
    
    void OnCollisionEnter(Collision collision)
    {
        ChangeOwner(collision);
    }

    void ChangeOwner(Collision collision)
    {
        if (collision.gameObject == Player01)
        {
            scoreMgr.IncrementPlayer01Score();
            SetOwner(1);
        }
        else if (collision.gameObject == Player02)
        {
            scoreMgr.IncrementPlayer02Score();
            SetOwner(2);
        }
    }

    public void SetOwner(int player)
    {
        owner = player == 1 ? Player01 : Player02;
        rd.material = player == 1 ? Player01OwnerMat : Player02OwnerMat;
    }

    public void Reset()
    {
        transform.position = resetPosition;
        transform.rotation = resetRotation;

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    /*
     * When hit by a shwockwave.
     */
    public void Hit()
    {
        _hits++;
    }

    public int GetHits()
    {
        return _hits;
    }
}
