using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlayerSoundSO : ScriptableObject
{
    public List<AudioClip> walkClips; 
    public List<AudioClip> attackClips;
    public List<AudioClip> dashClips;
    public List<AudioClip> fireSkillClips;
    public List<AudioClip> hitClips;
    public List<AudioClip> deathClips;
}
