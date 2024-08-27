// 用在远距离选择的物体上，实现发光的效果。

using UnityEngine;
using DG.Tweening;

public class EmissionControl : MonoBehaviour
{
    public Color emissionColor = Color.yellow;
    public float emissionIntensity = 2.0f;
    public float glowDuration = 1.0f;
    public float fadeDuration = 1.0f;

    public Renderer[] renderers;
    public MaterialPropertyBlock materialPropertyBlock;
    public static readonly int EmissionColorID = Shader.PropertyToID("_EmissionColor");

    void Start()
    {
        // 获取所有子对象的渲染器组件
        renderers = GetComponentsInChildren<Renderer>();
        materialPropertyBlock = new MaterialPropertyBlock();
    }

    public void ToggleGlow(bool enable)
    {
        renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderers)
        {
            rend.GetPropertyBlock(materialPropertyBlock);
            if (enable)
            {
                Color targetColor = emissionColor * emissionIntensity;
                DOTween.To(() => materialPropertyBlock.GetColor(EmissionColorID), x => materialPropertyBlock.SetColor(EmissionColorID, x), targetColor, glowDuration)
                    .OnUpdate(() => rend.SetPropertyBlock(materialPropertyBlock))
                    .OnStart(() => rend.material.EnableKeyword("_EMISSION"));
            }
            else
            {
                DOTween.To(() => materialPropertyBlock.GetColor(EmissionColorID), x => materialPropertyBlock.SetColor(EmissionColorID, x), Color.black, fadeDuration)
                    .OnUpdate(() => rend.SetPropertyBlock(materialPropertyBlock))
                    .OnComplete(() => rend.material.DisableKeyword("_EMISSION"));
            }
        }
    }

}
