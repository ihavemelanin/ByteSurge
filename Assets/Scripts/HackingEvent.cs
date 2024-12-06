using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HackingEvent : MonoBehaviour
{
    public Slider HackProgressSlider;
    public Button endHackButton;
    [SerializeField] public float hackDuration = 10.0f;
    private float remainingTime = 0.0f;
    [SerializeField] GlobalBytes GlobalBytes;
    private bool gettingHacked = false;
    private bool HackScheduled = false;
    public TextMeshProUGUI hackText;
    public TextMeshProUGUI hackText2;

    void Start()
    {
        remainingTime = 0.0f;
        endHackButton.gameObject.SetActive(false);
        HackProgressSlider.gameObject.SetActive(false);
        hackText.gameObject.SetActive(false);
        hackText2.gameObject.SetActive(false);
        gettingHacked = false;
        HackScheduled = false;
        ScheduleNextHack();
    }

    void Update()
    {
        if(gettingHacked){
            UpdateHackProgress();
        }
        else if(gettingHacked == false && HackScheduled == false){
            ScheduleNextHack();
        }
    }

    private void ScheduleNextHack()
    {
        Invoke("StartHack", Random.Range(5.0f, 10.0f));
        HackScheduled = true;
    }
    public void StartHack()
    {
        endHackButton.gameObject.SetActive(true); // show the end hack button
        HackProgressSlider.gameObject.SetActive(true); // show the slider
        hackText.gameObject.SetActive(true);
        hackText2.gameObject.SetActive(true);
        hackText.text = "Hacking in Progress!!!" + "\n" + "Time Remaining: " + hackDuration + "s";
        hackText2.text = "End Hack or lose 20% bytes!";
        remainingTime = hackDuration; // reset the timer
        HackProgressSlider.value = HackProgressSlider.maxValue; // set the slider to full
        gettingHacked = true;
    }

    public void EndHack()
    {
        remainingTime = 0.0f;
        HackProgressSlider.value = 0.0f;
        endHackButton.gameObject.SetActive(false);
        HackProgressSlider.gameObject.SetActive(false);
        hackText.gameObject.SetActive(false);
        hackText2.gameObject.SetActive(false);
        HackScheduled = false;
        gettingHacked = false;
    }

    private void FailHack(){
        Debug.Log("Hack Failed! Losing 20% of bytes.");
        GlobalBytes.RemoveBytes((int)(GlobalBytes.GetByteCount() * 0.15f));
        EndHack();
    }

    public void UpdateHackProgress(){
        if (remainingTime > 0.0f)
        {
            remainingTime -= Time.deltaTime;
            HackProgressSlider.value = remainingTime / hackDuration;
            hackText.text = "Hacking in Progress!!!" + "\n" + "Time Remaining: " + remainingTime.ToString() + "s";
            //hackText2.text = "End Hack or lose 15% bytes!";
        }
        else
        {
            FailHack();
        }
    }







}
