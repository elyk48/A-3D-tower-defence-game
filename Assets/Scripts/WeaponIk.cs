using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIk : MonoBehaviour
{
    static  Transform TargetTransform;
  Transform aimTransform;
    public Transform bone;
    int iterations = 10;
    public bool isfiring = false;
    [Range(0,1)]
     public float weight = 1.0f;
    public float angleLimit = 90.0f;
    public float distanceLimit =1.5f;
    //Projectile
    public ParticleSystem muzzelFlash;
    public ParticleSystem hitEffect;
    public TrailRenderer tracerEffect;
     GameObject raycastOrigin;
    GameObject brain;
    BrainController bC;
    Ray ray;
    RaycastHit hitInfo;
    // Start is called before the first frame update
    void Start()
    {
        raycastOrigin = GameObject.FindGameObjectWithTag("Raycast");
        brain = GameObject.FindGameObjectWithTag("Brain");
        bC = brain.GetComponent<BrainController>();
    }

    private void LateUpdate()
        
    {
        if (aimTransform == null)
        {
            return;
        }
        if (TargetTransform == null)
        {
            return;
        }
            Vector3 targetPosition = GetTargetPosition();
        for (int i = 0; i < iterations; i++)
        {
            AimTarget(bone, targetPosition, weight);
        }
        
        
    }
    Vector3 GetTargetPosition()
    {
        Vector3 targetDirection = TargetTransform.position - aimTransform.position;
        Vector3 aimDirection = -aimTransform.right;
        float blendout = 0.0f;
        float targetAngle = Vector3.Angle(targetDirection, aimDirection);
        if (targetAngle>angleLimit)
        {
            blendout += (targetAngle - angleLimit) / 50.0f;
        }
        Vector3 direction = Vector3.Slerp(targetDirection, aimDirection, blendout);
        return aimTransform.position + direction;
    }

    private void AimTarget(Transform bone, Vector3 targetPosition,float weight)
    {
        Vector3 aimDirection = -aimTransform.right;
        Vector3 targetDirection = targetPosition - aimTransform.position;
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        Quaternion blendRotation = Quaternion.Slerp(Quaternion.identity, aimTowards, weight);
        bone.rotation = blendRotation * bone.rotation;
    }

    public void SetaimTransform(Transform aim)
    {
        aimTransform = aim;

    }
    public static void  SetTargetTransform(Transform target)
    {
        TargetTransform = target;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startfiring()
    {
        isfiring = true;
        muzzelFlash.Emit(1);

        ray.origin = raycastOrigin.transform.position;
        ray.direction = -raycastOrigin.transform.right;
        var tracer = Instantiate(tracerEffect, ray.origin, Quaternion.identity);
        tracer.AddPosition(ray.origin);
      if (Physics.Raycast(ray,out hitInfo)){
            if (hitInfo.collider.CompareTag("Brain"))
            {
                hitEffect.transform.position = hitInfo.point;
                hitEffect.transform.forward = hitInfo.normal;
                hitEffect.Emit(2);
                tracer.transform.position = hitInfo.point;
                bC.applyDamage();

            }
            //Debug.DrawLine(ray.origin, hitInfo.point,Color.green,1.0f);
        }

    }
    public void stopfiring()
    {
        isfiring = false;
    }
}
