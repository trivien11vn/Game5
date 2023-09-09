using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D m_rb;
    public bool m_isground;

    public bool Isground { get => m_isground;}
    private void Awake(){
        m_rb = GetComponent<Rigidbody2D>();
   }
    private void FixedUpdate(){
        if(m_rb){
            m_rb.velocity = Vector3.down * moveSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Ground")){
            m_isground = true;
            Destroy(gameObject,1f);
            GameManager.Ins.Score++;
            AudioController.Ins.PlaySound(AudioController.Ins.landSound);
            GameUIManager.Ins.UpdateScore(GameManager.Ins.Score);
        }
    }
}
