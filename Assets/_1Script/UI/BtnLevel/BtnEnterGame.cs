using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnEnterGame : BaseButton
{
    [SerializeField] protected int sceneIndex;
    protected override void Reset()
    {
        base.Reset();
        this.sceneIndex = 1;
    }

    protected override void OnClick()
    {
        SceneManager.LoadScene(this.sceneIndex);
    }
}
