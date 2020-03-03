using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{
    public Transform ovrHand;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        transform.parent = ovrHand.Find("Hand_IndexTip").transform;
    }
}
