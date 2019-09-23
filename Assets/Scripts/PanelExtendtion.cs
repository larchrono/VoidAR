using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using HashTool;

[RequireComponent(typeof(CanvasGroup))]
public class PanelExtendtion : MonoBehaviour
{
    [Header("UI動畫設定")]
    protected const float FadeDuration = 0.5f;
    protected Tweener currentTween;
    protected CanvasGroup selfCanvas;

    public void ClosePanelImmediate(CanvasGroup panel, Action callback){
        panel.alpha = 0;
        panel.interactable = false;
        panel.blocksRaycasts = false;

        callback?.Invoke();
    }

    public void OpenPanelImmediate(CanvasGroup panel, Action callback){
        panel.alpha = 1;
        panel.interactable = true;
        panel.blocksRaycasts = true;

        callback?.Invoke();
    }

    public void ClosePanelForce(CanvasGroup panel, Action callback = null){
        if(currentTween != null)
            currentTween.Kill();

        TweenCallback onComplete = () => {
            Hash.SetHandleBool(panel,"isRun",false);
            currentTween = null;
            callback?.Invoke();
        };
        panel.interactable = false;
        panel.blocksRaycasts = false;
        Hash.SetHandleBool(panel,"isRun",true);
        currentTween = panel.DOFade(0, FadeDuration).OnComplete(onComplete);
    }

    public void ClosePanel(CanvasGroup panel, Action callback = null){
        bool isRunning = Hash.GetHandleBool(panel,"isRun");
        if(isRunning)
            return;

        TweenCallback onComplete = () => {
            Hash.SetHandleBool(panel,"isRun",false);
            currentTween = null;
            callback?.Invoke();
        };
        panel.interactable = false;
        panel.blocksRaycasts = false;
        Hash.SetHandleBool(panel,"isRun",true);
        currentTween = panel.DOFade(0, FadeDuration).OnComplete(onComplete);
    }

    public void OpenPanel(CanvasGroup panel, Action callback){
        bool isRunning = Hash.GetHandleBool(panel,"isRun");
        if(isRunning)
            return;

        TweenCallback onComplete = () => {
            panel.alpha = 1;
            panel.interactable = true;
            panel.blocksRaycasts = true;
            Hash.SetHandleBool(panel,"isRun",false);
            currentTween = null;
            callback?.Invoke();
        };
        Hash.SetHandleBool(panel,"isRun",true);
        currentTween = panel.DOFade(1,FadeDuration).OnComplete(onComplete);
    }

    public void BTNActive(Button button, bool turn){
        button.interactable = turn;
    }

    public void OpenSelf(Action callback){
        if(selfCanvas == null)
            selfCanvas = GetComponent<CanvasGroup>();

        if(selfCanvas == null)
            return;
        
        OpenPanel(selfCanvas, callback);
    }

    public void CloseSelf(Action callback = null){
        if(selfCanvas == null)
            selfCanvas = GetComponent<CanvasGroup>();

        if(selfCanvas == null)
            return;
        
        ClosePanel(selfCanvas, callback);
    }

    public void CloseSelfForce(Action callback = null){
        if(selfCanvas == null)
            selfCanvas = GetComponent<CanvasGroup>();

        if(selfCanvas == null)
            return;

        ClosePanelForce(selfCanvas, callback);
    }

    public void CloseSelfImmediate(Action callback = null){
        if(selfCanvas == null)
            selfCanvas = GetComponent<CanvasGroup>();

        if(selfCanvas == null)
            return;

        if(currentTween != null)
            currentTween.Kill();

        ClosePanelImmediate(selfCanvas, callback);
        
    }
    
}
