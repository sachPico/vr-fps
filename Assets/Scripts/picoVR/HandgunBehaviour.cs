using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandgunBehaviour : Weapon
{
    [SerializeField] private Projectile bulletObject;
    protected override void StartShoot(XRBaseInteractor interactor)
    {
        base.StartShoot(interactor);
        Shoot(interactor);
    }

    protected override void StopShoot(XRBaseInteractor interactor)
    {
        base.StopShoot(interactor);
    }
    
    protected override void Shoot(XRBaseInteractor interactor)
    {
        base.Shoot(interactor);
        Projectile projectileInstance = Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);
        projectileInstance.Init(this);
        projectileInstance.Launch();
    }
}
