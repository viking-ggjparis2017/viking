using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveControls : MonoBehaviour {

    [SerializeField]
    private Rigidbody _playerRigidBody = null;

    [SerializeField]
    private Shockwave[] _shockwavePool = null;

	// Update is called once per frame
	public void FixedUpdate () {
	    if(Input.GetKeyDown("space"))
        {
            Shockwave dropObject = FindShockwave();

            if(dropObject != null)
            {
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
