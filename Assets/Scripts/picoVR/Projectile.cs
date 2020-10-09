using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Weapon weapon;

    public virtual void Init(Weapon wp)
    {
        this.weapon = wp;
    }

    public virtual void Launch()
    {
        
    }

    /*public void OnCollideEnter(Collider other)
    {
        gameObject.SetActive(false);
    }*/
}
