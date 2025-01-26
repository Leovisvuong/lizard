using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DoubleJump : MonoBehaviour
{
    public static float timeLeft=-1f;
    public bool isActive;
    public TextMeshProUGUI timeText; 
    void Update()
    {
        if(timeLeft<0 && !isActive){
            timeLeft=20;
        }
        else{
            if(!isActive){
                StartCoroutine(CountdownTimer());
                isActive=true;
            }
            timeText.text=timeLeft+" s";
            mover.Boost(2);
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
