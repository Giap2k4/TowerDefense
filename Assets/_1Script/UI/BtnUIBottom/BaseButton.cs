using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : GapiMonoBehaviour
{
    [SerializeField] protected Button button;

    protected override void Reset()
    {
        if (this.button != null) return;

        this.button = GetComponent<Button>();
    }

    protected override void Start()
    {
        this.AddOnClickEvent();
    }

    protected void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }

    protected abstract void OnClick();
}
