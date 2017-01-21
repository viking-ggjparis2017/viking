using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxWater : MonoBehaviour {
    Material currentMaterial;

    [SerializeField]
    float maxOffset = 50;

    Ball ball;

	void Start () {
        currentMaterial = GetComponent<Material>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
	}
	
	void Update () {}

    void LateUpdate()
    {
        var newPos = new Vector3(transform.position.x + (maxOffset * ball.parallaxBallPosition * Time.deltaTime), transform.position.y, transform.position.z);
        print(newPos);
        transform.position = newPos;
    }
}
