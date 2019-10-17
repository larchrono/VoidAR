using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPreMessage : MonoBehaviour
{
    public MapNav GoogleMap;
    void Start()
    {
        GoogleMap.OnMapReady += OnMapReady;
    }

    void OnMapReady(){
        GoogleMap.OnMapReady -= OnMapReady;
        Destroy(gameObject);
    }
}
