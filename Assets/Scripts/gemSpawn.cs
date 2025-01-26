using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemSpawn : MonoBehaviour
{
    public GameObject gemPrefab1;
    public GameObject gemPrefab2;
    public GameObject gemPrefab3;
    public GameObject gemPrefab4;
    public GameObject gemPrefab5;
    public GameObject gemPrefab6;
    private float giftCountDown=50f;
    public float timer; 
    private bool Looping;
    public static bool isBoosting=false;
    public static bool stop=false;
    public float spawnInterval = 2f; 
    public static void boostStatus(bool val){
        isBoosting=val;
    }
    public static void isOver(){
        stop=true;
    }
    void Start(){
        StartCoroutine(CountdownTimer());
    }
    void Update()
    {
        if(!stop){
            timer += Time.deltaTime; 
            if (timer >= spawnInterval)
            {
                SpawnGem(); 
                timer = 0;
            }
        }
    }
    private IEnumerator CountdownTimer()
    {
        while (!stop)
        {
            yield return new WaitForSeconds(1f);
            giftCountDown--; 
        }
    }
    void SpawnGem()
    {
        Looping=true;
        while(Looping){
            Looping=false;
            float randomItem = Random.Range(-100f,100f);
            float randomX = Random.Range(-7.2f, 7.2f);
            Vector3 spawnPosition = new Vector3(randomX, 6f, 0); 
            if(giftCountDown<=0f){
                giftCountDown=50f;
                Instantiate(gemPrefab6, spawnPosition, Quaternion.identity);
                isBoosting=true;
            }
            else if(randomItem>=10f) Instantiate(gemPrefab1, spawnPosition, Quaternion.identity);
            else if(randomItem>=-40f) Instantiate(gemPrefab2, spawnPosition, Quaternion.identity);
            else if(randomItem>=-70f) Instantiate(gemPrefab3, spawnPosition, Quaternion.identity);
            else if(randomItem>=-85f) Instantiate(gemPrefab4, spawnPosition, Quaternion.identity);
            else if(randomItem>=-95f) Instantiate(gemPrefab5, spawnPosition, Quaternion.identity);
            else if(!isBoosting){
                Instantiate(gemPrefab6, spawnPosition, Quaternion.identity);
                isBoosting=true;
                giftCountDown=50f;
            }
            else Looping=true;
        }
    }
}
