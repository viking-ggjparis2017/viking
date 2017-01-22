using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossControls : MonoBehaviour {

    [SerializeField]
    private Rigidbody _ballBody = null;

    [SerializeField]
    private Ball _ballScript = null;

    [SerializeField]
    private float _tossRadius = 2f;

    [SerializeField]
    private CritRange[] _critRangePool = null;

    [Range(1, 2), SerializeField]
    private int playerNumber = 1;

    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Update () {
		if((playerNumber == 1 && Input.GetButtonDown("Stop_P1")) || (playerNumber == 2 && Input.GetButtonDown("Stop_P2")))
        {

            _animator.SetTrigger("TossTrigger");

            CritRange RangeItem = GetInactiveRange();
            if (RangeItem != null)
            {
                RangeItem.Place(transform.position);
            }

            if (IsBallInRange() && _ballScript.HasOwner())
            {

                var audioSource = transform.Find("Audio Source").GetComponent<AudioSource>();
                audioSource.clip = SoundManager.instance.FindClipByName("SFX_toss");
                audioSource.Play();

                _ballScript.Toss(playerNumber);
            }
        }
	}

    private bool IsBallInRange()
    {
        return Vector3.Distance(transform.position, _ballBody.transform.position) <= _tossRadius;
    }

    private CritRange GetInactiveRange()
    {
        foreach(CritRange rangeItem in _critRangePool)
        {
            if(!rangeItem.IsActive())
            {
                return rangeItem;
            }
        }

        return null;
    }
}
