using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class speedUp : MonoBehaviour
{
    public static float timeLeft=0f;
    public static bool stop=false;
    public TextMeshProUGUI timeText; 
    public static void isOver(){
        stop=true;
    }
    public static void setTime(){
        timeLeft=20f;
    }
    void Start(){
        StartCoroutine(CountdownTimer());
        var currentPosition=transform.position;
        currentPosition.x=-50f;
        currentPosition.y=4.3f;
        transform.position=currentPosition;
    }
    void Update()
    {
        var currentPosition=transform.position;
        if(timeLeft<=0f){
            if(timeLeft==0f) mover.Boost(0);
            timeText.text=" ";
            currentPosition.x=-50f;
        }
        else{
            currentPosition.x=-7.2f;
            timeText.text=timeLeft+" s";
            mover.Boost(1);
        }
        transform.position=currentPosition;
    }
    private IEnumerator CountdownTimer()
    {
        while(!stop){
            yield return new WaitForSeconds(1f);
            timeLeft--;
        } 
    }

}
