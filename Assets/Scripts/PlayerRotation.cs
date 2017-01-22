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

    private Quaternion _startVector, _endVector;

	void FixedUpdate () {
        Vector3 movement = _selfRigidBody.velocity;

        if(movement == Vector3.zero)
        {
            return;
        }

        foreach (Transform target in _affectedItems)
        {
            //print("target.rotation : " + target.rotation);
           // print("movement * -1f : " + movement * -1f);

            _startVector = target.rotation;
            _endVector = Quaternion.LookRotation(movement * -1f);

            Quaternion yourRotationQuaternion = Quaternion.Slerp(_startVector, _endVector, Time.fixedDeltaTime * _rotationSpeed);

            yourRotationQuaternion = Quaternion.Euler(new Vector3(yourRotationQuaternion.eulerAngles.x, target.transform.rotation.eulerAngles.y, yourRotationQuaternion.eulerAngles.z));

            target.rotation = yourRotationQuaternion;

            //target.rotation = Quaternion.Slerp(_startVector, _endVector, Time.fixedDeltaTime * _rotationSpeed);
        }
    }
}
 