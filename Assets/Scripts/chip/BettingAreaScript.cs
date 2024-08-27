using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;

public class BettingAreaScript : MonoBehaviour
{
    public List<ChipScript> chips;
    public ObservableCollection<ChipScript> chipsIn = new ObservableCollection<ChipScript>();
    public RectTransform bettingArea;
    public TextMeshProUGUI valueText;
    public float totalChipValue;

    void Start()
    {
        chipsIn.CollectionChanged += MyListChangedHandler;
    }
    void MyListChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
    {
        totalChipValue = 0;
        foreach (var chip in chipsIn)
        {
            Debug.LogWarning("chip value: " + chip.chipValue);
            totalChipValue += chip.chipValue;
        }
        Debug.LogWarning("total chip value: " + totalChipValue);
        valueText.text = totalChipValue.ToString();
    }
    private void Update()
    {
        foreach (var chip in chips)
        {
            if (IsTransformInsideRectTransform(bettingArea, chip.transform))
            {
                if (!chipsIn.Contains(chip))
                {
                    chipsIn.Add(chip);
                }
            }
            else
            {
                if (chipsIn.Contains(chip))
                {
                    chipsIn.Remove(chip);
                }
            }
        }

    }
    public bool IsTransformInsideRectTransform(RectTransform rectTransform, Transform targetTransform)
    {
        // 获取 RectTransform 的四个顶点的世界坐标
        Vector3[] worldCorners = new Vector3[4];
        rectTransform.GetWorldCorners(worldCorners);

        // 获取 Transform 的世界位置
        Vector3 targetPosition = targetTransform.position;

        // 判断是否在 X 轴范围内
        bool isInsideX = targetPosition.x >= worldCorners[0].x && targetPosition.x <= worldCorners[2].x;

        // 判断是否在 Z 轴范围内
        bool isInsideZ = targetPosition.z >= worldCorners[0].z && targetPosition.z <= worldCorners[1].z;

        // 如果在 X 和 Y 轴范围内，则返回 true
        return isInsideX && isInsideZ;
    }

}
