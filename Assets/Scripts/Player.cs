using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class Player : MonoBehaviour
{
    public Transform leftController;
    public Transform rightController;

    public VRTeleporter leftTeleporter;
    public VRTeleporter rightTeleporter;

    bool leftCast;
    bool rightCast;

    Vector3? targetPosition;

    InputDevice leftHandDevice;
    InputDevice rightHandDevice;

    private void Start()
    {



        //var leftHandDevices = new List<InputDevice>();
        //InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandDevices);
        //leftHandDevice = leftHandDevices[0];

        //var rightHandDevices = new List<InputDevice>();
        //InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);
        //rightHandDevice = rightHandDevices[0];
    }
    private void Update()
    {
        leftHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        leftHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 left); 
        rightHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 right);

        if (left.magnitude != 0)
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

        if (right.magnitude != 0)
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
