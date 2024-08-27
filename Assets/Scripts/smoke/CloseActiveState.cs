using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class CloseActiveState : MonoBehaviour, IActiveState
{
    private bool mActive;
    public float detectDistance = 0.5f;
    public Transform head;
    public Transform tail;
    public bool Active => mActive;
    protected virtual void Update()
    {
        mActive = Vector3.Distance(head.position, tail.position) < detectDistance;
    }

}
