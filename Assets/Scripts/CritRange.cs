using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritRange : MonoBehaviour {

    [SerializeField]
    private Transform _selfTransform = null;

    [SerializeField]
    private float _lifeTime = 0.25f;

    private float _timer = 0f;

    private bool _isActive = false;

	// Use this for initialization
	public void Start () {
        gameObject.SetActive(false);
	}

    public void Update()
    {
        if(_isActive == false)
        {
            return;
        }

        _timer += Time.deltaTime;
        
        if(_timer > _lifeTime)
        {
            gameObject.SetActive(false);
            _isActive = false;
        }
    }

	public void Place (Vector3 position) {
        position.y -= 1;
        _selfTransform.position = position;
        gameObject.SetActive(true);
        _timer = 0f;
        _isActive = true;
	}

    public bool IsActive()
    {
        return _isActive;
    }
}
