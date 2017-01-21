using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossControls : MonoBehaviour {

    [SerializeField]
    private Rigidbody _selfBody = null;
    
    private Rigidbody _ballBody = null;
    private Ball _ballScript = null;

    [SerializeField]
    private float _tossRadius = 2f;

    [Range(1, 2), SerializeField]
    private int playerNumber = 1;

    void Start()
    {
        var ball = GameObject.FindGameObjectWithTag("Ball");
        _selfBody = ball.GetComponent<Rigidbody>();
        _ballScript = ball.GetComponent<Ball>();
    }

    public void Update () {
		if((playerNumber == 1 && Input.GetButtonDown("Stop_P1")) || (playerNumber == 2 && Input.GetButtonDown("Stop_P2")))
        {
            Debug.Log("Toss " + playerNumber);

            if(IsBallInRange())
            {
                Debug.Log("Toss ok " + playerNumber);
                _ballScript.Toss(playerNumber);
            }
        }
	}

    private bool IsBallInRange()
    {
        Vector3 dir = _ballBody.transform.position - _selfBody.transform.position;
        return dir.magnitude <= _tossRadius;
    }
}
