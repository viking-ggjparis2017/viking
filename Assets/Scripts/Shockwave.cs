using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour {

    [SerializeField]
    private float _lifetime = 1f;

    [SerializeField]
    private float _maxRadius = 10f;

    [SerializeField]
    private float _force = 100f;

    [SerializeField]
    private float _critRadius = 1f;

    [SerializeField]
    private float _critMultiplier = 1.5f;

    [SerializeField]
    private Transform _selfTransform = null;

    [SerializeField]
    private GameObject _selfObject = null;

    [SerializeField]
    private Rigidbody _selfRigidBody = null;

    private bool _active = false;

    private float _currentLifeTime = 0f;
    private Vector3 _startScale = new Vector3(0f, 1f, 0f);
    private Vector3 _endScale = new Vector3(0f, 1f, 0f);

    public void Start()
    {
        _selfObject.SetActive(false);
        _endScale.x = _maxRadius;
        _endScale.z = _maxRadius;
    }
	
	public void FixedUpdate() {
		if (!_active)
        {
            return;
        }

        _currentLifeTime += Time.fixedDeltaTime;

        if (_currentLifeTime >= _lifetime)
        {
            _selfObject.SetActive(false);
            _active = false;
        }

        _selfTransform.localScale = Vector3.Lerp(_startScale, _endScale, _currentLifeTime / _lifetime);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.GetComponent<Rigidbody>().AddExplosionForce(_force, _selfRigidBody.position, _maxRadius);
        }
    }

    public void Drop(Vector3 dropPosition)
    {
        _currentLifeTime = 0f;
        _selfTransform.position = dropPosition;
        _selfTransform.localScale = _startScale;

        _active = true;
        _selfObject.SetActive(true);
    }

    public bool IsActive()
    {
        return _active;
    }
}
