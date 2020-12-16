using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleKiller : MonoBehaviour
{
    public float duration;
    void Awake()
    {
        Destroy(gameObject,duration);
    }
}
