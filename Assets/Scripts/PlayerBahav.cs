using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBahav : MonoBehaviour {

    public float superSpeed = 4f;
    public float speed = 20;
    public Sprite Up;
    public Sprite Right;
    public Sprite Down;
    public Sprite Left;
    public Sprite UpLeft;
    public Sprite UpRight;
    public Sprite DownRight;
    public Sprite DownLeft;
    Vector2 position1 = new Vector2(0,0);
    Vector2 position2;
    float directionX;
    float directionY;
    string spriteHelp;
    bool isSuperSpeed = false;

    private void FixedUpdate() {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
        if(!isSuperSpeed) {
            isSuperSpeed = CrossPlatformInputManager.GetButtonDown("BuSuperSpeed");
            GetComponent<Rigidbody2D>().velocity = moveVec.normalized * speed;
        } else {
            GetComponent<Rigidbody2D>().velocity = moveVec.normalized * speed;
            if(CrossPlatformInputManager.GetButtonUp("BuSuperSpeed")) isSuperSpeed = false;
        }
        
        position2 = transform.position;
        directionX = position2.x - position1.x;
        directionY = position2.y - position1.y;
        GetComponent<Animator>().enabled = true;
       
        if(directionX < 0) {  //LEFT
            if(directionY < 0) {  //DOWN
                if(directionY <= directionX) {  //DOWN
                    Direction(false, false, -directionY / -directionX >= 3.3, false, false, false, false, -directionY / -directionX < 3.3);
                    if(-directionY / -directionX >= 2.5) spriteHelp = "Down";
                    if(-directionY / -directionX < 2.5) spriteHelp = "DownLeft";
                } else {  //LEFT
                    Direction(false, false, false, -directionY / -directionX < 0.33, false, false, false, -directionY / -directionX >= 0.33);
                    if(-directionY / -directionX < 0.4) spriteHelp = "Left";
                    if(-directionY / -directionX >= 0.4) spriteHelp = "DownLeft";
                }
            } else {  //UP
                if(directionY >= -directionX) {  //UP
                    Direction(directionY / -directionX >= 3.3, false, false, false, directionY / -directionX < 3.3, false, false, false);
                    if(directionY / -directionX >= 2.5) spriteHelp = "Up";
                    if(directionY / -directionX < 2.5) spriteHelp = "UpLeft";
                } else {  //LEFT
                    Direction(false, false, false, directionY / -directionX < 0.33, directionY / -directionX >= 0.33, false, false, false);
                    if(directionY / -directionX < 0.4) spriteHelp = "Left";
                    if(directionY / -directionX >= 0.4) spriteHelp = "UpLeft";
                }
            } 
        } else if(directionX > 0) {  //RIGHT
            if(directionY < 0) {  //DOWN
                if(-directionY < directionX) {  //RIGHT
                    Direction(false, -directionY / directionX < 0.33, false, false, false, false, -directionY / directionX >= 0.33, false);
                    if(-directionY / directionX < 0.4) spriteHelp = "Right";
                    if(-directionY / directionX >= 0.4) spriteHelp = "DownRight";
                } else {  //DOWN
                    Direction(false, false, -directionY / directionX >= 3.3, false, false, false, -directionY / directionX < 3.3, false);
                    if(-directionY / directionX >= 2.5) spriteHelp = "Down";
                    if(-directionY / directionX < 2.5) spriteHelp = "DownRight";
                }
            } else {  //UP
                if(directionY >= directionX) {  //UP
                    Direction(directionY / directionX >= 3.3, false, false, false, false, directionY / directionX < 3.3, false, false);
                    if(directionY / directionX >= 2.5) spriteHelp = "Up";
                    if(directionY / directionX < 2.5) spriteHelp = "UpRight";
                } else {  //RIGHT
                    Direction(false, directionY / directionX < 0.33, false, false, false, directionY / directionX >= 0.33, false, false);
                    if(directionY / directionX < 0.4) spriteHelp = "Right";
                    if(directionY / directionX >= 0.4) spriteHelp = "UpRight";
                }
            }
        } else {  //NO MOVEMENT
            Direction(false, false, false, false, false, false, false, false);
            GetComponent<Animator>().enabled = false;
            if(spriteHelp == "Up") GetComponent<SpriteRenderer>().sprite = Up;
            if(spriteHelp == "Right") GetComponent<SpriteRenderer>().sprite = Right;
            if(spriteHelp == "Down") GetComponent<SpriteRenderer>().sprite = Down;
            if(spriteHelp == "Left") GetComponent<SpriteRenderer>().sprite = Left;
            if(spriteHelp == "UpLeft") GetComponent<SpriteRenderer>().sprite = UpLeft;
            if(spriteHelp == "UpRight") GetComponent<SpriteRenderer>().sprite = UpRight;
            if(spriteHelp == "DownRight") GetComponent<SpriteRenderer>().sprite = DownRight;
            if(spriteHelp == "DownLeft") GetComponent<SpriteRenderer>().sprite = DownLeft;
        }
        position1 = transform.position;
    }

    void Direction(bool bool1, bool bool2, bool bool3, bool bool4, bool bool5, bool bool6, bool bool7, bool bool8) {
        GetComponent<Animator>().SetBool("isGoingUp", bool1);
        GetComponent<Animator>().SetBool("isGoingRight", bool2);
        GetComponent<Animator>().SetBool("isGoingDown", bool3);
        GetComponent<Animator>().SetBool("isGoingLeft", bool4);
        GetComponent<Animator>().SetBool("isGoingUpLeft", bool5);
        GetComponent<Animator>().SetBool("isGoingUpRight", bool6);
        GetComponent<Animator>().SetBool("isGoingDownRight", bool7);
        GetComponent<Animator>().SetBool("isGoingDownLeft", bool8);
    }
}
