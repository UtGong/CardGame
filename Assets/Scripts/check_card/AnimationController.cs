using Oculus.Interaction;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animation anim;
    public bool _isTrigger;

    void Start()
    {
        // 获取Animation组件
        anim = GetComponent<Animation>();
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
    public void PlayAnim()
    {
        if (_isTrigger)
        {
            anim.Play("Cube|anim");
        }
    }
}
