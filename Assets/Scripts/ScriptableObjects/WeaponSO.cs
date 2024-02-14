using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class WeaponSO : ScriptableObject
{
    public GameObject prefab;
    public float damage;
    public float speed;
    public float length;
}
