using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SemiAutoBehaviour : Weapon
{
    [SerializeField] private float fireRate;
    [SerializeField] private Projectile bulletObject;
    private bool isShoot = false;
    protected override void StartShoot(XRBaseInteractor interactor)
    {
        base.StartShoot(interactor);
        isShoot = true;
        StartCoroutine(SemiAutoShoot(interactor));
    }

    protected override void StopShoot(XRBaseInteractor interactor)
    {
        base.StopShoot(interactor);
        isShoot = false;
        StopCoroutine(SemiAutoShoot(interactor));
    }

    IEnumerator SemiAutoShoot(XRBaseInteractor interactor)
    {
        while (isShoot)
        {
            base.Shoot(interactor);
            Projectile projectileInstance = Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);
            projectileInstance.Init(this);
            projectileInstance.Launch();
            yield return new WaitForSeconds(fireRate);
        }
    }
}
