using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IResetable {

    private const float CRIT_TIMER = 0.3f;
    private const float CRIT_BUILDUP = 0.2f;

    GameObject owner = null;

    [SerializeField]
    GameObject Player01, Player02;

    [SerializeField]
    Material Player01OwnerMat, Player02OwnerMat;

    [SerializeField]
    private Material _critStatusMat = null;

    [SerializeField]
    private Material _critBuildupMap = null;

    [SerializeField]
    Material defaultMaterial = null;

    private int _hits = 0;

    private bool _isCrit = false;
    private bool _isCritBuildup = false;
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
            var audioSource = collidedObject.transform.Find("Audio Source").GetComponent<AudioSource>();

            if (owner != collidedObject)
            {
                ScoreManager scoreMgr = ScoreManager.Instance;

                if (collidedObject.GetComponent<PlayerMouvement>().playerNumber == 1 && owner != null)
                    scoreMgr.IncrementPlayer02Score();
                else if (collidedObject.GetComponent<PlayerMouvement>().playerNumber == 2 && owner != null)
                    scoreMgr.IncrementPlayer01Score();

                audioSource.clip = SoundManager.instance.FindClipByName("SFX_impact");
                audioSource.Play();

                scoreMgr.ResetScene(false);
            }
            else
            {
                audioSource.clip = SoundManager.instance.FindClipByName("SFX_dodge");
                audioSource.Play();
            }
        }
    }
    
    public void SetOwner(int player)
    {
        owner = player == 1 ? Player01 : Player02;
        rd.material = player == 1 ? Player01OwnerMat : Player02OwnerMat;
    }

    public bool HasOwner()
    {
        if (owner != null)
            return true;
        else
            return false;
    }

    public void Reset()
    {
        owner = null;
        rd.material = defaultMaterial;
        _isCritBuildup = false;
        _isCrit = false;

        transform.position = resetPosition;
        transform.rotation = resetRotation;

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        _hits = 0;
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

    public bool CanBeHit()
    {
        return !_isCritBuildup;
    }

    public void CritUpdate()
    {
        if (!_isCrit && !_isCritBuildup)
        {
            return;
        }

        _critTimer += Time.deltaTime;

        if (_isCritBuildup && _critTimer >= Ball.CRIT_BUILDUP)
        {
            _isCritBuildup = false;
            _isCrit = true;
            _critTimer = 0f;
            rd.material = _critStatusMat;
            Debug.Log("buildup done");
            return;
        }

        if (_isCrit && _critTimer >= Ball.CRIT_TIMER)
        {
            Debug.Log("Crit done");
            EndCrit();
        }
    }

    public void StartCrit()
    {
        _isCritBuildup = true;
        _critTimer = 0f;
        rd.material = _critBuildupMap;
    }

    public void EndCrit()
    {
        _isCrit = false;
        _critTimer = 0f;
        rd.material = owner == Player01 ? Player01OwnerMat : Player02OwnerMat;
    }
}