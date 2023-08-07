using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POICreatorComp : MonoBehaviour
{
    POIData danetPOI;
    SetGeolocation geoData;
    void Start()
    {
        danetPOI = GetComponent<POIData>();
        geoData = GetComponent<SetGeolocation>();

        CreatePOI(danetPOI.POI_Name, geoData.lat, geoData.lon, danetPOI.POI_Name, danetPOI.ArtContent);
    }

    public void CreatePOI(string poiName, double Lat_Obj, double Lon_Obj, string title, string content){
        //GameObject poi = new GameObject();
        gameObject.tag = "POI";
        POI.POIData data = gameObject.AddComponent<POI.POIData>();
        data.POI_Name = poiName;
        data.Latitude = Lat_Obj;
        data.Longitude = Lon_Obj;
        data.Title = title;
        data.Content = content;
        data.oldData = danetPOI;
        //data.Media = media;

        //poi.transform.parent = transform;
        gameObject.name = $"POI_{danetPOI.typeOfPOI}_{danetPOI.POI_Name}";
    }
}
