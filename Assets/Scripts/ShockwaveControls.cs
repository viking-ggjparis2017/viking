using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveControls : MonoBehaviour {

    [SerializeField]
    private Rigidbody _playerRigidBody = null;

    [SerializeField]
    private Shockwave[] _shockwavePool = null;

    [SerializeField]
    private PlayerMouvement _movementScript = null;

    [Range(1, 2), SerializeField]
    private int playerNumber = 1;

    Animator _animator;

    public void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void FixedUpdate () {
	    if( (playerNumber == 1 && Input.GetButtonDown("Fire_P1")) || (playerNumber == 2 && Input.GetButtonDown("Fire_P2")) )
        {
            Shockwave dropObject = FindShockwave();

            if(dropObject != null)
            {
                _animator.SetTrigger("JumpTrigger");

                dropObject.SetOwner(playerNumber);
                dropObject.Drop(_playerRigidBody.position);
                _movementScript.StopControl(0.25f);
                
                //_animator.ResetTrigger("JumpTrigger");
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
