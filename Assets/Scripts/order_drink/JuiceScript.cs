using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class JuiceScript : MonoBehaviour
{
    public Transform _spawnPos;
    private float destroyTimer = 2f;
    private bool isSelecting;
    public bool onSale = true;

    // Update is called once per frame
    void Update()
    {
        if (!onSale)
        {
            if (!isSelecting)
            {
                destroyTimer -= Time.deltaTime;

                if (destroyTimer <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void SelectedEvent()
    {
        if (onSale)
        {
            GameObject juice = Instantiate(gameObject, _spawnPos);
            onSale = false;
        }
        isSelecting = true;
    }

    public void UnselectedEvent()
    {

        destroyTimer = 2f;
        isSelecting = false;
    }
}
