using UnityEngine;


public class AnimatorFeedback : FeedbackShip
{
    private Animator anim;

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();

        ship.OnBorn.AddListener(() => { anim.SetTrigger("Born"); });
        ship.OnShoot.AddListener(() => { anim.SetTrigger("Shoot"); });
        ship.OnDead.AddListener(() => { anim.SetTrigger("Dead"); });
    }

}

