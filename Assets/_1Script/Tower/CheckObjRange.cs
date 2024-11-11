using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjRange : MonoBehaviour
{
    protected void Update()
    {
        if (TowerManager.instance.obj != transform.parent.parent.gameObject)
        {
            transform.gameObject.SetActive(false);
        }
    }
}
