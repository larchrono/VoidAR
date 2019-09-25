using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextHelper : MonoBehaviour
{
    Text _text;
    
    void Awake(){
        _text = GetComponent<Text>();
    }

    public void SetTextFromFloat(float value){
        _text.text = value.ToString("#.###");
    }
}
