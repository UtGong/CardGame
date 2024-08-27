using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HitController : MonoBehaviour
{
    public bool _isTrigger;
    public List<AudioSource> audioSources;
    public GameObject cardPrefab;
    public Transform generatePoint;
    public Transform endPoint;

    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        // 确保碰撞物体有特定标签或组件，可以根据需要调整条件
        // if (other.CompareTag("Player"))
        _isTrigger = true;

    }
    private void OnTriggerExit(Collider other)
    {
        _isTrigger = false;

    }
    public void Hit()
    {
        if (_isTrigger)
        {
            if (endPoint.childCount > 0)
            {
                Destroy(endPoint.GetChild(0).gameObject);
            }
            PlayRandomAudio();
            //发牌
            var card = Instantiate(cardPrefab, generatePoint);
            card.transform.DOMove(endPoint.position, 0.5f).SetEase(Ease.InOutQuad);
            card.transform.SetParent(endPoint);
        }
    }

    public void PlayRandomAudio()
    {
        if (audioSources == null || audioSources.Count == 0)
        {
            Debug.LogWarning("No AudioSource available to play.");
            return;
        }

        int randomIndex = Random.Range(0, audioSources.Count);
        AudioSource randomAudio = audioSources[randomIndex];

        if (randomAudio != null)
        {
            randomAudio.Play();
        }
        else
        {
            Debug.LogWarning("Selected AudioSource is null.");
        }
    }
}
