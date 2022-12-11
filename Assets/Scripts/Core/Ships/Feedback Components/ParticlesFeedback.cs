using UnityEngine;

public class ParticlesFeedback : FeedbackShip
{
    [SerializeField] private ParticleSystem bornParticles, shootParticles, deadParticles;

    protected override void Awake()
    {
        base.Awake();

        ship.OnBorn.AddListener(() => { bornParticles.Play(); });
        ship.OnShoot.AddListener(() => { shootParticles.Play(); });
        ship.OnDead.AddListener(() => { deadParticles.Play(); });
    }

}

