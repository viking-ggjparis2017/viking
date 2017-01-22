using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {
    private const int WAIT_MAX = 5;
    private const float X_MAX = 105f;
    private const float X_MIN = -103f;
    private const float Z_MAX = 43f;
    private const float Z_MIN = -74f;

    [SerializeField]
    private Transform _selfTransform = null;

    [SerializeField]
    private Rigidbody _selfRigidBody = null;

    private float _startElevation = 0f;
    private float _waitTimer = 0f;
    private Vector3 _destination = Vector3.zero;

	void Start () {
        _startElevation = _selfTransform.position.y;
	}
	
	void Update () {
        if(_waitTimer >= 0f)
        {
            _waitTimer -= Time.deltaTime;
            return;
        }

        GetNewDestination();
        SetNewTimer();
        ApplyForce();
	}

    private void GetNewDestination()
    {
        _destination.x = Random.Range(FishMovement.X_MIN, FishMovement.Z_MAX);
        _destination.z = Random.Range(FishMovement.Z_MIN, FishMovement.Z_MAX);
    }

    private void SetNewTimer()
    {
        _waitTimer = Random.Range(0.5f, FishMovement.WAIT_MAX);
    }

    private void ApplyForce()
    {
        Vector3 dir = _destination - _selfTransform.position;
        _selfRigidBody.AddForce(dir * Random.Range(0.1f, 1f), ForceMode.Impulse);
    }
}
