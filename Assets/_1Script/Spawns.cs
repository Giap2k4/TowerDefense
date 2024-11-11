using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : GapiMonoBehaviour
{
    [SerializeField] public List<Transform> objPool;
    [SerializeField] public List<Transform> prefabs;
    [SerializeField] protected Transform prefab;

    [SerializeField] public Transform holder;

    protected override void Reset()
    {
        base.Reset();

        this.prefab = transform.Find("Prefab");
        foreach (Transform t in this.prefab)
        {
            this.prefabs.Add(t);
        }

        this.holder = transform.Find("Holder");
    }

    public virtual Transform Spawn(string nameObj, Vector3 pos, Quaternion rot)
    {
        Transform objPrefab = GetObjInPrefab(nameObj);
        if (objPrefab == null) return null;

        Transform objPool = GetObjInPool(objPrefab);
        objPool.name = objPrefab.name;
        objPool.SetPositionAndRotation(pos, rot);
        objPool.parent = this.holder;
        objPool.gameObject.SetActive(true);

        return objPool;
    }

    public virtual void AddObjPool(Transform obj)
    {
        obj.gameObject.SetActive(false);
        this.objPool.Add(obj);
    }

    protected virtual Transform GetObjInPrefab(string nameObj)
    {
        foreach (Transform child in this.prefabs)
        {
            if (child.name == nameObj)
            {
                return child;
            }
        }

        return null;
    }

    protected virtual Transform GetObjInPool(Transform obj)
    {
        foreach (Transform child in this.objPool)
        {
            if (child.name == obj.name)
            {
                this.objPool.Remove(child);
                return child;
            }
        }

        Transform objNew = Instantiate(obj);
        return objNew;
    }
}
