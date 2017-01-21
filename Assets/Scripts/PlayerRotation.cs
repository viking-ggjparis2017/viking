using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    [SerializeField]
    private Transform[] _affectedItems = null;

    [SerializeField]
    private Rigidbody _selfRigidBody = null;

    private float _neutral = 0.2f;
    private float _rotationSpeed = 3f;

	void FixedUpdate () {
        Vector3 movement = _selfRigidBody.velocity;

        if(movement == Vector3.zero)
        {
            return;
        }

        foreach (Transform target in _affectedItems)
        {
            target.rotation = Quaternion.Slerp(
                target.rotation,
                Quaternion.LookRotation(movement * -1f),
                Time.fixedDeltaTime * _rotationSpeed
            );
        }
    }
}
 