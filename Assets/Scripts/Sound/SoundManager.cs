using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : ISoundService
{
    public void PlaySound(List<AudioClip> audioClipList, Vector3 position,float volume, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClipList[Random.Range(0, audioClipList.Count)], position, volumeMultiplier * volume);
    }
}
