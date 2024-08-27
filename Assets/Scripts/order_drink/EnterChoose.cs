using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class EnterChoose : MonoBehaviour
{
    // 其他脚本
    public EmissionControl _emissionControl;
    public GameObject _thisHandGrab;
    public Transform head;
    private List<GameObject> handGrabs;
    private List<JuiceScript> juicesScripts;
    // 方法变量
    public List<Transform> _drinkPos = new List<Transform>();
    // public List<GameObject> _drinkPrefabs = new List<GameObject>();
    // 初始状态
    [SerializeField]
    private float duration = 1f;  // 动画持续时间
    [SerializeField]
    private Vector3 aimScale = new Vector3(0.4f, 0.4f, 0.4f);  // 动画持续时间
    private Vector3 initialPosition;
    private Vector3 initialScale;
    private Quaternion initialRotation;
    void Start()
    {
        initialPosition = transform.position;
        initialScale = transform.localScale;
        initialRotation = transform.rotation;
        RefreshList();
        foreach (var item in handGrabs)
        {
            item.SetActive(false);
        }
    }
    void Update()
    {
        foreach (var item in juicesScripts)
        {
            if (!item.onSale)
            {
                item.transform.SetParent(null);
                RefreshList();
            }
        }

    }
    public void EnterChooseDrink(bool enable)
    {
        // 移动物体位置到面前
        Vector3 headForward = head.forward;
        headForward.y = 0f;
        headForward.Normalize();
        Vector3 targetPos = head.position + headForward * 1f;
        Vector3 headRot = head.rotation.eulerAngles;
        headRot.x = -90f;

        if (enable)
        {
            transform.DOScale(aimScale, duration).SetEase(Ease.InOutQuad);
            transform.DOMove(targetPos, .5f).SetEase(Ease.InOutQuad);
            transform.DORotateQuaternion(Quaternion.Euler(headRot), duration).SetEase(Ease.InOutQuad);
            _thisHandGrab.SetActive(false);
            foreach (var item in handGrabs)
            {
                item.SetActive(true);
            }
        }
        else
        {
            transform.DOScale(initialScale, duration).SetEase(Ease.InOutQuad);
            transform.DOMove(initialPosition, duration).SetEase(Ease.InOutQuad);
            transform.DORotateQuaternion(initialRotation, duration).SetEase(Ease.InOutQuad);
            foreach (var item in handGrabs)
            {
                item.SetActive(false);
            }
            _thisHandGrab.SetActive(true);
        }

    }
    void RefreshList()
    {
        handGrabs = new List<GameObject>();
        juicesScripts = new List<JuiceScript>();
        foreach (var item in _drinkPos)
        {
            juicesScripts.Add(item.GetComponentInChildren<JuiceScript>());
            foreach (var i in item.GetComponentsInChildren<HandGrabInteractable>())
            {
                handGrabs.Add(i.gameObject);
            }
        }
    }

}
