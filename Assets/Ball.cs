﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IResetable {

    private const float CRIT_TIMER = 0.5f;

    GameObject owner = null;

    [SerializeField]
    GameObject Player01, Player02;

    [SerializeField]
    Material Player01OwnerMat, Player02OwnerMat;

    [SerializeField]
    ScoreManager scoreMgr;

    [SerializeField]
    private Material _critStatusMat = null;

    private int _hits = 0;

    private bool _isCrit = false;
    private float _critTimer = 0f;

    Renderer rd;

    //----- reset variable
    Vector3 resetPosition;
    Quaternion resetRotation;

    void Start () {
        rd = GetComponent<Renderer>();

        resetPosition = transform.position;
        resetRotation = transform.rotation;
    }
	
	void Update () {
        CritUpdate();

    }
    
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

    public void Toss(int player)
    {
        SetOwner(player);

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        StartCrit();
    }

    public bool IsCritActive(int player)
    {
        return _isCrit && ((player == 1 && owner == Player01) || (player == 2 && owner == Player02));
    }

    public void CritUpdate()
    {
        if (!_isCrit)
        {
            return;
        }


        if (_critTimer >= Ball.CRIT_TIMER)
        {
            EndCrit();
        }

        _critTimer += Time.deltaTime;
    }

    public void StartCrit()
    {
        _isCrit = true;
        _critTimer = 0f;
        rd.material = _critStatusMat;
    }

    public void EndCrit()
    {
        _isCrit = false;
        _critTimer = 0f;
        rd.material = owner == Player01 ? Player01OwnerMat : Player02OwnerMat;
    }
}