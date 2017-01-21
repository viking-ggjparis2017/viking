using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField]
    GameObject owner = null;

    [SerializeField]
    GameObject Player01, Player02;

    [SerializeField]
    Material Player01OwnerMat, Player02OwnerMat;

    [SerializeField]
    ScoreManager scoreMgr;

    Renderer rd;

    // Use this for initialization
    void Start () {
        rd = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnCollisionEnter(Collision collision)
    {
        ChangeOwner(collision);
    }

    void ChangeOwner(Collision collision)
    {
        if (collision.gameObject == Player01)
        {
            owner = Player01;
            scoreMgr.IncrementPlayer01Score();
            rd.material = Player01OwnerMat;
        }
        else if (collision.gameObject == Player02)
        {
            owner = Player02;
            scoreMgr.IncrementPlayer02Score();
            rd.material = Player02OwnerMat;
        }
    }


}
