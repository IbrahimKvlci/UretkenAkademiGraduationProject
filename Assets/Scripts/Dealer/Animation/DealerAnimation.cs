using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerAnimation : MonoBehaviour
{
    [SerializeField] private int IdleCounterMax;
    [SerializeField] private float timerMax;

    public int IdleCounter { get; set; }

    private float timer;

    private Animator animator;

    
    public enum DealerAnimationConditions
    {
        IdleOther,
        IdleOtherCounter
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer+= Time.deltaTime;
        if (timer > timerMax)
        {
            timer = 0;
            PlayRandomIdleOther();
        }
    }

    private void PlayRandomIdleOther()
    {
        IdleCounter = Random.Range(0, IdleCounterMax);
        animator.SetInteger(DealerAnimationConditions.IdleOtherCounter.ToString(), IdleCounter);
        animator.SetTrigger(DealerAnimationConditions.IdleOther.ToString());

    }
}
