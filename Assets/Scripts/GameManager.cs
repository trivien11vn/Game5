using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public override void Awake(){
        MakeSingleton(false);
    }
    public override void Start(){
        GameUIManager.Ins.ShowGameGUI(false);
    }
    public void PlayGame(){
        if(playerPrefab){
            m_dinoClone = Instantiate(playerPrefab,Vector3.zero,Quaternion.identity);
        }
        StartCoroutine(Spawn());
        GameUIManager.Ins.ShowGameGUI(true);
    }

    public Dino playerPrefab;
    public Stone[] stonePrefab;
    public float spawnTime;
    int m_score;
    bool m_isGameOver;
    bool m_isGameBegin;
    Dino m_dinoClone;

    public int Score { get => m_score; set => m_score = value; }
    public bool IsGameOver { get => m_isGameOver; set => m_isGameOver = value; }
    public bool IsGameBegin { get => m_isGameBegin; set => m_isGameBegin = value; }

    IEnumerator Spawn(){
        yield return new WaitForSeconds(3f);
        m_isGameBegin = true;
        if(stonePrefab != null && stonePrefab.Length > 0){
            while(!m_isGameOver){
                int random = Random.Range(0,stonePrefab.Length);
                if(stonePrefab[random] != null){
                    Instantiate(stonePrefab[random], new Vector3(m_dinoClone.transform.position.x,Random.Range(6f,9f),0f),Quaternion.identity);
                }
                yield return new WaitForSeconds(spawnTime);
            }
        }
        yield return null;
    }
}
