using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private GameObject replacement;
    private bool broken = false;
    [SerializeField] private float breakForce = 2f;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    private void Update()
    {
        if (broken)
            return;
        if (Input.GetKey(KeyCode.Space))
        {
            BreakCube();
        }
    }

    private void BreakCube()
    {
        var replacement = Instantiate(this.replacement, transform.position, transform.rotation);
        var rbs = replacement.GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rbs)
        {
            rb.AddExplosionForce(400, transform.position, 2);
        }
        Destroy(gameObject);
        broken = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (broken)
            return;
        if (other.relativeVelocity.magnitude >= breakForce)
        {
            broken = true;
            BreakCube();
        }
    }
}
