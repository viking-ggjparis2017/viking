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
//        var max_X = Mathf.Clamp(transform.position.x + (maxOffset * ball.parallaxBallPosition * Time.deltaTime), -30, 30);

  //      print("Val : " + (transform.position.x + (maxOffset * ball.parallaxBallPosition * Time.deltaTime)));

//        var newPos = new Vector3(max_X, transform.position.y, transform.position.z);
  //      transform.position = newPos;
    }
}
