using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] public static int bytePerClick = 1;
    [SerializeField] public static int bytePerSecond = 0;
    [SerializeField] public static int bytePerClickUpgradeCost = 10;
    [SerializeField] public static int bytePerSecondUpgradeCost = 10;
    [SerializeField] GlobalBytes GlobalBytes;
    public GameObject bytePerClickUpgrade;
    public GameObject bytePerSecondUpgrade;



    void Start(){
        bytePerClickUpgrade.GetComponent<TMPro.TextMeshProUGUI>().text = "Buy Byte Per Click Upgrade\nCost: " + bytePerClickUpgradeCost;
        bytePerSecondUpgrade.GetComponent<TMPro.TextMeshProUGUI>().text = "Buy Byte Per Second Upgrade\nCost: " + bytePerSecondUpgradeCost;
    }

    public void BuyBytePerClickUpgrade(){
        if(GlobalBytes.GetByteCount() >= bytePerClickUpgradeCost){
            GlobalBytes.SetByteCount(GlobalBytes.GetByteCount() - bytePerClickUpgradeCost);
            bytePerClick++;
            bytePerClickUpgradeCost = bytePerClickUpgradeCost * 2;
        }
        bytePerClickUpgrade.GetComponent<TMPro.TextMeshProUGUI>().text = "Buy Byte Per Click Upgrade\nCost: " + bytePerClickUpgradeCost;
    }

    public void BuyBytePerSecondUpgrade(){
        if(GlobalBytes.GetByteCount() >= bytePerSecondUpgradeCost){
            GlobalBytes.SetByteCount(GlobalBytes.GetByteCount() - bytePerSecondUpgradeCost);
            bytePerSecond++;
            bytePerSecondUpgradeCost = bytePerSecondUpgradeCost * 2;
        }
        bytePerSecondUpgrade.GetComponent<TMPro.TextMeshProUGUI>().text = "Buy Byte Per Second Upgrade\nCost: " + bytePerSecondUpgradeCost;
    }

}
