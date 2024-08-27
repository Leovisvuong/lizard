using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    private int JumpTime=2;
    [SerializeField] private Rigidbody2D rigid;
    public static bool stop=false;
    public static void isOver(){
        stop=true;
    }
    public bool moveLeft;
    public bool moveRight;
    private Animator animator;
    public bool inGround;
    public float jumpSpeed;
    public static float speed=7f;
    public static bool canDoubleJump=false;
    public static void Boost(int typeBoost){
        if(typeBoost==1){
            speed=10f;
            gemSpawn.boostStatus(true);
        }
        else if(typeBoost==2){
            gemSpawn.boostStatus(true);
            canDoubleJump=true;
        }
        else if(typeBoost==3){
            gemSpawn.boostStatus(true);
            ScoreManage.changeBoostAmount(2);
        }
        else{
            gemSpawn.boostStatus(false);
            speed=7f;
            ScoreManage.changeBoostAmount(1);
            canDoubleJump=false;
        }
    }
    void Start()
    {
        animator=GetComponent<Animator>();
    }
    void Update()
    {
        if(!stop){
            var currentVelocity=rigid.velocity;
            var currentPosition=gameObject.transform.position;
            if(Input.GetKey(KeyCode.RightArrow)){
                if(currentPosition.x<=7.2f) currentVelocity.x=speed;
                else currentVelocity.x=0;
                if(Input.GetKeyDown(KeyCode.LeftArrow)){
                    moveLeft=true;
                    moveRight=false;
                }
                else{
                    moveLeft=false;
                    moveRight=true;
                }
            }
            else if(Input.GetKey(KeyCode.LeftArrow)){
                if(currentPosition.x>=-7.2f) currentVelocity.x=-speed;
                else currentVelocity.x=0;
                if(Input.GetKeyDown(KeyCode.RightArrow)){
                    moveLeft=false;
                    moveRight=true;
                }
                else{
                    moveLeft=true;
                    moveRight=false;
                }
            }
            else{
                moveLeft=false;
                moveRight=false;
                currentVelocity.x=0;
            }
            if(canDoubleJump&&Input.GetKeyDown(KeyCode.UpArrow)&&JumpTime<3){
                JumpTime++;
                currentVelocity.y=jumpSpeed;
                currentVelocity.x+=1;
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow)&&inGround) currentVelocity.y=jumpSpeed;
            rigid.velocity=currentVelocity;
            animator.SetBool("moveLeft",moveLeft);
            animator.SetBool("moveRight",moveRight);
        }
        else{
            animator.SetBool("die",true);
            var currentVelocity=rigid.velocity;
            currentVelocity.x=0;
            rigid.velocity=currentVelocity;
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("ground")){
            inGround=true;
            JumpTime=1;
        }
    }
    void OnCollisionExit2D(Collision2D other){
        inGround=false;
    }
}
