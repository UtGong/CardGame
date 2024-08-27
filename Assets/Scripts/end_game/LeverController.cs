using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class LeverController : MonoBehaviour
{
    public Light _light; // 指向光源的引用
    public float fadeDuration = 1f; // 渐暗持续时间
    public AudioSource _audio; // 指向音频源的引用
    public Transform _leverTop;
    public event Action<float> OnFloatValueChanged;
    private bool acted = false;
    private float _myFloat;

    public float MyFloat
    {
        get { return _myFloat; }
        set
        {
            if (Math.Abs(_myFloat - value) > Mathf.Epsilon) // 当 float 值发生变化时
            {
                _myFloat = value;
                OnFloatValueChanged?.Invoke(_myFloat); // 触发事件
            }
        }
    }
    private void Start()
    {
        OnFloatValueChanged += HandleFloatValueChanged;
    }
    private void Update()
    {
        float rot = _leverTop.localRotation.eulerAngles.x;
        MyFloat = rot;
        Debug.LogWarning(MyFloat);
    }

    private void HandleFloatValueChanged(float newValue)
    {
        //应用退出的代码
        if (newValue > 300f && newValue < 350f && !acted)
        {
            _light.DOIntensity(0f, fadeDuration);
            acted = true;
            _audio.Play();
        }
        else if (acted && newValue < 180f)
        {
            _light.DOIntensity(1f, fadeDuration);
            acted = false;
            _audio.Play();
        }
        Debug.Log("退出");
    }

    private void OnDestroy()
    {
        OnFloatValueChanged -= HandleFloatValueChanged;
    }
}