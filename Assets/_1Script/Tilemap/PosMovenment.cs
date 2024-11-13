using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PosMovenment : GapiMonoBehaviour
{
    [SerializeField] public List<Vector3> posMovenment;
    [SerializeField] protected Tilemap tilemap;

    protected override void Start()
    {
        base.Start();
        //gameObject.SetActive(false);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.tilemap = GetComponent<Tilemap>();

        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(position.x, position.y, position.z);

            if (this.tilemap.HasTile(localPlace))
            {
                Vector3 worldPosition = this.tilemap.GetCellCenterWorld(localPlace);

                worldPosition.y = 0.15f + worldPosition.y;
                worldPosition.z = 0;
                this.posMovenment.Add(worldPosition);
            }
        }
    }
}
