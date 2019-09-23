using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AR2DLayout : MonoBehaviour
{
    public static AR2DLayout instance;

    public Button BTNExit;
    public Button BTNShot;
    
    void Awake(){
        instance = this;
    }

    void Start()
    {
        BTNExit.onClick.AddListener(DoExit);
        BTNShot.onClick.AddListener(DoShot);

        gameObject.SetActive(false);
    }

    void DoExit(){
        gameObject.SetActive(false);

    }

    void DoShot(){

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
