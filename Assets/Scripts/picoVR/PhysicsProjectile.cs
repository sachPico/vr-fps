using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent((typeof(Rigidbody)))]
public class PhysicsProjectile : Projectile
{
    [SerializeField] private float _lifeTime;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Init(Weapon wp)
    {
        base.Init(wp);
        Destroy(gameObject, _lifeTime);
    }

    public override void Launch()
    {
        base.Launch();
        rb.AddRelativeForce(Vector3.forward * weapon.GetShootingForce(), ForceMode.Impulse);
    }

    public void OnCollideEnter(Collision other)
    {
        ITakeDamage[] damageTakers = other.gameObject.GetComponentsInChildren<ITakeDamage>();
        foreach (var dt in damageTakers)
        {
            dt.TakeDamage(weapon, this, transform.position);
        }

        if (other.gameObject.CompareTag("Destroyable"))
        {
            Destroy(gameObject);
        }
    }
}
