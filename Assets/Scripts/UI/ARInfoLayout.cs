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
    Vector3 ContentTextPos;
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

        Open2D.onClick.AddListener(OpenAR2D);
        Open3D.onClick.AddListener(OpenAR3D);

        ContentTextPos = ContentText.rectTransform.localPosition;
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

    void OpenAR2D(){
        if(currentData.UseModel != null) {
            UITabCenter.instance.AR2DPanel.SetupArtwork(currentData.UseModel);
        } else if (currentData.UseMask != null) {
            UITabCenter.instance.AR2DPanel.SetupStreetPhoto(currentData.UseMask);
        }
        UITabCenter.instance.AR2DPanel.gameObject.SetActive(true);
        UITabCenter.instance.AR2DPanel.StartAR2D();
    }

    void OpenAR3D(){
        if(currentData.UseModel != null) {
            UITabCenter.instance.AR3DPanel.SetupArtwork(currentData.UseModel);
        } else if (currentData.UseMask != null) {
            UITabCenter.instance.AR3DPanel.SetupStreetPhoto(currentData.UseMask);
        }
        UITabCenter.instance.AR3DPanel.gameObject.SetActive(true);
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
        ArtworkInfo.Artist.text = currentData.ArtistName;
        ArtworkInfo.Artwork.text = currentData.ArtworkName;
        ArtworkInfo.MaterialInfo.text = currentData.ArtMaterial;
        ArtworkInfo.SizeInfo.text = currentData.ArtSize;
        ArtworkInfo.Age.text = currentData.ArtAge;

        ContentText.text = currentData.ArtContent;
        CopyrightText.text = currentData.ArtCopyright;

        ContentText.rectTransform.localPosition = ContentTextPos;

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
        ArtworkInfo.Artist.text = currentData.PhotoSource;
        ArtworkInfo.Artwork.text = currentData.PhotoAge;
        ArtworkInfo.MaterialInfo.text = "";
        ArtworkInfo.SizeInfo.text = "";
        ArtworkInfo.Age.text = "";

        ContentText.text = currentData.ViewpointContent;
        CopyrightText.text = "";

        ContentText.rectTransform.localPosition = ContentTextPos;

        Open2D.gameObject.SetActive(true);
        Open3D.gameObject.SetActive(true);
        
        contentSizeController.ResizeContent();
    }

    public void RefreshInfoBus_FromPOI(){
        Title.text = currentData.POI_Name;
        MapIcon.sprite = currentData.spriteLoc;

        ContentPhoto.enabled = true;
        ContentPhoto.sprite = currentData.ArtPhoto;
        ContentPhotoInText.text = "";

        ArtworkLink.interactable = false;
        ArtworkInfo.Artist.text = currentData.ArtistName;
        ArtworkInfo.Artwork.text = "";
        ArtworkInfo.MaterialInfo.text = "";
        ArtworkInfo.SizeInfo.text = "";
        ArtworkInfo.Age.text = "";
        
        ContentText.text = currentData.ArtContent;
        CopyrightText.text = "";

        ContentText.rectTransform.localPosition = new Vector3(ContentTextPos.x, ContentTextPos.y + 180, ContentTextPos.z);

        Open2D.gameObject.SetActive(false);
        Open3D.gameObject.SetActive(false);
        
        contentSizeController.ResizeContent();
    }

    public void RefreshInfoGallery_FromPOI(){
        Title.text = currentData.POI_Name;
        MapIcon.sprite = currentData.spriteLoc;

        ContentPhotoInText.text = "";
        ContentText.text = "";
        CopyrightText.text = "";

        ContentPhoto.sprite = currentData.ArtPhoto;
        if(ContentPhoto.sprite != null){
            ContentPhoto.enabled = true;
            ContentText.text = currentData.ArtContent;
            ContentText.rectTransform.localPosition = new Vector3(ContentTextPos.x, ContentTextPos.y + 580, ContentTextPos.z);
        } else {
            ContentPhoto.enabled = false;
            ContentPhotoInText.text = currentData.ArtContent;
            ContentText.rectTransform.localPosition = new Vector3(ContentTextPos.x, ContentTextPos.y + 880, ContentTextPos.z);
        }
        

        ArtworkLink.interactable = false;
        ArtworkInfo.Artist.text = "";
        ArtworkInfo.Artwork.text = "";
        ArtworkInfo.MaterialInfo.text = "";
        ArtworkInfo.SizeInfo.text = "";
        ArtworkInfo.Age.text = "";

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
