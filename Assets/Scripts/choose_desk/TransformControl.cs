// 用在远距离选择的物体上，实现缩放、倾斜、高度变化等动画效果。

using UnityEngine;
using DG.Tweening;

public class TransformControl : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(0.3f, 0.3f, 0.3f);  // 目标缩放大小
    public float targetHeight = 0.2f;  // 目标高度
    public float duration = 1f;  // 动画持续时间
    public float maxTiltAngle = 20f;  // 最大倾斜角度+23

    public Vector3 initialPosition;
    public Vector3 initialScale;
    public Quaternion initialRotation;
    public bool hasRun;

    void Start()
    {
        initialPosition = transform.position;
        initialScale = transform.localScale;
        initialRotation = transform.rotation;
    }

    public void EnlargeAndLift()
    {
        if (!hasRun)
        {
            // 随机生成倾斜角度
            float randomTiltX = Random.Range(-maxTiltAngle, maxTiltAngle);
            float randomTiltZ = Random.Range(-maxTiltAngle, maxTiltAngle);
            Quaternion randomTilt = Quaternion.Euler(-90+randomTiltX, 0, randomTiltZ);

            // 同时执行放大、升高和倾斜动画
            transform.DOScale(targetScale, duration).SetEase(Ease.InOutQuad);
            transform.DOMoveY(initialPosition.y + targetHeight, duration).SetEase(Ease.InOutQuad);
            transform.DORotateQuaternion(randomTilt, duration).SetEase(Ease.InOutQuad);
            hasRun = true;
        }
    }

    public void ResetTransform()
    {
        // 恢复到初始状态
        transform.DOScale(initialScale, duration).SetEase(Ease.InOutQuad);
        transform.DOMove(initialPosition, duration).SetEase(Ease.InOutQuad);
        transform.DORotateQuaternion(initialRotation, duration).SetEase(Ease.InOutQuad);
        hasRun = false;
    }

}
