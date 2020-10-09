/*
TODO:
- Bullet spawn system must be replaced with object pool system. Instantiation is not efficient
- Ensure the future object pool can be used easily for other TicTech developer
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Weapon : MonoBehaviour
{
    //public GameObject test;
    
    [SerializeField] protected float shootingForce;
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] protected float _recoilForce = new float();
    [SerializeField] protected float _shotDamage = new float();
    [SerializeField] private float recoilResetRate;

    private Rigidbody _rb;
    private XRGrabInteractable _interactableWeapon;
    [SerializeField] private static Vector3 definedRecoilVector = Vector3.zero;
    [SerializeField] private float recoilDampTime;
    [SerializeField] private Transform customAttachPointTransform;

    private Vector3 newRecoilDirection = Vector3.zero;

    private Vector3 testRecoilEuler = Vector3.zero;
    private Quaternion testRecoilQuaternion = new Quaternion(0,0,0,1);

    protected virtual void Awake()
    {
        _interactableWeapon = GetComponent<XRGrabInteractable>();
        _rb = GetComponent<Rigidbody>();
        SetupInteractableEvents();
        customAttachPointTransform = GameObject.Find("RightHand Interactor").transform.GetChild(1);
        //definedRecoilVector = customAttachPointTransform.forward;
    }

    private void SetupInteractableEvents()
    {
        _interactableWeapon.onSelectEnter.AddListener(GrabbedBehaviour);
        _interactableWeapon.onSelectExit.AddListener(ReleasedBehaviour);
        _interactableWeapon.onActivate.AddListener(StartShoot);
        _interactableWeapon.onDeactivate.AddListener(StopShoot);
    }

    private void GrabbedBehaviour(XRBaseInteractor interactor)
    {
        //interactor.GetComponent<MeshHider>().HideChildMeshRenderers();
    }
    
    private void ReleasedBehaviour(XRBaseInteractor interactor)
    {
        //interactor.GetComponent<MeshHider>().ShowChildMeshRenderers();
    }
    
    protected virtual void StartShoot(XRBaseInteractor interactor)
    {
        //throw new NotImplementedException();
    }
    
    protected virtual void StopShoot(XRBaseInteractor interactor)
    {
        definedRecoilVector = Vector3.zero;
        //throw new NotImplementedException();
    }

    protected virtual void Shoot(XRBaseInteractor interactor)
    {
        definedRecoilVector.y += _recoilForce / _rb.mass;
        Debug.Log(definedRecoilVector.y);
        ApplyRecoil(interactor);
    }

    private void ApplyRecoil(XRBaseInteractor interactor)
    {
    }

    public float GetShootDamage()
    {
        return _shotDamage;
    }

    public float GetShootingForce()
    {
        return shootingForce;
    }

    private void Update()
    {
        //customAttachPointTransform.localRotation = Quaternion.FromToRotation(Vector3.forward, definedRecoilVector);
        newRecoilDirection = customAttachPointTransform.parent.forward + customAttachPointTransform.parent.up*definedRecoilVector.y;
        definedRecoilVector.y = Mathf.Lerp(definedRecoilVector.y, 0, recoilResetRate * Time.deltaTime);
        customAttachPointTransform.rotation = Quaternion.LookRotation(newRecoilDirection, Vector3.Cross(customAttachPointTransform.parent.right, -newRecoilDirection));
        //testRecoilQuaternion.x = testRecoilQuaternion.x > 1 ? -1 : testRecoilQuaternion.x;
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(customAttachPointTransform.TransformPoint((newRecoilDirection)), .1f);
        }
    }
}
