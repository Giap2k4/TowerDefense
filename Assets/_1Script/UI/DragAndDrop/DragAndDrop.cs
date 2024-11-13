using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class DragAndDrop : GapiMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static DragAndDrop instance;
    [SerializeField] protected Tilemap CanPick;
    [SerializeField] protected Tilemap CantPick;
    [SerializeField] protected Transform objImage;

    [SerializeField] protected string nameTower;
    [SerializeField] protected Quaternion rot = new Quaternion(0, 0, 0, 0);

    [SerializeField] protected int checkGold;

    public static List<Vector3> listPosTilemap;

    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip clip1;
    [SerializeField] protected AudioClip clip2;

    protected override void Reset()
    {
        base.Reset();
        this.audioSource = GetComponent<AudioSource>();
    }
    protected override void Start()
    {
        base.Start();

        this.CanPick = GameObject.Find("Object/Map/Map_" + ScrollLevel.nameMap + "/CanPick").GetComponent<Tilemap>();
        this.CantPick = GameObject.Find("Object/Map/Map_" + ScrollLevel.nameMap + "/CantPick").GetComponent<Tilemap>();
    }

    protected override void Awake()
    {
        base.Awake();
        DragAndDrop.instance = this;
        DragAndDrop.listPosTilemap = new List<Vector3>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.objImage.gameObject.SetActive(true);
        this.CantPick.GetComponent<Tilemap>().color = new Color(0.5f, 0.5f, 0.5f, 1);

        this.audioSource.clip = clip1;
        this.audioSource.Play();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 posObj = this.PosMouse();
        posObj.z = -3;
        objImage.transform.position = posObj;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3Int tilePosition = CanPick.WorldToCell(this.PosMouse()); // Xác định ô trong tilemap

        Vector3 cellCenterPosition = CanPick.GetCellCenterWorld(tilePosition); // lấy vị trí ở chính giữa ô
        Vector3 posObj = cellCenterPosition;
        posObj.z = -3;

        if (CanPick.GetTile(tilePosition) != null && !listPosTilemap.Contains(posObj))
        {
            TowerController.instance.Spawn(this.nameTower, posObj, this.rot);
            GoldLevel.instance.GoldUse(this.checkGold);

            this.audioSource.clip = clip2;
            this.audioSource.Play();

            listPosTilemap.Add(posObj);
        } else
        {
            Debug.Log("Đã có tháp ở vị trí này");
        }

        this.objImage.gameObject.SetActive(false);
        this.CantPick.GetComponent<Tilemap>().color = new Color(1, 1, 1, 1f);
    }

    protected Vector3 PosMouse()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        pos.y = pos.y + 3;
        return pos;
    }

}
