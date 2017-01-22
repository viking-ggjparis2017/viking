using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxWater : MonoBehaviour {

    Ball ball;

    [SerializeField]
    float _ratio = 1000.0f;

	void Start () {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
    }

    void Launch()
    {
        var posRatio = (ball.transform.position.x / _ratio) * Time.deltaTime;

        print("pr : " + posRatio);
        gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(posRatio, 0);
    }

    void LateUpdate()
    {
        Launch();
    }
}
