using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public static MapController instance;
    public static Action<float> CollisionRangeHandler;

    public Text CollisionText;
    public Slider CollisionRange;

    void Awake(){
        instance = this;
    }

    void Start()
    {
        if(CollisionRange)
            CollisionRange.onValueChanged.AddListener(OnCollisionRangeChange);
        
        float val = PlayerPrefs.GetFloat("Collision", 10);

        if(CollisionText)
            CollisionText.text = val.ToString("#.###");
    }

    void OnCollisionRangeChange(float src){
        CollisionRangeHandler?.Invoke(src);
        PlayerPrefs.SetFloat("Collision", src);
    }
}
