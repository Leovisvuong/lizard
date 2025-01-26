using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreEventManager : MonoBehaviour
{
    public TextMeshProUGUI myText;
    private bool isActive;
    void Update(){
        if(myText.text!=" " && !isActive){
            StartCoroutine(CountDownTimer());
            transform.position+= new Vector3(0,1,0);
            isActive=true;
        }
        transform.position+=new Vector3(0,0.001f,0);
    }
    private IEnumerator CountDownTimer(){
        yield return new WaitForSeconds(0.5f);
        myText.text=" ";
        isActive=false;
    }
}
