using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtistLayout : MonoBehaviour
{
    public Image ArtistPhoto;
    public Text ContentText;
    public Text CopyrightText;

    public void InitInfomations(POIData data){
        ArtistPhoto.sprite = data.ArtistPhoto;
        ContentText.text = data.ArtistContent;
        CopyrightText.text = data.ArtistCopyright;
    }

}
