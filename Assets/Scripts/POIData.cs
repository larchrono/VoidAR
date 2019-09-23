using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Ideafixxxer.CsvParser;

[RequireComponent(typeof(SphereCollider))]
public class POIData : MonoBehaviour
{
    public SpriteRenderer Icon;
    public Transform GizmoColliRange;
    SphereCollider eventCollider;
    public TypeOfPOI typeOfPOI;

    [Header("POI Datas") , Space(40)]
    public string POI_Name;
    [HideInInspector] public Sprite spriteLoc;
    public string ArtistName;
    public string ArtworkName;
    public string ArtSize;
    public string ArtAge;
    public string ArtMaterial;
    public Sprite ArtPhoto;
    [TextArea] public string ArtContent;
    public string ArtCopyright;

    //Artist Info
    [Header("Artist Info")]
    public Sprite ArtistPhoto;
    [TextArea] public string ArtistContent;
    public string ArtistCopyright;
    public GameObject UseModel;

    [Header("Old Picture")]
    public string ViewpointName;
    public string ViewpointContent;
    public Sprite ViewpointPhoto;
    public string PhotoAge;
    public string PhotoSource;
    public GameObject UseMask;


    void Start()
    {
        eventCollider = GetComponent<SphereCollider>();
        MapController.CollisionRangeHandler += OnCollisionRangeHandler;
        spriteLoc = Icon.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionRangeHandler(float src){
        eventCollider.radius = src;

        if(GizmoColliRange)
            GizmoColliRange.localScale = new Vector3(src * 2, src * 2, src * 2);
    }

    [Space(40)] public TextAsset csvFile;
    public int csvIndex = 1;
    [Button]
    public void ImportPOIData(){
        if(csvFile == null)
            return;

        //讀入 CSV 檔案，使其分為 string 二維陣列
        CsvParser csvParser = new CsvParser();
        string[][] csvTable = csvParser.Parse(csvFile.text);

        ArtistName = csvTable[csvIndex][0]; // Artist Name
        ArtworkName = csvTable[csvIndex][1]; // Artwork Name
        ArtSize = csvTable[csvIndex][2]; // Art Size
        ArtAge = csvTable[csvIndex][3]; // Art Age
        ArtMaterial = csvTable[csvIndex][4]; // Art Material
        ArtCopyright = csvTable[csvIndex][5]; // Art Coptright
        ArtistCopyright = csvTable[csvIndex][6]; // Artist Copyright
        ArtistContent = csvTable[csvIndex][7]; // Artist Info
        ArtContent = csvTable[csvIndex][8]; // Art Info
    }
    [Button]
    public void POINameToArtistName(){
        POI_Name = ArtworkName;
    }


    public enum TypeOfPOI {
        AR,
        OldPicture,
        Bus,
        ArtGallery
    }
}
