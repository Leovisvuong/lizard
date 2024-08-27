using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemMover : MonoBehaviour
{
    private GameObject sound1;
    private GameObject sound2;
    private GameObject sound3;
    public float speed = 5f; 
    public static bool stop=false;
    public static void isOver(){
        stop=true;
    }
    void Start(){
        sound1=GameObject.FindWithTag("sound1");
        sound2=GameObject.FindWithTag("sound2");
        sound3=GameObject.FindWithTag("sound3");
    }
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime); 
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(!stop){
            if (other.gameObject.CompareTag("Player")){
                AudioSource audioSource = sound1.GetComponent<AudioSource>();
                if(gameObject.tag=="gems") ScoreManage.AddScore(1);
                else if(gameObject.tag=="exgems") ScoreManage.AddScore(2);
                else if(gameObject.tag=="supgems") ScoreManage.AddScore(3);
                else if(gameObject.tag=="poison"){
                    ScoreManage.MinusHP(15);
                    audioSource = sound2.GetComponent<AudioSource>();
                }
                else if(gameObject.tag=="mushroom"){
                    ScoreManage.MinusHP(3);
                    audioSource = sound2.GetComponent<AudioSource>();
                }
                else if(gameObject.tag=="box"){
                    audioSource = sound3.GetComponent<AudioSource>();
                    Vector3 spawnPosition = new Vector3(-7.2f, 4.3f, 0);
                    float randomBoost=Random.Range(1f,99f);
                    if(randomBoost>=66f) speedUp.setTime();
                    else if(randomBoost>=33f) DoubleJump.setTime();
                    else MegaStomach.setTime();
                }
                audioSource.Play();
                Destroy(gameObject); 
            }
            else if (other.gameObject.CompareTag("ground")){
                Destroy(gameObject); 
            }
        }
    }
}
