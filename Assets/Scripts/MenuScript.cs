using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // public DistanceHandGrabInteractor _rightDistanceHandGrabInteractor;
    // public DistanceHandGrabInteractor _leftDistanceHandGrabInteractor;
    public Transform head;
    private bool menuShowing = false;

    public void ShowMenu(bool enable)
    {
        Vector3 headForward = head.forward;
        headForward.y = 0f;
        headForward.Normalize();
        Vector3 spawnPos = head.position + headForward * 0.5f;

        if (enable)
        {
            transform.DOMove(spawnPos, .5f).SetEase(Ease.InOutQuad);
            transform.forward = headForward;
            menuShowing = true;
        }
        else
        {
            Vector3 hidePos = head.position + Vector3.down * 5f;
            transform.DOMove(hidePos, .5f).SetEase(Ease.InOutQuad);
            menuShowing = false;
        }
    }
    public void JoinTable()
    {
        Debug.Log("加入房间");
        ShowMenu(false);
    }
}
