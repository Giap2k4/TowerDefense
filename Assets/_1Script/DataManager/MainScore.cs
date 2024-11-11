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

    public void SaveInt(string nameVariable, int variable)
    {
        PlayerPrefs.SetInt(nameVariable, variable);
        PlayerPrefs.Save();
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

    public int LoadInt(string nameVariable, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(nameVariable, defaultValue);
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
        if (!PlayerPrefs.HasKey("map_1"))
        {
            PlayerPrefs.SetInt("map_1", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("map_2"))
        {
            PlayerPrefs.SetInt("map_2", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("map_3"))
        {
            PlayerPrefs.SetInt("map_3", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("map_4"))
        {
            PlayerPrefs.SetInt("map_4", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("map_5"))
        {
            PlayerPrefs.SetInt("map_5", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("map_6"))
        {
            PlayerPrefs.SetInt("map_6", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("map_7"))
        {
            PlayerPrefs.SetInt("map_7", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("map_8"))
        {
            PlayerPrefs.SetInt("map_8", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("map_9"))
        {
            PlayerPrefs.SetInt("map_9", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("map_10"))
        {
            PlayerPrefs.SetInt("map_10", 0);
            PlayerPrefs.Save();
        }
    }
    
    protected void RewardMap()
    {
        // Thông tin phần thưởng các Map
        if (!PlayerPrefs.HasKey("reward_1"))
        {
            PlayerPrefs.SetInt("reward_1", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("reward_2"))
        {
            PlayerPrefs.SetInt("reward_2", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("reward_3"))
        {
            PlayerPrefs.SetInt("reward_3", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("reward_4"))
        {
            PlayerPrefs.SetInt("reward_4", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("reward_5"))
        {
            PlayerPrefs.SetInt("reward_5", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("reward_6"))
        {
            PlayerPrefs.SetInt("reward_6", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("reward_7"))
        {
            PlayerPrefs.SetInt("reward_7", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("reward_8"))
        {
            PlayerPrefs.SetInt("reward_8", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("reward_9"))
        {
            PlayerPrefs.SetInt("reward_9", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("reward_10"))
        {
            PlayerPrefs.SetInt("reward_10", 0);
            PlayerPrefs.Save();
        }
    }
        

}
