using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveControls : MonoBehaviour {

    [SerializeField]
    private Rigidbody _playerRigidBody = null;

    [SerializeField]
    private Shockwave[] _shockwavePool = null;

    [Range(1, 2), SerializeField]
    private int playerNumber = 1;

    public void FixedUpdate () {
        if(Input.GetButtonDown("Fire_P1"))
        {
            Debug.Log("P1");
        }

        if(Input.GetButtonDown("Fire_P2"))
        {
            Debug.Log("P2");
        }

	    if( (playerNumber == 1 && Input.GetButtonDown("Fire_P1")) || (playerNumber == 2 && Input.GetButtonDown("Fire_P2")) )
        {
            Shockwave dropObject = FindShockwave();

            if(dropObject != null)
            {
                dropObject.SetOwner(playerNumber);
                dropObject.Drop(_playerRigidBody.position);
            }
        }
	}

    private Shockwave FindShockwave()
    {
        foreach(Shockwave dropObject in _shockwavePool)
        {
            if(dropObject.IsActive() == false)
            {
                return dropObject;
            }
        }

        return null;
    }
}
