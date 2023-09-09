using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D m_rb;
    Animator m_anim;
    bool is_dead;
    private void Awake(){
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
    }
    private void FixedUpdate(){
        if(is_dead && m_rb){
            m_rb.velocity = new Vector2 (0f, m_rb.velocity.y);
        }
        if(is_dead || !GameManager.Ins.IsGameBegin){
            return;
        }
        MoveHandle();
        ChangeFace();
        transform.position = new Vector3 (
            Math.Clamp(transform.position.x, -8.5f, 8.5f),
            transform.position.y,
            transform.position.z
        );
    }
    void MoveHandle(){
        if(GamePadsController.Ins.Can_moveLeft){
            if(m_rb){
                m_rb.velocity = new Vector2(-1f, m_rb.velocity.y) * moveSpeed;
            }
            if(m_anim){
                m_anim.SetBool("Run",true);
            }
        }
        else if(GamePadsController.Ins.Can_moveRight){
            if(m_rb){
                m_rb.velocity = new Vector2(1f, m_rb.velocity.y) * moveSpeed;
            }
            if(m_anim){
                m_anim.SetBool("Run",true);
            }
        }
        else{
            if(m_rb){
                m_rb.velocity = new Vector2(0, m_rb.velocity.y);
            }
            if(m_anim){
                m_anim.SetBool("Run",false);
            }
        }
    }
    void ChangeFace(){
        if(GamePadsController.Ins.Can_moveLeft){
            if(transform.localScale.x>0){
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else if(GamePadsController.Ins.Can_moveRight){
            if(transform.localScale.x<0){
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }
    void Dead(){
        if(m_anim){
            m_anim.SetTrigger("Dead");
        }
        if(m_rb){
            m_rb.velocity = new Vector2(0f, m_rb.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Rock")){
            if(is_dead){
                return;
            }
            else{
                Stone stone = col.gameObject.GetComponent<Stone>();
                if(stone && !stone.m_isground){
                    Dead();
                    GameManager.Ins.IsGameOver = true;
                    is_dead = true;
                    AudioController.Ins.PlaySound(AudioController.Ins.loseSound);
                    AudioController.Ins.PlaySound(AudioController.Ins.landSound);
                    GameUIManager.Ins.ShowGameOver(true);
                }
            }
        }
    }
}
