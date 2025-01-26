using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class speedUp : MonoBehaviour
{
    public static float timeLeft=-1f;
    private bool isActive;
    public TextMeshProUGUI timeText; 
    void Update()
    {
        if(timeLeft<0f && !isActive){
            timeLeft=20;
        }
        else{
            if(!isActive){
                StartCoroutine(CountdownTimer());
                isActive=true;
            }
            timeText.text=timeLeft+" s";
            mover.Boost(1);
        }
    }
    private IEnumerator CountdownTimer()
    {
        while(timeLeft>=0){
            yield return new WaitForSeconds(1f);
            timeLeft--;
        } 
        mover.Boost(0);
        timeText.text=" ";
        isActive=false;
        gameObject.SetActive(false);
    }

}
