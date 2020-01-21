using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaunlet : MonoBehaviour
{
    public LineRenderer line;
    public LayerMask mask;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f, mask))
        {
            Debug.Log("Hit Target");
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, hit.point);
        }
        else
            line.enabled = false;
    }
}
