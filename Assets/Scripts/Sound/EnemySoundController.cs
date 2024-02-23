using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySoundController : MonoBehaviour
{
    [SerializeField] EnemySoundSO enemySoundSO;
    [SerializeField] float enemyWalkTime=.5f;
    [SerializeField] float enemyRunTime = .3f;


    private float timer=0;
    private float volume=1f;

    private ISoundService soundService;

    private void Awake()
    {
        soundService=new SoundManager();
    }

    public void PlayEnemyWalkSound()
    {
        timer += Time.deltaTime;

        if (timer > enemyWalkTime)
        {
            timer = 0;

            //soundService.PlaySound(enemySoundSO.walkClips, transform.position, volume);
        }
    }

    public void PlayEnemyRunSound()
    {
        timer += Time.deltaTime;

        if (timer > enemyRunTime)
        {
            timer = 0;

           // soundService.PlaySound(enemySoundSO.walkClips, transform.position, volume);
        }
    }

    public void PlayEnemyAttackSound()
    {
        //soundService.PlaySound(enemySoundSO.attackClips, transform.position, volume);

    }

    public void PlayEnemyHitSound()
    {
       // soundService.PlaySound(enemySoundSO.hitClips, transform.position, volume);

    }

    public void PlayEnemyDeathSound()
    {
       // soundService.PlaySound(enemySoundSO.deathClips, transform.position, volume);

    }
}
