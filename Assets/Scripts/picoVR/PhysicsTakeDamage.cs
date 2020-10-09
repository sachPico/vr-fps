using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsTakeDamage : MonoBehaviour, ITakeDamage
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void TakeDamage(Weapon wp, Projectile p, Vector3 pos)
    {
        rb.AddForce(p.transform.forward * wp.GetShootingForce(), ForceMode.Impulse);
    }
}
