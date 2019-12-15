﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Transform leftController;
    public Transform rightController;

    public VRTeleporter leftTeleporter;
    public VRTeleporter rightTeleporter;

    bool leftCast;
    bool rightCast;

    Vector3? targetPosition;
    private void Update()
    {

        float left = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).magnitude;
        float right = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).magnitude;

        if (left != 0)
        {
            leftCast = true;
            leftTeleporter.ToggleDisplay(true);
        }
        else if(leftCast)
        {
            leftCast = false;
            leftTeleporter.Teleport();
            leftTeleporter.ToggleDisplay(false);
        }

        if (right != 0)
        {
            rightCast = true;
            rightTeleporter.ToggleDisplay(true);
        }
        else if (rightCast)
        {
            rightCast = false;
            rightTeleporter.Teleport();
            rightTeleporter.ToggleDisplay(false);
        }
    }

    void Cast(Transform controller, LineRenderer line)
    {
        RaycastHit hit;
        if (Physics.Raycast(controller.position, controller.forward, out hit, Mathf.Infinity))
        {
            line.SetPosition(0, controller.position);
            line.SetPosition(1, hit.point);

            if (hit.transform.tag.Equals("Ground"))
            {
                line.startColor = Color.green;
                line.endColor = Color.green;

                targetPosition = hit.point;
            }
            else
            {
                line.startColor = Color.red;
                line.endColor = Color.red;
                targetPosition = null;
            }
        }
    }
}
