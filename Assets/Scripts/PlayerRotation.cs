using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    [SerializeField]
    private Transform[] _affectedItems = null;

    [SerializeField]
    private Rigidbody _selfRigidBody = null;

    private float _rotationSpeed = 3f;

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

            //            print("target.rotation : " + target.rotation);
            //            print("movement * -1f : " + movement * -1f);

            //            _startVector = target.eulerAngles.x;
            //            _endVector = Quaternion.LookRotation(movement * -1f);

            /*float tiltAroundZ = target.eulerAngles.z;
            float tiltAroundX = target.eulerAngles.x;
            Quaternion targeta = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
            transform.rotation = Quaternion.Slerp(targeta, Quaternion.LookRotation(movement * -1f), Time.fixedDeltaTime * _rotationSpeed);*/

    //        Debug.Log(target);

        target.rotation = Quaternion.Slerp(
            target.rotation,
            Quaternion.LookRotation(movement),
            Time.deltaTime * _rotationSpeed
        );
//            Debug.Log(target.rotation);


            //Quaternion yourRotationQuaternion = Quaternion.Slerp(_startVector, _endVector, Time.fixedDeltaTime * _rotationSpeed);

            //yourRotationQuaternion = Quaternion.Euler(new Vector3(yourRotationQuaternion.eulerAngles.x, target.transform.rotation.eulerAngles.y, yourRotationQuaternion.eulerAngles.z));

            //target.rotation = yourRotationQuaternion;

            //   target.rotation = Quaternion.Slerp(_startVector, _endVector, Time.fixedDeltaTime * _rotationSpeed)

            //            transform.Rotate(Vector3.Slerp(_startVector.eulerAngles, _endVector.eulerAngles, Time.fixedDeltaTime * _rotationSpeed));

        }
    }
}
 