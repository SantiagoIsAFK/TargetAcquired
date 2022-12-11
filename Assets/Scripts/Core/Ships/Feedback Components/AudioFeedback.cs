using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFeedback : FeedbackShip
{

    [SerializeField] private AudioClip bornClip, shootClip, deadClip;
    private AudioSource source;
    protected override void Awake()
    {
        base.Awake();
        source = GetComponent<AudioSource>();

        ship.OnBorn.AddListener(() => { source.PlayOneShot(bornClip); });
        ship.OnShoot.AddListener(() => { source.PlayOneShot(shootClip); });
        ship.OnDead.AddListener(() => { source.PlayOneShot(deadClip); });
    }

}

