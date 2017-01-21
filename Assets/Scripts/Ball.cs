using System;
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
    private Material _critStatusMat = null;

    [SerializeField]
    Material defaultMaterial = null;

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
        var collidedObject = collision.gameObject;

        if (collidedObject.tag == "Player")
        {
            if (owner != collidedObject)
            {
                ScoreManager scoreMgr = ScoreManager.Instance;

                if (collidedObject.GetComponent<PlayerMouvement>().playerNumber == 1 && owner != null)
                    scoreMgr.IncrementPlayer02Score();
                else if (collidedObject.GetComponent<PlayerMouvement>().playerNumber == 2 && owner != null)
                    scoreMgr.IncrementPlayer01Score();

                scoreMgr.ResetScene(false);
            }
        }
    }
    
    public void SetOwner(int player)
    {
        owner = player == 1 ? Player01 : Player02;
        rd.material = player == 1 ? Player01OwnerMat : Player02OwnerMat;
    }

    public void Reset()
    {
        owner = null;
        rd.material = defaultMaterial;

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

    public bool IsCritActive()
    {
        return _isCrit;
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