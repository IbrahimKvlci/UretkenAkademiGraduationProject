using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController:MonoBehaviour
{
    [SerializeField] private PlayerSoundSO playerSoundSO;

    private float volume = 1f;

    [SerializeField] private float playerWalkTime=0.5f;
    private float timer = 0;


    private ISoundService soundService;

    private void Awake()
    {
        soundService = new SoundManager();
    }

    public void PlayPlayerWalkSound(Vector3 position)
    {
        timer += Time.deltaTime;

        if (timer > playerWalkTime)
        {
            timer = 0;

            soundService.PlaySound(playerSoundSO.walkClips, position, volume);
        }
    }

    public void PlayPlayerAttackSound(Vector3 position)
    {
        soundService.PlaySound(playerSoundSO.attackClips, position, volume);
    }

    public void PlayPlayerDashSound(Vector3 position)
    {
        soundService.PlaySound(playerSoundSO.dashClips, position, volume);
    }

    public void PlayPlayerFireSkillSound(Vector3 position)
    {
        soundService.PlaySound(playerSoundSO.fireSkillClips, position, volume);
    }

    public void PlayPlayerHitSound(Vector3 position)
    {
        soundService.PlaySound(playerSoundSO.attackClips, position, volume);
    }

    public void PlayPlayerDeathSound(Vector3 position)
    {
        soundService.PlaySound(playerSoundSO.deathClips, position, volume);
    }
}
