using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManage : MonoBehaviour
{
    public GameObject GameOverPanel; 
    private GameObject soundOver;
    public TextMeshProUGUI GameOverText;
    public static int boostAmount=1;
    public static float score = 0;
    private bool stop=false;
    private bool audioplayed=false;
    public static float remainingHP=30f;
    public TextMeshProUGUI scoreText; 
    public static void changeBoostAmount(int amount){
        boostAmount=amount;
    }
    public static void AddScore(int amount) 
    {
        amount*=boostAmount;
        if(remainingHP+amount<=30){
            remainingHP += amount;
            score++;
        }
        else{
            remainingHP=30;
            score+=remainingHP+amount-30f;
        }
    }
    public static void MinusHP(int amount) 
    {
        remainingHP -= amount;
    }
    void Start(){
        StartCoroutine(CountdownTimer());
        soundOver=GameObject.FindWithTag("sound4");
    }
	void Update()
    {
        scoreText.text = "Score: " + score + "\nHungry: " + Mathf.CeilToInt(remainingHP) + "/30"; 
        if(remainingHP<=0){
            if(!audioplayed){
                AudioSource audiosource = soundOver.GetComponent<AudioSource>();
                audiosource.Play();
                audioplayed=true;
            }
            GameOver();
            remainingHP=0;
        }
    }
    private IEnumerator CountdownTimer()
    {
        while (!stop)
        {
            yield return new WaitForSeconds(1f);
            remainingHP--; 
        }
    }
    private void GameOver()
    {
        GameOverText.text = "Game Over!\nScore: " + score;
        GameOverPanel.SetActive(true);
        StopAll();
    }
    private void StopAll(){
        stop=true;
        mover.isOver();
        gemSpawn.isOver();
        gemMover.isOver();
        speedUp.isOver();
        DoubleJump.isOver();
        MegaStomach.isOver();
    }
}

