using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalBytes : MonoBehaviour
{
    private int ByteCount;
    public GameObject ByteDisplay;
    public int InternalByte;
    private float timer = 0.0f;
    private float passiveByteTimer = 1.0f;

    void Update()
    {
        InternalByte = ByteCount;
        ByteDisplay.GetComponent<TextMeshProUGUI>().text = "Bytes: " + InternalByte;
        //passive byte generation
        timer+=Time.deltaTime;
        if(timer >= passiveByteTimer){
            ByteCount += UpgradeManager.bytePerSecond;
            timer = 0.0f;
        }
    
    }











    public int GetByteCount(){
        return ByteCount;
    }
    public void SetByteCount(int newByteCount){
        ByteCount = newByteCount;
    }
}
