﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SaveScreen))]
public class AR2DLayout : MonoBehaviour
{
    public static AR2DLayout instance;

    public Button BTNExit;
    public Button BTNShot;
    public ScriptsCamera scriptsCamera;
    public Transform ArtworkPool;

    SaveScreen saveScreen;
    
    
    void Awake(){
        instance = this;
    }

    void OnEnable() {
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    void OnDisable() {
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.orientation = ScreenOrientation.Portrait;
    }

    void Start()
    {
        BTNExit.onClick.AddListener(DoExit);
        BTNShot.onClick.AddListener(DoShot);

        saveScreen = GetComponent<SaveScreen>();
    }

    public void SetupArtwork(GameObject obj){
        foreach (Transform item in ArtworkPool)
        {
            Destroy(item.gameObject);
        }

        if(obj)
            Instantiate(obj, ArtworkPool);
    }

    public void SetupStreetPhoto(GameObject obj){
        foreach (Transform item in ArtworkPool)
        {
            Destroy(item.gameObject);
        }

        if(obj)
            Instantiate(obj, ArtworkPool);
    }

    public void StartAR2D(){
        scriptsCamera.StartWebcam();
    }
    void DoExit(){
        gameObject.SetActive(false);
        scriptsCamera.StopWebcam();
        
    }

    void DoShot(){
        saveScreen.OnClickScreenCaptureButton();
    }
}
