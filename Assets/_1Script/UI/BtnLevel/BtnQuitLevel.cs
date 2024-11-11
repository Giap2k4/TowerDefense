using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnQuitLevel : BaseButton
{
    [SerializeField] protected int sceneIndex;
    protected override void Reset()
    {
        base.Reset();
        this.sceneIndex = 0;
    }

    protected override void OnClick()
    {
        //HealthLevel.instance.CheckReward();

        Time.timeScale = 1;
        SceneManager.LoadScene(this.sceneIndex);

        if (DataSetUpItem.instance == null) return;
        DataSetUpItem.instance.OnEnableCountBottle();
    }
}
