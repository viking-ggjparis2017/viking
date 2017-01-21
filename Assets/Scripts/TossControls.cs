﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossControls : MonoBehaviour {

    [SerializeField]
    private Rigidbody _ballBody = null;

    [SerializeField]
    private Ball _ballScript = null;

    [SerializeField]
    private float _tossRadius = 2f;

    [Range(1, 2), SerializeField]
    private int playerNumber = 1;

    public void Update () {
		if((playerNumber == 1 && Input.GetButtonDown("Stop_P1")) || (playerNumber == 2 && Input.GetButtonDown("Stop_P2")))
        {
            if(IsBallInRange())
            {
                _ballScript.Toss(playerNumber);
            }
        }
	}

    private bool IsBallInRange()
    {
        return Vector3.Distance(transform.position, _ballBody.transform.position) <= _tossRadius;
    }
}
