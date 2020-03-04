using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeCause : BinaryCause
{
    public float gazeRadius = .5f;
    public LayerMask interactionLayer;

    Transform gazeTarget;
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, gazeRadius, out hit, 150f, interactionLayer))
        {
            Transform target = hit.transform;

            if(target != gazeTarget)
            {
                gazeTarget = target;
                ActivateEffects();
            }
        }
        else if(gazeTarget)
        {
            DeactivateEffects();
            gazeTarget = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, gazeRadius);
    }
}
