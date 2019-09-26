using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SaveScreen))]
public class AR3DLayout : MonoBehaviour
{
    public static AR3DLayout instance;

    public Button BTNExit;
    public Button BTNShot;
    public Button BTNTracking;
    public Transform ArtworkPool;

    public GameObject Prefab_Object;

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
        BTNTracking.onClick.AddListener(DoStartTracking);

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

    void DoExit(){
        gameObject.SetActive(false);
    }

    void DoShot(){
        saveScreen.OnClickScreenCaptureButton();
    }

    void DoStartTracking(){
        VoidAR.GetInstance().startMarkerlessTracking();
    }
}
