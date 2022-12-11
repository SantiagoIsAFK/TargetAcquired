using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCoreFeedback : MonoBehaviour
{

    [SerializeField] private AudioClip startClip, scoreClip, finishClip;
    public NaveTopDownCore core;
    private AudioSource source;
    protected void Awake()
    {
        source = GetComponent<AudioSource>();

        core.OnStartGame.AddListener(() => { source.PlayOneShot(startClip); });
        core.OnUpdateScore.AddListener(() => { source.PlayOneShot(scoreClip); });
        core.OnFinishGame.AddListener(() => { source.PlayOneShot(finishClip); });
    }

}

