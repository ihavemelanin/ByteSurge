using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalBytes : MonoBehaviour
{
    private int ByteCount;
    public GameObject ByteDisplay;
    private float timer = 0.0f;
    private float passiveByteTimer = 1.0f;


    void Start()
    {
        ByteCount = 0;
    }
    void Update()
    {
        //InternalByte = ByteCount;
        ByteDisplay.GetComponent<TextMeshProUGUI>().text = "Bytes: " + ByteCount;
        //passive byte generation
        timer+=Time.deltaTime;
        if(timer >= passiveByteTimer){
            generatePassiveBytes();
            timer = 0.0f;
        }
    
    }







    private void generatePassiveBytes()
    {
        ByteCount += (int)(UpgradeManager.bytePerSecond * combinedMultiplier());
    }
    public float combinedMultiplier(){
        return 1 - UpgradeManager.bpsMultiplier + UpgradeManager.bytePerSecond;
    }


    public int GetByteCount(){
        return ByteCount;
    }
    public void SetByteCount(int newByteCount){
        ByteCount = newByteCount;
    }



    public void AddBytes(int bytesToAdd){
        ByteCount += bytesToAdd;
    }
    public void RemoveBytes(int bytesToRemove){
        ByteCount -= bytesToRemove;
    }
}
