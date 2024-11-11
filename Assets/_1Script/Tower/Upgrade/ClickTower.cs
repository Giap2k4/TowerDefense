using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickTower : GapiMonoBehaviour
{
    [SerializeField] public Attack attack;
    [SerializeField] public UpgradeTower upgradeTower;

    [SerializeField] public Text txtLevel;

    [SerializeField] public Image img;
    [SerializeField] public Image imgUpgrade;

    [SerializeField] public Text txtDamage;
    [SerializeField] public Text txtDamageUpLevel;

    [SerializeField] public Text txtTimeAttack;
    [SerializeField] public Text txtTimeAttackUpLevel;

    [SerializeField] public Text txtRange;
    [SerializeField] public Text txtRangeUpLevel;

    [SerializeField] public Text txtGoldUpLevel;
    [SerializeField] public Text txtGoldUpgrade;
    [SerializeField] public Text txtGoldSell;

    [SerializeField] public Text txtTargetEnemy;

    [SerializeField] public GameObject checkGoldLevelUp;
    [SerializeField] public GameObject checkGoldUpgrade;

    [SerializeField] public GameObject rangeObj;

    [SerializeField] protected GameObject imgCheck_1;
    [SerializeField] protected GameObject imgCheck_2;
    [SerializeField] protected bool boolCheckImg_1;

    [SerializeField] protected AudioBtn audioBtn;

    protected override void Reset()
    {
        base.Reset();

        this.txtLevel = GameObject.Find("Canvas/TowerDiscription/_Txt").GetComponent<Text>();

        this.img = GameObject.Find("Canvas/TowerDiscription/_Img1").GetComponent<Image>();
        this.imgUpgrade = GameObject.Find("Canvas/TowerDiscription/_Img2").GetComponent<Image>();

        this.txtDamage = GameObject.Find("Canvas/TowerDiscription/GridParameter/Damage/_TxtDamage").GetComponent<Text>();
        this.txtDamageUpLevel = GameObject.Find("Canvas/TowerDiscription/GridParameter/Damage/_TxtDamageUpLevel").GetComponent<Text>();

        this.txtTimeAttack = GameObject.Find("Canvas/TowerDiscription/GridParameter/Reload/_TxtTime").GetComponent<Text>();
        this.txtTimeAttackUpLevel = GameObject.Find("Canvas/TowerDiscription/GridParameter/Reload/_TxtTimeUpLevel").GetComponent<Text>();

        this.txtRange = GameObject.Find("Canvas/TowerDiscription/GridParameter/Range/_TxtRange").GetComponent<Text>();
        this.txtRangeUpLevel = GameObject.Find("Canvas/TowerDiscription/GridParameter/Range/_TxtRangeUpLevel").GetComponent<Text>();

        this.txtGoldUpLevel = GameObject.Find("Canvas/TowerDiscription/BtnTower/UpLevel/_Txt").GetComponent<Text>();
        this.txtGoldUpgrade = GameObject.Find("Canvas/TowerDiscription/BtnTower/Upgrade/_Txt").GetComponent<Text>();
        this.txtGoldSell = GameObject.Find("Canvas/TowerDiscription/BtnTower/Sell/_Txt").GetComponent<Text>();

        this.txtTargetEnemy = GameObject.Find("Canvas/TowerDiscription/TargetTower/Btn/_Txt").GetComponent<Text>();

        this.attack = transform.Find("Attack").GetComponent<Attack>();
        this.upgradeTower = GetComponent<UpgradeTower>();

        this.checkGoldLevelUp = GameObject.Find("Canvas/TowerDiscription/CheckGoldTower/UpLevel");
        this.checkGoldUpgrade = GameObject.Find("Canvas/TowerDiscription/CheckGoldTower/Upgrade");

        this.rangeObj = transform.Find("Range/Range").gameObject;

        this.imgCheck_1 = GameObject.Find("Canvas/TowerDiscription/_Img1/CheckImg1");
        this.imgCheck_2 = GameObject.Find("Canvas/TowerDiscription/_Img2/CheckImg2");

        this.audioBtn = GameObject.Find("SoundManager/SoundBtn").GetComponent<AudioBtn>();
    }

    public void OnClick()
    {
        this.audioBtn.AudioPlay();

        TowerManager.instance.obj = gameObject;

        this.rangeObj.SetActive(true);

        if (this.boolCheckImg_1 == false)
        {
            this.imgCheck_1.SetActive(false);
            this.imgCheck_2.SetActive(true);
        } 
        else
        {
            this.imgCheck_1.SetActive(true);
            this.imgCheck_2.SetActive(false);
        }

        if (gameObject.name == "Flash" || gameObject.name == "Flash_2")
        {
            this.txtLevel.text = "Tháp điện - Level " + this.attack.level.ToString() + "/" + this.attack.maxLevel;

            this.img.sprite = Resources.Load<Sprite>("Item2/Flash_1");
            this.imgUpgrade.sprite = Resources.Load<Sprite>("Item2/Flash_2");
        }

        else if (gameObject.name == "Fire" || gameObject.name == "Fire_2")
        {
            this.txtLevel.text = "Tháp lửa - Level " + this.attack.level.ToString() + "/" + this.attack.maxLevel;

            this.img.sprite = Resources.Load<Sprite>("Item2/Fire_1");
            this.imgUpgrade.sprite = Resources.Load<Sprite>("Item2/Fire_2");
        }

        else if (gameObject.name == "Ice" || gameObject.name == "Ice_2")
        {
            this.txtLevel.text = "Tháp băng - Level " + this.attack.level.ToString() + "/" + this.attack.maxLevel;

            this.img.sprite = Resources.Load<Sprite>("Item2/Ice_1");
            this.imgUpgrade.sprite = Resources.Load<Sprite>("Item2/Ice_2");
        }

        else
        {
            this.txtLevel.text = "Tháp ma thuật - Level " + this.attack.level.ToString() + "/" + this.attack.maxLevel;

            this.img.sprite = Resources.Load<Sprite>("Item2/Magic_1");
            this.imgUpgrade.sprite = Resources.Load<Sprite>("Item2/Magic_2");
        }

        this.CheckGold();

        this.txtDamage.text = this.attack.damage.ToString();
        this.txtDamageUpLevel.text = "+" + this.upgradeTower.GetDamage().ToString();

        this.txtTimeAttack.text = this.attack.timeAttack.ToString();
        this.txtTimeAttackUpLevel.text = "-" + this.upgradeTower.timeAttack.ToString();

        this.txtRange.text = this.attack.circleCollider.radius.ToString();
        this.txtRangeUpLevel.text = "+" + this.upgradeTower.range.ToString();

        this.txtGoldUpLevel.text = this.upgradeTower.goldUpLevel.ToString();
        this.txtGoldUpgrade.text = this.upgradeTower.goldUpgrade.ToString();
        this.txtGoldSell.text = this.upgradeTower.goldSell.ToString();


        if (this.attack.level == this.attack.maxLevel)
        {
            this.txtDamageUpLevel.text = "";
            this.txtTimeAttackUpLevel.text = "";
            this.txtRangeUpLevel.text = "";
            this.txtGoldUpLevel.text = "";
        }

        if (this.attack.hpMin)
        {
            this.txtTargetEnemy.text = "Máu ít nhất";
        }

        else if (this.attack.hpMax)
        {
            this.txtTargetEnemy.text = "Máu nhiều nhất";
        }

        else if (this.attack.distanceMin)
        {
            this.txtTargetEnemy.text = "Gần nhất";
        }

        else
        {
            this.txtTargetEnemy.text = "Xa nhất";
        }

        if (this.upgradeTower.goldUpgrade == 0)
        {
            this.txtGoldUpgrade.text = "";
            this.checkGoldUpgrade.SetActive(true);
        }
    }

    public void CheckGold()
    {
        if (GoldLevel.instance.goldLevel < this.upgradeTower.goldUpLevel || this.attack.level >= this.attack.maxLevel)
        {
            this.txtGoldUpLevel.color = Color.red;
            this.checkGoldLevelUp.SetActive(true);
        }
        else
        {
            this.txtGoldUpLevel.color = Color.black;
            this.checkGoldLevelUp.SetActive(false);
        }

        if (GoldLevel.instance.goldLevel < this.upgradeTower.goldUpgrade)
        {
            this.txtGoldUpgrade.color = Color.red;
            this.checkGoldUpgrade.SetActive(true);
        }
        else
        {
            this.txtGoldUpgrade.color = Color.black;
            this.checkGoldUpgrade.SetActive(false);
        }

        if (this.upgradeTower.goldUpgrade == 0)
        {
            this.txtGoldUpgrade.text = "";
            this.checkGoldUpgrade.SetActive(true);
        }
    }
}
