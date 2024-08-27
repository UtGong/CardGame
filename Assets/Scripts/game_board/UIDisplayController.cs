using Unity.VisualScripting;
using UnityEngine;

public class UIDisplayController : MonoBehaviour
{
    public Transform uiElement;
    public GameObject canvas;
    public float min = 0.1f;
    public float max = 1f;
    public float diaplay = 0.2f;

    // Update 在每一帧调用
    void Start()
    {
    }
    void Update()
    {
        Vector3 currentScale = uiElement.localScale;
        if (currentScale.x >= diaplay)
        {
            ShowUI(true);
        }
        else
        {
            ShowUI(false);
        }
        if(currentScale.x >= max){
            uiElement.localScale = new Vector3(max,max,max);
        }
        if (currentScale.y <= min){
            uiElement.localScale = new Vector3(min,min,min);
        }
    }

    // 控制 UI 元素的显示和隐藏
    void ShowUI(bool show)
    {
        canvas.SetActive(show);
    }
}
