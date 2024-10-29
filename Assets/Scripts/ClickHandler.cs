using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ClickHandler : MonoBehaviour
{
    [SerializeField] GlobalBytes GlobalBytes;
    // Start is called before the first frame update
    void Start(){   
        GlobalBytes.SetByteCount(0);
    }

    public void ClickButton(){
        GlobalBytes.SetByteCount(GlobalBytes.GetByteCount() + UpgradeManager.bytePerClick);
    }

}