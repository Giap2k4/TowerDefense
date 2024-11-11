using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeTower : GapiMonoBehaviour
{
    [SerializeField] protected Attack attack;
    [SerializeField] protected ClickTower click;

    [SerializeField] protected float damage;
    [SerializeField] protected float damageIncrease; // Damage sẽ cộng thêm khi tăng các level
    
    [SerializeField] public float timeAttack;
    [SerializeField] public float range;

    [SerializeField] public int goldUpLevel;
    [SerializeField] public int goldUpgrade;
    [SerializeField] public int goldSell;

    [SerializeField] public int goldAfterUpgrade;

    protected override void Reset()
    {
        base.Reset();
        this.attack = transform.Find("Attack").GetComponent<Attack>();
        this.click = GetComponent<ClickTower>();
    }

    public abstract float GetDamage();// Damage sẽ tăng
    public abstract void SetDamage();

    public void LevelUp()
    {
        if (goldUpLevel > GoldLevel.instance.goldLevel || this.attack.level >= this.attack.maxLevel)
        {
            return;
        }

        GoldLevel.instance.GoldUse(this.goldUpLevel);
        this.goldUpLevel += this.goldAfterUpgrade;

        this.attack.damage += this.damage;
        this.attack.timeAttack -= this.timeAttack;
        this.attack.circleCollider.radius += this.range;
        this.attack.level++;

        this.click.rangeObj.transform.localScale = new Vector3(this.attack.circleCollider.radius, this.attack.circleCollider.radius, 1); 

        this.SetDamage();

        //damage
        this.click.txtDamage.text = this.attack.damage.ToString();
        this.click.txtDamageUpLevel.text = "+" + GetDamage().ToString();

        //thời gian
        this.click.txtTimeAttack.text = this.attack.timeAttack.ToString();
        this.click.txtTimeAttackUpLevel.text = "-" + this.timeAttack.ToString();

        //phạm vi
        this.click.txtRange.text = this.attack.circleCollider.radius.ToString();
        this.click.txtRangeUpLevel.text = "+" + this.range.ToString();

        // vàng
        this.click.txtGoldUpLevel.text = this.goldUpLevel.ToString();
        this.click.txtGoldUpgrade.text = this.goldUpgrade.ToString();
        this.click.txtGoldSell.text = this.goldSell.ToString();

        if (this.goldUpgrade == 0)
        {
            this.click.txtGoldUpgrade.text = "";
            this.click.checkGoldUpgrade.SetActive(true);
        }

        if (gameObject.name == "Flash" || gameObject.name == "Flash_2")
        {
            this.click.txtLevel.text = "Tháp điện - Level " + this.attack.level.ToString() + "/" + this.attack.maxLevel;
        }

        else if (gameObject.name == "Fire" || gameObject.name == "Fire_2")
        {
            this.click.txtLevel.text = "Tháp lửa - Level " + this.attack.level.ToString() + "/" + this.attack.maxLevel;
        }

        else if (gameObject.name == "Ice" || gameObject.name == "Ice_2")
        {
            this.click.txtLevel.text = "Tháp băng - Level " + this.attack.level.ToString() + "/" + this.attack.maxLevel;
        }

        else
        {
            this.click.txtLevel.text = "Tháp ma thuật - Level " + this.attack.level.ToString() + "/" + this.attack.maxLevel;
        }
        
        

        if (goldUpLevel > GoldLevel.instance.goldLevel || this.attack.level >= this.attack.maxLevel)
        {
            this.click.checkGoldLevelUp.SetActive(true);
            this.click.txtGoldUpLevel.color = Color.red;
        } else
        {
            this.click.txtGoldUpLevel.color = Color.black;
        }

        if (this.attack.level == this.attack.maxLevel)
        {
            this.click.txtDamageUpLevel.text = "";
            this.click.txtTimeAttackUpLevel.text = "";
            this.click.txtRangeUpLevel.text = "";
            this.click.txtGoldUpLevel.text = "";
        }
    }

    public void Upgrade()
    {
        Transform obj;

        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        GoldLevel.instance.GoldUse(this.goldUpgrade);
        TowerController.instance.AddObjPool(transform);

        //this.imgCheck_1.SetActive(true);
        //this.imgCheck_2.SetActive(false);

        if (gameObject.name == "Flash")
        {
            obj = TowerController.instance.Spawn("Flash_2", pos, rot);
            this.click.txtLevel.text = "Tháp điện - Level " + this.attack.level.ToString() + "/" + this.attack.maxLevel;
        } 
        else if (gameObject.name == "Fire")
        {
            obj = TowerController.instance.Spawn("Fire_2", pos, rot);
            this.click.txtLevel.text = "Tháp lửa - Level " + this.attack.level.ToString() + "/" + this.attack.maxLevel;
        }
        else if (gameObject.name == "Ice")
        {
            obj = TowerController.instance.Spawn("Ice_2", pos, rot);
            this.click.txtLevel.text = "Tháp băng - Level " + this.attack.level.ToString() + "/" + this.attack.maxLevel;
        }
        else
        {
            obj = TowerController.instance.Spawn("Magic_2", pos, rot);
            this.click.txtLevel.text = "Tháp ma thuật - Level " + this.attack.level.ToString() + "/" + this.attack.maxLevel;
        }

        TowerManager.instance.obj = obj.gameObject;

        this.click.checkGoldUpgrade.SetActive(true);
        this.click.txtGoldUpgrade.text = "";

        //this.click.OnClick();

        //damage
        this.click.txtDamage.text = this.attack.damage.ToString();
        this.click.txtDamageUpLevel.text = "+" + GetDamage().ToString();

        //thời gian
        this.click.txtTimeAttack.text = this.attack.timeAttack.ToString();
        this.click.txtTimeAttackUpLevel.text = "-" + this.timeAttack.ToString();

        //phạm vi
        this.click.txtRange.text = this.attack.circleCollider.radius.ToString();
        this.click.txtRangeUpLevel.text = "+" + this.range.ToString();

        // vàng
        this.click.txtGoldUpLevel.text = this.goldUpLevel.ToString();
        this.click.txtGoldUpgrade.text = this.goldUpgrade.ToString();
        this.click.txtGoldSell.text = this.goldSell.ToString();

        if (goldUpLevel > GoldLevel.instance.goldLevel)
        {
            this.click.checkGoldLevelUp.SetActive(true);
            this.click.txtGoldUpLevel.color = Color.red;
        }
        else
        {
            this.click.txtGoldUpLevel.color = Color.black;
        }

    }

    public void Sell()
    {
        
        Vector3 posObj = (transform.position);
        Vector3 posRemove = new Vector3(0, 0, 0);
        Vector3 posRemove2 = new Vector3(0, 0, 0);

        float distance = Vector2.Distance(posObj, DragAndDrop.listPosTilemap[0]);

        for (int i = 0; i < DragAndDrop.listPosTilemap.Count - 1; i++)
        {
            float distance2 = Vector2.Distance(posObj, DragAndDrop.listPosTilemap[i + 1]);

            if (distance > distance2)
            {
                distance = distance2;
                posRemove2 = DragAndDrop.listPosTilemap[i + 1];
            }
        }

        if (posRemove2 == posRemove)
        {
            posRemove2 = DragAndDrop.listPosTilemap[0];
        }

        if (DragAndDrop.listPosTilemap.Contains(posRemove2))
        {
            TowerController.instance.AddObjPool(transform);
            DragAndDrop.listPosTilemap.Remove(posRemove2);

        }
        else Debug.Log("Không có vị trí này");
        
        GoldLevel.instance.GoldCollect(this.goldSell);
    }
}
