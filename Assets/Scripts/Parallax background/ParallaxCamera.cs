using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCamera : MonoBehaviour {

    Ball ball;

    [SerializeField]
    float _ratio = 1000.0f;

    Vector3 _basePosition;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        _basePosition = transform.position;
    }

    void Launch()
    {
        var posRatio = _basePosition.x + (ball.transform.position.x / _ratio) * Time.deltaTime;

        gameObject.transform.position = new Vector3(posRatio, _basePosition.y, _basePosition.z);
    }

    void LateUpdate()
    {
        Launch();
    }
}
