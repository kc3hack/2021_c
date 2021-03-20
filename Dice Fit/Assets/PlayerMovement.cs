using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] MassGameObjects;//
    public GameObject[] Players;//各プレイヤーゲームオブジェクトの山椒
    public bool[] GoalPlayer;//Goal判定
    public int[] currentMasuIndex;//プレイヤーごとのどこのますにいるかの配列
    public int positionTmp;//移動前の位置情報一時保存
    public int currentPlayer = 0;//今どのプレイヤーかどうか
    bool ダイス振れる;

    // Start is called before the first frame update
    void Start()
    {   
        ダイス振れる = true;
        currentMasuIndex = new int[Players.Length];//プレイヤーの位置情報
        GoalPlayer = new bool[Players.Length];
    }

    public int ChangePlayer (int currentPlayer,int NumPlayer)//プレイヤー交代
    {
        if(currentPlayer == NumPlayer)
        {
            currentPlayer = 0;
        }
        else
        {
            currentPlayer += 1;
        }
        return currentPlayer;
    }

    //DiceRollスクリプトのサイコロの目の数だけ駒を進ませる
    public void PlayerMove(int tempDiceValue)
    {
        if (currentMasuIndex + tempDiceValue <= 26)
        {
            currentMasuIndex += tempDiceValue;
            Vector2 tmp = MassGameObjects[currentMasuIndex].transform.position;
            this.transform.position = tmp;
        }
        else
        {
            Debug.Log("GOOOOOOOOOOOOOAL!!!!!!!");
            Vector2 tmp = MassGameObjects[27].transform.position;
            this.transform.position = tmp;
        }
    }

    public void OnPointerClick(PointerEventData e) 
    IEnumerator MovePlayer ()
    {
        for(int i=positionTmp+1;i<=currentMasuIndex[currentPlayer];i++)
        {
            Vector2 tmp = MassGameObjects[i].transform.position;
            Players[currentPlayer].transform.DOJump(tmp, jumpPower: 3f, numJumps: 1, duration: 0.5f).SetEase(Ease.InOutSine);
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }

    IEnumerator GoAheadWithAnim()
    {
        if(currentMasuIndex[currentPlayer] + tempDiceValue <= 28)
        {
            positionTmp = currentMasuIndex[currentPlayer];
            currentMasuIndex[currentPlayer] += tempDiceValue;//位置情報の更新
            yield return MovePlayer();//
        }
        else
        {
            Debug.Log ("GOOOOOOOOOOOOOAL!!!!!!!");
            Vector2 tmp = MassGameObjects[27].transform.position;
            Players[currentPlayer].transform.position = tmp;
            GoalPlayer[currentPlayer] = true;
        }
        
        currentPlayer = ChangePlayer(currentPlayer,Players.Length-1);
        if(GoalPlayer[currentPlayer])//Goalしたプレイヤーをスキップ
        {
            currentPlayer = ChangePlayer(currentPlayer,Players.Length-1);
        }
        //ここからマスのイベント開始！！！
        ダイス振れる = true;
        yield return null;
    }

    public void OnPointerClick(PointerEventData e) 
    {
        if(ダイス振れる)
        {
            ダイス振れる = false;
            StartCoroutine(GoAheadWithAnim());
        }
	}

}
