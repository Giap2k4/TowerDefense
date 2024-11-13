using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScore : GapiMonoBehaviour
{
    public static MainScore instance;

    protected override void Awake()
    {
        base.Awake();
        MainScore.instance = this;
    }

    protected override void Start()
    {
        base.Start();

//#if UNITY_EDITOR
//        PlayerPrefs.DeleteAll();
//#endif

        this.QuantityGoldAndDiamond();
        this.QuantityItem();
        this.LevelItem();
        this.ParameterItem();
        this.LevelMap();
        this.RewardMap();
        
    }

    public void SaveFloat(string nameVariable, float variable)
    {
        PlayerPrefs.SetFloat(nameVariable, variable);
        PlayerPrefs.Save();
    }

    public void SaveString(string nameVariable, string variable)
    {
        PlayerPrefs.SetString(nameVariable, variable);
        PlayerPrefs.Save();
    }

    public float LoadFloat(string nameVariable, float defaultValue = 0.0f)
    {
        return PlayerPrefs.GetFloat(nameVariable, defaultValue);
    }

    public string LoadSrting(string nameVariable, string defaultValue = "")
    {
        return PlayerPrefs.GetString(nameVariable, defaultValue);
    }

    protected void QuantityGoldAndDiamond()
    {
        if (!PlayerPrefs.HasKey("giftNewbies"))
        {
            PlayerPrefs.SetInt("giftNewbies", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("gold"))
        {
            PlayerPrefs.SetInt("gold", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("diamond"))
        {
            PlayerPrefs.SetInt("diamond", 0);
            PlayerPrefs.Save();
        }
    }

    protected void QuantityItem()
    {
        // Số lượng item
        if (!PlayerPrefs.HasKey("quantityBoost"))
        {
            PlayerPrefs.SetInt("quantityBoost", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("quantityFreeze"))
        {
            PlayerPrefs.SetInt("quantityFreeze", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("quantityLightning"))
        {
            PlayerPrefs.SetInt("quantityLightning", 0);
            PlayerPrefs.Save();
        }

        
    }

    protected void LevelItem()
    {
        // Level cao nhất của item
        if (!PlayerPrefs.HasKey("maxLevelBottle"))
        {
            PlayerPrefs.SetInt("maxLevelBottle", 6);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("maxLevelBoost"))
        {
            PlayerPrefs.SetInt("maxLevelBoost", 6);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("maxLevelFreeze"))
        {
            PlayerPrefs.SetInt("maxLevelFreeze", 6);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("maxLevelLightning"))
        {
            PlayerPrefs.SetInt("maxLevelLightning", 6);
            PlayerPrefs.Save();
        }

        // Level của item
        if (!PlayerPrefs.HasKey("levelBottle"))
        {
            PlayerPrefs.SetInt("levelBottle", 1);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("levelBoost"))
        {
            PlayerPrefs.SetInt("levelBoost", 1);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("levelFreeze"))
        {
            PlayerPrefs.SetInt("levelFreeze", 1);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("levelLightning"))
        {
            PlayerPrefs.SetInt("levelLightning", 1);
            PlayerPrefs.Save();
        }
    }
        
    protected void ParameterItem()
    {
        // Thông số của các item
        if (!PlayerPrefs.HasKey("parameterBottle"))
        {
            PlayerPrefs.SetFloat("parameterBottle", 3);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("parameterBoost"))
        {
            PlayerPrefs.SetFloat("parameterBoost", 2);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("parameterFreeze"))
        {
            PlayerPrefs.SetFloat("parameterFreeze", 3);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("parameterLightning"))
        {
            PlayerPrefs.SetFloat("parameterLightning", 500);
            PlayerPrefs.Save();
        }
    }
        
    protected void LevelMap()
    {
        //Các màn đã vượt qua của từng map

        for (int i = 1; i < 11; i++)
        {
            if (!PlayerPrefs.HasKey("map_" + i))
            {
                PlayerPrefs.SetInt("map_" + i, 0);
                PlayerPrefs.Save();
            }
        }
    }
    
    protected void RewardMap()
    {
        // Thông tin phần thưởng các Map
        for (int i = 1; i < 11; i++)
        {
            if (!PlayerPrefs.HasKey("reward_" + i))
            {
                PlayerPrefs.SetInt("reward_" + i, 0);
                PlayerPrefs.Save();
            }
        }
    }
        

}
