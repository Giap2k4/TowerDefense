using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataInventory : GapiMonoBehaviour
{
    [SerializeField] protected Text txtLevelBottle;
    [SerializeField] protected Text txtParameterBottle;

    [SerializeField] protected Text txtLevelBoost;
    [SerializeField] protected Text txtParameterBoost;
    [SerializeField] protected Text txtQuantityBoost;

    [SerializeField] protected Text txtLevelFreeze;
    [SerializeField] protected Text txtParameterFreeze;
    [SerializeField] protected Text txtQuantityFreeze;

    [SerializeField] protected Text txtLevelLightning;
    [SerializeField] protected Text txtParameterLightning;
    [SerializeField] protected Text txtQuantityLightning;

    protected override void Reset()
    {
        base.Reset();

        this.txtLevelBottle = transform.Find("Object/Bottle/Image/Panel/_Txt").GetComponent<Text>();
        this.txtParameterBottle = transform.Find("Object/Bottle/_Txt").GetComponent<Text>();

        this.txtLevelBoost = transform.Find("Object/Grid/Boost/Image/Panel/_Txt").GetComponent<Text>();
        this.txtParameterBoost = transform.Find("Object/Grid/Boost/_TxtParameter").GetComponent<Text>();
        this.txtQuantityBoost = transform.Find("Object/Grid/Boost/_TxtQuantity").GetComponent<Text>();

        this.txtLevelFreeze = transform.Find("Object/Grid/Freeze/Image/Panel/_Txt").GetComponent<Text>();
        this.txtParameterFreeze = transform.Find("Object/Grid/Freeze/_TxtParameter").GetComponent<Text>();
        this.txtQuantityFreeze = transform.Find("Object/Grid/Freeze/_TxtQuantity").GetComponent<Text>();

        this.txtLevelLightning = transform.Find("Object/Grid/Lightning/Image/Panel/_Txt").GetComponent<Text>();
        this.txtParameterLightning = transform.Find("Object/Grid/Lightning/_TxtParameter").GetComponent<Text>();
        this.txtQuantityLightning = transform.Find("Object/Grid/Lightning/_TxtQuantity").GetComponent<Text>();
    }

    protected void OnEnable()
    {
        this.txtLevelBottle.text = MainScore.instance.LoadFloat("levelBottle", 0).ToString();
        this.txtParameterBottle.text = MainScore.instance.LoadFloat("parameterBottle", 0).ToString();
        
        this.txtLevelBoost.text = MainScore.instance.LoadFloat("levelBoost", 0).ToString();
        this.txtQuantityBoost.text = MainScore.instance.LoadFloat("quantityBoost", 0).ToString();
        this.txtParameterBoost.text = "x" + MainScore.instance.LoadFloat("parameterBoost", 0).ToString();

        this.txtLevelFreeze.text = MainScore.instance.LoadFloat("levelFreeze", 0).ToString();
        this.txtQuantityFreeze.text = MainScore.instance.LoadFloat("quantityFreeze", 0).ToString();
        this.txtParameterFreeze.text = MainScore.instance.LoadFloat("parameterFreeze", 0).ToString() + "s";

        this.txtLevelLightning.text = MainScore.instance.LoadFloat("levelLightning", 0).ToString();
        this.txtQuantityLightning.text = MainScore.instance.LoadFloat("quantityLightning", 0).ToString();
        this.txtParameterLightning.text = MainScore.instance.LoadFloat("parameterLightning", 0).ToString();
    }
}
