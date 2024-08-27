using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    public GameObject smokePrefab;
    public float duration = 0.5f;
    public float lifeTime = 1f;
    public Transform _headPos;
    public float detectDistance = 0.3f;
    public Transform head;
    public Transform tail;
    private bool smoked = false;
    protected virtual void Update()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem _particleSystem = smokePrefab.GetComponent<ParticleSystem>();
        var ps = _particleSystem.main;
        ps.duration = duration;
        ps.startLifetime = lifeTime;
    }
    public void Smoke()
    {
        Vector3 headForward = _headPos.forward;
        headForward.y = 0f;
        headForward.Normalize();
        Vector3 spawnPos = _headPos.position + headForward * 0.1f;
        GameObject _smokeRef = Instantiate(smokePrefab, spawnPos, _headPos.rotation);
        // 销毁物体
        Destroy(_smokeRef, duration + lifeTime);
    }
    public void SmokeOnCondition()
    {
        if (Vector3.Distance(head.position, tail.position) < detectDistance && !smoked)
        {
            smoked = true;
            Vector3 headForward = _headPos.forward;
            headForward.y = 0f;
            headForward.Normalize();
            Vector3 spawnPos = _headPos.position + headForward * 0.1f;
            GameObject _smokeRef = Instantiate(smokePrefab, spawnPos, _headPos.rotation);
            // 销毁物体
            Destroy(_smokeRef, duration + lifeTime);
        }
        if(Vector3.Distance(head.position, tail.position) > detectDistance)
        {
            smoked = false;
        }
    }
}
