using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fabric;

public class SoundTest : MonoBehaviour {

// 

	// Use this for initialization
	void Start () {
    }

    void TestSon()
    {
        if (Input.GetKey("l"))
            GetComponent<Fabric.AudioComponent>().Play(gameObject);

    }
	
	// Update is called once per frame
	void Update () {
        TestSon();

    }
}
