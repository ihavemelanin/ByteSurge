using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ClickHandler : MonoBehaviour
{
    [SerializeField] GlobalBytes GlobalBytes;

    //combo system
    public int currentCombo = 0;
    public static float comboMultiplier = 1.0f;
    public float maxMultiplier = 2.0f;
    public int maxCombo = 0;

    //max time between clicks to count as a combo
    public float maxComboTime = 2.0f;
    //time of last click
    public float lastClickTime = 0.0f;


    public TextMeshProUGUI comboText;
    public TextMeshProUGUI currentMultiplierText;
    public TextMeshProUGUI bpsMultiplierText;
    public TextMeshProUGUI maxComboText;
    public TextMeshProUGUI maxClickMultiplierText;
    public TextMeshProUGUI bytesPerClickText;
    public TextMeshProUGUI bytesPerSecondText;









    // Start is called before the first frame update
    void Update(){
        
        maxMultiplier = UpgradeManager.maxBytePerClickMultiplier; //update max multiplier

        //update combo text
        if(Time.time - lastClickTime > maxComboTime){
            currentCombo = 0;
            comboMultiplier = 1.0f;
        }
        comboText.text = "Combo: " + currentCombo + "x";
        maxComboText.text = "Max Combo: " + maxCombo + "x";
        currentMultiplierText.text = "Current Multiplier: " + comboMultiplier + "x";
        bpsMultiplierText.text = "Byte Per Second Multiplier: " + UpgradeManager.bpsMultiplier + "x";
        maxClickMultiplierText.text = "Max Byte Per Click Multiplier: " + UpgradeManager.maxBytePerClickMultiplier + "x";
        bytesPerClickText.text = "Bytes Per Click: " + UpgradeManager.bytePerClick;
        bytesPerSecondText.text = "Bytes Per Second: " + UpgradeManager.bytePerSecond + " x " + GlobalBytes.combinedMultiplier() + " = " + (int)(UpgradeManager.bytePerSecond * GlobalBytes.combinedMultiplier());

        
    }

    public void ClickButton(){
        if(Time.time - lastClickTime <= maxComboTime){ //if the time between clicks is less than the max combo time
            currentCombo++;
            if(currentCombo > maxCombo){
                maxCombo = currentCombo; //update max combo
            }
            comboMultiplier = 1.0f + (currentCombo * 0.1f); 
            comboMultiplier = Mathf.Min(comboMultiplier, maxMultiplier);
        }
        int bytesEarned = (int)(UpgradeManager.bytePerClick * comboMultiplier); //calculate bytes earned
        GlobalBytes.AddBytes(bytesEarned); //add bytes to the total
        lastClickTime = Time.time;
    }

}