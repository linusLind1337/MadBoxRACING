using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakMoment : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        source.PlayOneShot(clip);
    }
}
