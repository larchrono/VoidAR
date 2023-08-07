﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineDataManager : HimeLib.SingletonMono<OnlineDataManager>
{
    public string webService;
    public string sheetID;
    public string POI_pageID;
    public string Infos_PageID;

    public void PostDataToSheet(params string [] data){
        DownloadManager.GoogleWriteLastLine(webService, sheetID, POI_pageID, data);
    }
}
