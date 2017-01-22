using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    [SerializeField]
    public List<AudioClip> audioClip;

    // Use this for initialization
    void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public AudioClip FindClipByName(string name)
    {
        foreach (var clip in audioClip)
            if (clip.name == name)
                return clip;

        return null;
    }
}
