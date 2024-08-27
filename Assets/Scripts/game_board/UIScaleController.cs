using DG.Tweening;
using Oculus.Interaction;
using UnityEngine;

public class UIScaleController : MonoBehaviour
{
    public Transform _leftHand;
    public Transform _rightHand;
    public Transform _gameBoard;
    private float distancePre;
    private float distanceNext;
    public ActiveStateGroup _selectState;
    private bool _active = false;
    public Transform head;

    private void Start()
    {
        distanceNext = Vector3.Distance(_leftHand.position, _rightHand.position);
        distancePre = Vector3.Distance(_leftHand.position, _rightHand.position);
    }

    void Update()
    {
        if (_active)
        {
            distanceNext = Vector3.Distance(_leftHand.position, _rightHand.position);
            float distanceDelta = distanceNext - distancePre;
            _gameBoard.DOScale(distanceDelta * 3 + _gameBoard.localScale.x, 0.1f).SetEase(Ease.OutBounce);
            distancePre = distanceNext;
        }
        Vector3 headForward = head.forward;
        headForward.y = 0f;
        headForward.Normalize();
        Vector3 spawnPos = head.position + headForward;
        _gameBoard.DOMove(spawnPos, .5f).SetEase(Ease.InOutQuad);
        _gameBoard.forward = headForward;
    }
    public void RecordEvent(bool isRecording)
    {
        if (isRecording)
        {
            _active = true;
            distanceNext = Vector3.Distance(_leftHand.position, _rightHand.position);
            distancePre = Vector3.Distance(_leftHand.position, _rightHand.position);
        }
        else
        {
            _active = false;
        }

    }
}
