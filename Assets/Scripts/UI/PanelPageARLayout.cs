using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPageARLayout : MonoBehaviour
{
    public Button NavLocate;
    public Button NavTop;
    public Button NavBottom;
    public Button NavLeft;
    public Button NavRight;

    public Image TextUpdating;
    void Start()
    {
        NavLocate.onClick.AddListener(() => { OnPressNavLocate?.Invoke(); });
        NavTop.onClick.AddListener(() => { OnPressNavTop?.Invoke(); });
        NavBottom.onClick.AddListener(() => { OnPressNavBottom?.Invoke(); });
        NavLeft.onClick.AddListener(() => { OnPressNavLeft?.Invoke(); });
        NavRight.onClick.AddListener(() => { OnPressNavRight?.Invoke(); });

        NavLocate.gameObject.SetActive(false);
        NavTop.gameObject.SetActive(false);
        NavBottom.gameObject.SetActive(false);
        NavLeft.gameObject.SetActive(false);
        NavRight.gameObject.SetActive(false);
        TextUpdating.gameObject.SetActive(false);
    }

    public Action OnPressNavLocate;
    public Action OnPressNavTop;
    public Action OnPressNavBottom;
    public Action OnPressNavLeft;
    public Action OnPressNavRight;
}
