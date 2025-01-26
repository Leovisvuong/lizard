using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gemMover : MonoBehaviour
{
    private GameObject sound1;
    private GameObject sound2;
    private GameObject sound3;
    public TextMeshProUGUI scoreEvent;
    public Transform Player;
    [SerializeField] private GameObject SpeedUpUI;
    [SerializeField] private GameObject DoubleJumpUI;
    [SerializeField] private GameObject MegaStomachUI;
    public float speed = 5f; 
    public static bool stomachBoost;
    public static bool stop=false;
    public static void isOver(){
        stop=true;
    }
    public static void SetStomachBoost(bool value){
        stomachBoost=value;
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
                if(gameObject.tag=="gems"){
                    ScoreManage.AddScore(1);
                    scoreEvent.text="1";
                    if(stomachBoost) scoreEvent.text="2";
                    scoreEvent.color = Color.green;
                    scoreEvent.transform.position=Player.position;
                }
                else if(gameObject.tag=="exgems"){
                    ScoreManage.AddScore(2);
                    scoreEvent.text="2";
                    if(stomachBoost) scoreEvent.text="4";
                    scoreEvent.color = Color.green;
                    scoreEvent.transform.position=Player.position;
                }
                else if(gameObject.tag=="supgems"){
                    ScoreManage.AddScore(3);
                    scoreEvent.text="3";
                    if(stomachBoost) scoreEvent.text="6";
                    scoreEvent.color = Color.green;
                    scoreEvent.transform.position=Player.position;
                }

                else if(gameObject.tag=="poison"){
                    ScoreManage.MinusHP(15);
                    scoreEvent.text="15";
                    scoreEvent.color = Color.red;
                    scoreEvent.transform.position=Player.position;
                    audioSource = sound2.GetComponent<AudioSource>();
                }
                else if(gameObject.tag=="mushroom"){
                    ScoreManage.MinusHP(3);
                    scoreEvent.text="3";
                    scoreEvent.color = Color.red;
                    scoreEvent.transform.position=Player.position;
                    audioSource = sound2.GetComponent<AudioSource>();
                }
                else if(gameObject.tag=="box"){
                    audioSource = sound3.GetComponent<AudioSource>();
                    Vector3 spawnPosition = new Vector3(-7.2f, 4.3f, 0);
                    float randomBoost=Random.Range(1f,99f);
                    if(randomBoost>=66f){
                        SpeedUpUI.SetActive(true);
                    }
                    else if(randomBoost>=33f){
                        DoubleJumpUI.SetActive(true);
                    }
                    else MegaStomachUI.SetActive(true);
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
