using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPageARLayout : MonoBehaviour
{
    public Button BTN_Here;
    public Button BTN_GoMap;

    void Start()
    {
        BTN_Here.onClick.AddListener(() => { OnPressHere?.Invoke(); });
        BTN_GoMap.onClick.AddListener(() => { OnPressGoMap?.Invoke(); });
    }

    public Action OnPressHere;
    public Action OnPressGoMap;
}
