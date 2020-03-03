using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerData;
    public UnityEvent onRecognized;
}

public class GestureDetector : MonoBehaviour
{
    public float threshold = .1f;
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;

    private List<OVRBone> fingerBones;

    public bool debugMode;

    Gesture previousGesture;

    private void Start()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
        previousGesture = new Gesture();
    }

    private void Update()
    {
        if (debugMode && Input.GetKeyDown(KeyCode.Space))
            SaveGesture();

        Gesture currentGesture = Recognize();
        bool hasRecognized = !currentGesture.Equals(new Gesture());

        if(hasRecognized) // && !currentGesture.Equals(previousGesture)
        {
            Debug.Log("New Gesture Found: " + currentGesture.name);
            previousGesture = currentGesture;
            currentGesture.onRecognized.Invoke();
        }
    }

    public void SaveGesture()
    {
        Gesture g = new Gesture();
        g.name = "New Gesture";
        List<Vector3> data = new List<Vector3>();

        foreach(OVRBone bone in fingerBones)
        {
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        g.fingerData = data;
        gestures.Add(g);
    }

    Gesture Recognize()
    {
        Gesture currentGesture = new Gesture();
        float currentMin = Mathf.Infinity;

        foreach(Gesture gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;

            for(int i = 0; i < fingerBones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.fingerData[i]);

                if(distance > threshold)
                {
                    isDiscarded = true;
                    break;
                }

                sumDistance += distance;
            }

            if(!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currentGesture = gesture;
            }
        }
        return currentGesture;
    }
}
