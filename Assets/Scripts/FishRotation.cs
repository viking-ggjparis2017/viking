using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRotation : MonoBehaviour
{

    [SerializeField]
    private Rigidbody _selfRigidBody = null;

    [SerializeField]
    private Transform _selfTransform = null;

    private float _rotationSpeed = 3f;


    void FixedUpdate()
    {
        Vector3 movement = _selfRigidBody.velocity;

        if (movement == Vector3.zero)
        {
            return;
        }

        _selfTransform.rotation = Quaternion.Slerp(
            _selfTransform.rotation,
            Quaternion.LookRotation(movement),
            Time.deltaTime * 4f
        );
    }
}