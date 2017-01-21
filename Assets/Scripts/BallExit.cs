using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExit : MonoBehaviour {
    private const float X_OFFSET = 100f;
    private const float Y_OFFSET = 175f;

    [SerializeField]
    private float _exitTimeout = 1f;

    [SerializeField]
    private Transform _selfTransform = null;

    private bool _isBallOut = false;

    private float _timer = 0f;

	// Update is called once per frame
	public void Update () {
		if(_isBallOut == false && CheckForPosition())
        {
            _isBallOut = true;
        }

        if(_isBallOut)
        {
            _timer += Time.deltaTime;
            if(_timer >= _exitTimeout)
            {
                _timer = 0;
                _isBallOut = false;
                ScoreManager.Instance.ResetScene(false);
            }
        }
	}

    private bool CheckForPosition()
    {
        return _selfTransform.position.x > BallExit.X_OFFSET ||
            _selfTransform.position.x < -BallExit.X_OFFSET ||
            _selfTransform.position.y > BallExit.Y_OFFSET ||
            _selfTransform.position.y > BallExit.Y_OFFSET;
    }
}
