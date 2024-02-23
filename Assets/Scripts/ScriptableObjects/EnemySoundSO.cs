using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemySoundSO : ScriptableObject
{
    public List<AudioClip> walkClips;
    public List<AudioClip> runClips;
    public List<AudioClip> attackClips;
    public List<AudioClip> hitClips;
    public List<AudioClip> deathClips;

    public AudioClip enemyIdleSound;
}
