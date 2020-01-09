﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    Controller control;
    public bool holding = false;
    Collider held;
    bool lastFrameTrigger;
    bool trigger;
    Rigidbody body;
    [SerializeField] float throwStrength;
    [SerializeField] float rotationStrength = .75f;
    Quaternion lastRotation, currentRotation;

    private void Start()
    {
        control = GetComponent<Controller>();
    }

    void Update()
    {
        lastFrameTrigger = trigger;
        OVRInput.Update();
        trigger = control.controller == OVRInput.Controller.LTouch
                ? OVRInput.Get(OVRInput.Button.Any)
                : OVRInput.Get(OVRInput.Button.Any);

        if (holding)
        {
            lastRotation = currentRotation;
            if(held)
            currentRotation = held.transform.rotation;
        }

        if (control.touching.Length > 0 && control.touching[0].tag == "Grabbable")
        {
            if (!holding && !lastFrameTrigger && trigger) // pick up
            {
                holding = true;
                held = control.touching[0];

                if (held.gameObject == PutBulbOnSocket.Instance.oldBulb) return;

                held.transform.position = transform.position;
                held.transform.parent = transform;
                body = held.GetComponent<Rigidbody>();
                body.useGravity = false;
                body.isKinematic = true;
            }
            else if (holding && !trigger) // drop
            {
                holding = false;

                if(held)
                held.transform.parent = null;
                body.useGravity = true;
                body.isKinematic = false;
                body.velocity = OVRInput.GetLocalControllerVelocity(control.controller) * throwStrength;
                body.angularVelocity = GetAngularVelocity();
                body = null;
            }
        }
    }

    Vector3 GetAngularVelocity()
    {
        Quaternion deltaRotation = currentRotation * Quaternion.Inverse(lastRotation);
        return new Vector3(Mathf.DeltaAngle(0, deltaRotation.eulerAngles.x), Mathf.DeltaAngle(0, deltaRotation.eulerAngles.y), Mathf.DeltaAngle(0, deltaRotation.eulerAngles.z)) * rotationStrength;
    }
}