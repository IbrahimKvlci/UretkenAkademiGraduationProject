using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoundService 
{
    void PlaySound(List<AudioClip> audioClipList, Vector3 position,float volume, float volumeMultiplier = 1f);
}
