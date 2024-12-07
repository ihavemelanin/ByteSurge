using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] public static int bytePerClick = 5; //bytes per click
    [SerializeField] public static float maxBytePerClickMultiplier = 1; //max byte per click multiplier
    [SerializeField] public static int bytePerSecond = 0; //bytes per second
    [SerializeField] public static float bpsMultiplier = 1.0f; //byte per second multiplier
    [SerializeField] public static int bytePerClickUpgradeCost = 10;
    [SerializeField] public static int bytePerSecondUpgradeCost = 10;
    [SerializeField] public static int bpsMultiplierUpgradeCost = 10;
    [SerializeField] public static int maxBytePerClickMultiplierUpgradeCost = 10;
    [SerializeField] GlobalBytes GlobalBytes;
    [SerializeField] AudioClip upgradeSound;
    [SerializeField] AudioSource audioSource;
    public GameObject bytePerClickUpgrade;
    public GameObject bytePerSecondUpgrade;
    public GameObject bpsMultiplierUpgrade;
    public GameObject maxBytePerClickMultiplierUpgrade;





    void Start(){
        bytePerClickUpgrade.GetComponent<TMPro.TextMeshProUGUI>().text = "+5 Byte per Click\nCost: " + bytePerClickUpgradeCost;
        maxBytePerClickMultiplierUpgrade.GetComponent<TMPro.TextMeshProUGUI>().text = "+0.5% Max Byte per Click Multiplier\nCost: " + maxBytePerClickMultiplierUpgradeCost;
        bytePerSecondUpgrade.GetComponent<TMPro.TextMeshProUGUI>().text = "+5 Bytes per Second\nCost: " + bytePerSecondUpgradeCost;
        bpsMultiplierUpgrade.GetComponent<TMPro.TextMeshProUGUI>().text = "+0.5% Byte per Second Multiplier\nCost: " + bpsMultiplierUpgradeCost;
    }

    public void BuyBytePerClickUpgrade(){
        if(GlobalBytes.GetByteCount() >= bytePerClickUpgradeCost){
            GlobalBytes.RemoveBytes(bytePerClickUpgradeCost);
            bytePerClick+=5;
            bytePerClickUpgradeCost = bytePerClickUpgradeCost * 2;
            audioSource.PlayOneShot(upgradeSound);
        }
        bytePerClickUpgrade.GetComponent<TMPro.TextMeshProUGUI>().text = "+5 Byte per Click\nCost: " + bytePerClickUpgradeCost;
    }

    public void BuyMaxBytePerClickMultiplierUpgrade(){
        if(GlobalBytes.GetByteCount() >= maxBytePerClickMultiplierUpgradeCost){
            GlobalBytes.RemoveBytes(maxBytePerClickMultiplierUpgradeCost);
            maxBytePerClickMultiplier+=0.5f;
            maxBytePerClickMultiplierUpgradeCost = maxBytePerClickMultiplierUpgradeCost * 2;
            audioSource.PlayOneShot(upgradeSound);
        }
        maxBytePerClickMultiplierUpgrade.GetComponent<TMPro.TextMeshProUGUI>().text = "+0.5% Max Byte per Click Multiplier\nCost: " + maxBytePerClickMultiplierUpgradeCost;
    }

    public void BuyBytePerSecondUpgrade(){
        if(GlobalBytes.GetByteCount() >= bytePerSecondUpgradeCost){
            GlobalBytes.RemoveBytes(bytePerSecondUpgradeCost);
            bytePerSecond+=5;
            bytePerSecondUpgradeCost = bytePerSecondUpgradeCost * 2;
            audioSource.PlayOneShot(upgradeSound);
        }
        bytePerSecondUpgrade.GetComponent<TMPro.TextMeshProUGUI>().text = "+5 Bytes per Second\nCost: " + bytePerSecondUpgradeCost;
    }

    public void BuyBPSMultiplierUpgrade(){
        if(GlobalBytes.GetByteCount() >= bpsMultiplierUpgradeCost){
            GlobalBytes.RemoveBytes(bpsMultiplierUpgradeCost);
            bpsMultiplier+=0.5f;
            bpsMultiplierUpgradeCost = bpsMultiplierUpgradeCost * 2;
            audioSource.PlayOneShot(upgradeSound);
        }
        bpsMultiplierUpgrade.GetComponent<TMPro.TextMeshProUGUI>().text = "+0.5% Byte per Second Multiplier\nCost: " + bpsMultiplierUpgradeCost;
    }



}
