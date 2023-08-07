﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapTool : MonoBehaviour
{
    public Button AimToMap;
    public Button AimToUser;

    [SerializeField]
    double defaultMapLon = 0;
    [SerializeField]
    double defaultMapLat = 0;

    void Start(){
        AimToMap?.onClick.AddListener(DoAimToMap);
        AimToUser?.onClick.AddListener(DoAimToUser);

        OnlineMaps.instance.GetPosition(out defaultMapLon, out defaultMapLat);
    }

    void DoAimToMap(){
        OnlineMaps.instance.SetPosition(defaultMapLon, defaultMapLat);
    }

    void DoAimToUser(){
        AimToCurrentLocat();
    }

    // 使用者目前位置系統
    /// <summary>
    /// Move duration (sec)
    /// </summary>
    public float SlideTime = 0.5f;

    /// <summary>
    /// Relative position (0-1) between from and to
    /// </summary>
    private float angle;

    /// <summary>
    /// Movement trigger
    /// </summary>
    private bool isMovement;
    Vector2 fromPosition, toPosition;
    double fromTileX, fromTileY, toTileX, toTileY;
    int moveZoom;

    public void AimToCurrentLocat(){
        // from current map position
        fromPosition = OnlineMaps.instance.position;

        // to GPS position;
        toPosition = OnlineMapsLocationService.instance.position;

        // calculates tile positions
        moveZoom = OnlineMaps.instance.zoom;
        OnlineMaps.instance.projection.CoordinatesToTile(fromPosition.x, fromPosition.y, moveZoom, out fromTileX, out fromTileY);
        OnlineMaps.instance.projection.CoordinatesToTile(toPosition.x, toPosition.y, moveZoom, out toTileX, out toTileY);

        // if tile offset < 4, then start smooth movement
        if (OnlineMapsUtils.Magnitude(fromTileX, fromTileY, toTileX, toTileY) < 4)
        {
            // set relative position 0
            angle = 0;

            // start movement
            isMovement = true;
        }
        else // too far
        {
            OnlineMaps.instance.SetPositionAndZoom(toPosition.x, toPosition.y, 18);
        }
    }

    private void Update()
    {
        // if not movement then return
        if (!isMovement) return;

        // update relative position
        angle += Time.deltaTime / SlideTime;

        if (angle > 1)
        {
            // stop movement
            isMovement = false;
            angle = 1;
        }

        // Set new position
        double px = (toTileX - fromTileX) * angle + fromTileX;
        double py = (toTileY - fromTileY) * angle + fromTileY;
        OnlineMaps.instance.projection.TileToCoordinates(px, py, moveZoom, out px, out py);
        OnlineMaps.instance.SetPosition(px, py);
    }
}
