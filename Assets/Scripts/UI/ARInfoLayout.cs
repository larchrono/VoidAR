using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARInfoLayout : PanelExtendtion
{
    public static ARInfoLayout instance;
    public Text Title;
    public Image MapIcon;
    public Text GoadRange;
    public Button Go2D;
    public Button Go3D;
    public Button Open2D;
    public Button Open3D;
    public NavingLayout PanelNaving;
    public SizeController contentSizeController;

    public Button BTNClose;

    //-------------------

    public Image ContentPhoto;
    public Text ContentPhotoInText;
    public Button ArtworkLink;
    public ArtworkInfoBox ArtworkInfo;
    public Text ContentText;
    public Text CopyrightText;

    public POIData currentData;
 
    void Awake() {
        instance = this;
    }

    void Start(){
        //BTNStart.onClick.AddListener(OpenAR);
        BTNClose.onClick.AddListener(CloseInfo);
        ArtworkLink.onClick.AddListener(OpenArtistWindow);

        Go2D.onClick.AddListener(Enable2DGo);

        
    }

    void Update(){
        //BTNStart.interactable = currentData.CanStartAR;

    }

    public void OpenPanelRegular(POIData data , double distance){
        currentData = data;

        if(data.typeOfPOI == POIData.TypeOfPOI.AR)
            ARInfoLayout.instance.RefreshInfoAR_FromPOI();
        else if (data.typeOfPOI == POIData.TypeOfPOI.OldPicture)
            ARInfoLayout.instance.RefreshInfoOldPhoto_FromPOI();
        else if (data.typeOfPOI == POIData.TypeOfPOI.Bus)
            ARInfoLayout.instance.RefreshInfoBus_FromPOI();
        else if (data.typeOfPOI == POIData.TypeOfPOI.ArtGallery)
            ARInfoLayout.instance.RefreshInfoGallery_FromPOI();

         ARInfoLayout.instance.SetMeterDistanceDisplay(distance);
         CheckOpenARReady();
         OpenSelf(null);
    }

    void Enable2DGo(){
        PlayerEvent.instance.SetTargetGoal(currentData.transform);
        PlayerEvent.instance.OnUpdateDistance += OnUpdateDistance;
        CloseSelf();
        PanelNaving.OpenSelf(null);
    }

    public void Stop2DGo(){
        PlayerEvent.instance.ClearTargetGoal();
        PlayerEvent.instance.OnUpdateDistance = null;
    }

    public void CheckOpenARReady(){
        if(currentData == PlayerEvent.instance.arrivePOI){
            Open2D.interactable = true;
            Open3D.interactable = true;
        } else {
            Open2D.interactable = false;
            Open3D.interactable = false;
        }
    }

    void OnUpdateDistance(double value){
        SetMeterDistanceDisplay(value);
    }

    public void SetMeterDistanceDisplay(double value){
        //Debug.Log("Distance is " + value.ToString("#.#"));
        GoadRange.text = "距離 " + value.ToString("#.#") + " m";
    }

    void OpenAR(){
        
    }

    void CloseInfo(){
        CloseSelf();
    }

    public void RefreshInfoAR_FromPOI(){
        Title.text = currentData.POI_Name;
        MapIcon.sprite = currentData.spriteLoc;

        ContentPhoto.enabled = true;
        ContentPhoto.sprite = currentData.ArtPhoto;
        ContentPhotoInText.text = "";

        ArtworkLink.interactable = true;
        ArtworkInfo.Artwork.text = currentData.ArtworkName;
        ArtworkInfo.Artist.text = currentData.ArtistName;
        ArtworkInfo.Age.text = currentData.ArtAge;
        ArtworkInfo.MaterialInfo.text = currentData.ArtMaterial;
        ArtworkInfo.SizeInfo.text = currentData.ArtSize;

        ContentText.text = currentData.ArtContent;
        CopyrightText.text = currentData.ArtCopyright;

        Open2D.gameObject.SetActive(true);
        Open3D.gameObject.SetActive(true);

        contentSizeController.ResizeContent();
    }

    public void RefreshInfoOldPhoto_FromPOI(){
        Title.text = currentData.POI_Name;
        MapIcon.sprite = currentData.spriteLoc;

        ContentPhoto.enabled = true;
        ContentPhoto.sprite = currentData.ViewpointPhoto;
        ContentPhotoInText.text = "";

        ArtworkLink.interactable = false;
        ArtworkInfo.Artwork.text = currentData.PhotoAge;
        ArtworkInfo.Artist.text = currentData.PhotoSource;
        ArtworkInfo.Age.text = "";
        ArtworkInfo.MaterialInfo.text = "";
        ArtworkInfo.SizeInfo.text = "";

        ContentText.text = currentData.ViewpointContent;
        CopyrightText.text = "";

        Open2D.gameObject.SetActive(true);
        Open3D.gameObject.SetActive(true);
        
        contentSizeController.ResizeContent();
    }

    public void RefreshInfoBus_FromPOI(){
        Title.text = currentData.ArtistName;
        MapIcon.sprite = currentData.spriteLoc;

        ContentPhoto.enabled = false;
        ContentPhoto.sprite = null;
        ContentPhotoInText.text = currentData.ArtContent;

        ArtworkLink.interactable = false;
        ArtworkInfo.Artwork.text = "";
        ArtworkInfo.Artist.text = "";
        ArtworkInfo.Age.text = "";
        ArtworkInfo.MaterialInfo.text = "";
        ArtworkInfo.SizeInfo.text = "";

        ContentText.text = "";
        CopyrightText.text = "";

        Open2D.gameObject.SetActive(false);
        Open3D.gameObject.SetActive(false);
        
        contentSizeController.ResizeContent();
    }

    public void RefreshInfoGallery_FromPOI(){
        Title.text = currentData.POI_Name;
        MapIcon.sprite = currentData.spriteLoc;

        ContentPhoto.enabled = false;
        ContentPhoto.sprite = null;
        ContentPhotoInText.text = currentData.ArtContent;

        ArtworkLink.interactable = false;
        ArtworkInfo.Artwork.text = "";
        ArtworkInfo.Artist.text = "";
        ArtworkInfo.Age.text = "";
        ArtworkInfo.MaterialInfo.text = "";
        ArtworkInfo.SizeInfo.text = "";

        ContentText.text = "";
        CopyrightText.text = "";

        Open2D.gameObject.SetActive(false);
        Open3D.gameObject.SetActive(false);
        
        contentSizeController.ResizeContent();
    }

    void OpenArtistWindow(){
        if(UITabCenter.instance.Prefab_ArtistFlowWindow != null){
            ArtistLayout temp = Instantiate(UITabCenter.instance.Prefab_ArtistFlowWindow, UITabCenter.instance.parentCanvas.transform);
            UITabCenter.instance.flowWindows.Add(temp.GetComponent<PanelWindow>());
            temp.InitInfomations(currentData);
        }
    }
}
