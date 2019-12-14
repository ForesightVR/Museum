﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform leftController;
    public Transform rightController;

    public LineRenderer lLine;
    public LineRenderer rLine;

    public GameObject indicator;

    bool leftCast;
    bool rightCast;

    Vector3? targetPosition;

    private void Update()
    {
        float left = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).magnitude;
        float right = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).magnitude;

        if (left != 0)
        {
            leftCast = true;
            lLine.enabled = true;
            Cast(leftController, lLine);
        }
        else if(leftCast)
        {
            leftCast = false;
            lLine.enabled = false;
            if (targetPosition != null)
                transform.position = (Vector3)targetPosition;

            indicator.SetActive(false);
        }

        if (right != 0)
        {
            rightCast = true;
            rLine.enabled = true;
            Cast(rightController, rLine);
        }
        else if(rightCast)
        {
            rightCast = false;
            rLine.enabled = false;
            if (targetPosition != null)
                transform.position = (Vector3)targetPosition;

            indicator.SetActive(false);
        }
    }

    void Cast(Transform controller, LineRenderer line)
    {
        RaycastHit hit;
        if (Physics.Raycast(controller.position, controller.forward, out hit, Mathf.Infinity))
        {
            indicator.SetActive(true);
            line.SetPosition(0, controller.position);
            line.SetPosition(1, hit.point);

            if (hit.transform.tag.Equals("Ground"))
            {
                line.startColor = Color.green;
                line.endColor = Color.green;

                targetPosition = hit.point;

                indicator.transform.position = hit.point + (Vector3.up * .05f);
                indicator.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
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
