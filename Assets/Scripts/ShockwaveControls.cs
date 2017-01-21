using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveControls : MonoBehaviour {

    [SerializeField]
    private Rigidbody _playerRigidBody = null;

    [SerializeField]
    private Shockwave[] _shockwavePool = null;

    [Range(1, 2), SerializeField]
    int playerNumber = 1;
    string fireName;

    void Start()
    {
        fireName = "Fire_P" + playerNumber.ToString();
    }

    public void FixedUpdate () {
	    if( Input.GetButtonDown(fireName) )
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
