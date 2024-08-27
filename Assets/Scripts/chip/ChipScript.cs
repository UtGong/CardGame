using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ChipScript : MonoBehaviour
{
    public BettingAreaScript _bettingArea;
    public int chipValue;
    public int chipType;
    public TextMeshPro valueText;
    public RectTransform textParent;
    public Transform meshParent;
    public GameObject chipMesh;
    public List<GameObject> chipMeshArray;
    public bool isCount;
    private float chipHeight = 0.0034f;
    private bool _base = true;
    private bool entered = false;
    public void HoldChip(bool holded)
    {
        _base = !holded;
    }

    private void Start()
    {
        chipValue = 25;
        chipType = 25;
        chipMeshArray.Add(chipMesh);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (entered) return;
        _collisionEnter(collision);
        entered = true;
    }
    private void OnCollisionExit(Collision other)
    {
        entered = false;
    }
    public void _collisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;
        if (collidedObject.tag == "Chip")
        {
            ChipScript baseChip = collidedObject.GetComponent<ChipScript>();
            if (baseChip.chipType == chipType && !_base)
            {
                baseChip.chipValue += chipValue;
                baseChip.valueText.text = baseChip.chipValue.ToString();
                //get new meshs
                for (int i = 0; i < chipMeshArray.Count; i++)
                {
                    Debug.LogWarning(chipMeshArray.Count);

                    Vector3 upVector = chipHeight * baseChip.chipMeshArray.Count * baseChip.chipMesh.transform.forward;
                    Vector3 newPosition = baseChip.chipMesh.transform.position + upVector;

                    Quaternion newRotation = baseChip.chipMesh.transform.rotation;
                    var newMesh = Instantiate(chipMesh, newPosition, newRotation);
                    foreach (var mesh in baseChip.chipMeshArray)
                    {
                        Physics.IgnoreCollision(mesh.GetComponent<MeshCollider>(), newMesh.GetComponent<MeshCollider>());
                    }
                    newMesh.transform.SetParent(baseChip.meshParent);
                    baseChip.chipMeshArray.Add(newMesh);
                }
                _bettingArea.chips.Remove(this);
                _bettingArea.chipsIn.Remove(this);
                Destroy(gameObject);
                baseChip.textParent.DOAnchorPosY((baseChip.chipMeshArray.Count + 4) * chipHeight, 0.2f).SetEase(Ease.OutBack);
            }
        }
    }
}
