﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour {

    [SerializeField]
    private float _lifetime = 0.4f;

    [SerializeField]
    private float _maxRadius = 10f;

    [SerializeField]
    private float _force = 100f;

    [SerializeField]
    private float _hitForceMultiplier = 0.3f;

    [SerializeField]
    private float _critRadius = 1f;

    [SerializeField]
    private float _critMultiplier = 1.5f;

    [SerializeField]
    private Transform _selfTransform = null;

    [SerializeField]
    private GameObject _selfObject = null;

    [SerializeField]
    private Rigidbody _selfRigidBody = null;

    private bool _active = false;
    private float _currentLifeTime = 0f;
    private float _critMultiplierDelta = 0f;
    private Vector3 _startScale = new Vector3(0f, 1f, 0f);
    private Vector3 _endScale = new Vector3(0f, 1f, 0f);

    public void Start()
    {
        _selfObject.SetActive(false);
        _endScale.x = _maxRadius * 2;
        _endScale.z = _maxRadius * 2;
        _critMultiplierDelta = 1 - (_critRadius / _maxRadius);
    }
	
	public void FixedUpdate() {
		if (!_active)
        {
            return;
        }

        _currentLifeTime += Time.fixedDeltaTime;

        if (_currentLifeTime >= _lifetime)
        {
            _selfObject.SetActive(false);
            _active = false;
        }

        _selfTransform.localScale = Vector3.Lerp(_startScale, _endScale, _currentLifeTime / _lifetime);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
           AddExplosionForce(other.GetComponent<Rigidbody>(), _selfRigidBody.position, other.GetComponent<Ball>());
        }
    }

    public void AddExplosionForce(Rigidbody body, Vector3 expPosition, Ball ballScript)
    {
        Vector3 dir = body.transform.position - expPosition;
        float magnitude = dir.magnitude;

        float forceMultiplier = 1 - (magnitude/ _maxRadius);
        if (forceMultiplier <= 0) 
        {
            return;
        }

        ballScript.Hit();
        forceMultiplier *= 1 + (_hitForceMultiplier * ballScript.GetHits());

        Debug.Log("Dir " + dir.ToString());
        Debug.Log("Magnitude " + dir.magnitude.ToString());
        Debug.Log("Force multiplier " + forceMultiplier.ToString());

        body.AddForce(dir.normalized * _force * forceMultiplier);
    }

    public void Drop(Vector3 dropPosition)
    {
        _currentLifeTime = 0f;
        _selfTransform.position = dropPosition;
        _selfTransform.localScale = _startScale;

        _active = true;
        _selfObject.SetActive(true);
    }

    public bool IsActive()
    {
        return _active;
    }
}
