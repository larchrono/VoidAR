using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PageBehaviour : PanelExtendtion
{
    [HideInInspector] public CanvasGroup canvas;
    public UnityEvent OnPageOpen;
    public UnityEvent OnPageClose;

    void Awake(){
        canvas = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        CloseSelfImmediate();
    }

    public void DoPageOpen(){
        OnPageOpen?.Invoke();
    }

    public void DoPageClose(){
        OnPageClose?.Invoke();
    }

    public bool IsInActive(){
        return canvas.interactable;
    }
}
