using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITakeDamage
{
    void TakeDamage(Weapon wp, Projectile pr, Vector3 contactPoint);
}
