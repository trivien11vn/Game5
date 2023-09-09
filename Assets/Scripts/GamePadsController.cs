using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadsController : Singleton<GamePadsController>
{
    public bool isOnMobile;
    bool can_moveLeft;
    bool can_moveRight;

    public bool Can_moveLeft { get => can_moveLeft; set => can_moveLeft = value; }
    public bool Can_moveRight { get => can_moveRight; set => can_moveRight = value; }
    public override void Awake(){
        MakeSingleton(false);
    }
    void PCHandle(){
        can_moveLeft = Input.GetAxisRaw("Horizontal") < 0;
        can_moveRight = Input.GetAxisRaw("Horizontal") > 0;
    }
    public void Update(){
        if(!isOnMobile){
            PCHandle();
        }
    }
}
