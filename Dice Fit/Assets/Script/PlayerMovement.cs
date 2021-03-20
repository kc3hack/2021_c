using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject[] MassGameObjects;//
    public GameObject[] AllPlayers;
    GameObject[] Players;//各プレイヤーゲームオブジェクトの山椒
    public bool[] GoalPlayer;//Goal判定
    public int[] currentMasuIndex;//プレイヤーごとのどこのますにいるかの配列
    public int positionTmp;//移動前の位置情報一時保存
    public int currentPlayer = 0;//今どのプレイヤーかどうか
    bool ダイス振れる;
    public int[] sai123;
    public int[] sai456;

    private int tempDiceValue;//出たダイスの目
    [SerializeField] Text playerInfomationText;
    public Text SaiText123;
    public Text SaiText456;

    // Start is called before the first frame update
    void Start()
    {   
        ダイス振れる = true;
        Players = new GameObject[pNumSelect.GetPlayerNum()];
        for (int i = 0; i < pNumSelect.GetPlayerNum(); i++)
        {
            Players[i] = AllPlayers[i];
            Players[i].SetActive(true);
        }


        currentMasuIndex = new int[Players.Length];//プレイヤーの位置情報
        GoalPlayer = new bool[Players.Length];
        sai123 = new int[Players.Length];
        sai456 = new int[Players.Length];
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


    IEnumerator MovePlayer()
    {
        for (int i = positionTmp + 1; i <= currentMasuIndex[currentPlayer]; i++)
        {
            if (i >= MassGameObjects.Length)
            {   
                break;
            }
            Vector2 tmp = MassGameObjects[i].transform.position;
            tmp.y += 0.8f;
            Players[currentPlayer].transform.DOJump(tmp, jumpPower: 3f, numJumps: 1, duration: 0.5f).SetEase(Ease.InOutSine);
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }

    IEnumerator GoAheadWithAnim()
    {
        //int tempDiceValue = Random.Range(0, 6) + 1;//ダイスの値をランダムに設定
        Debug.Log(tempDiceValue);
            positionTmp = currentMasuIndex[currentPlayer];
            currentMasuIndex[currentPlayer] += tempDiceValue;//位置情報の更新
            yield return MovePlayer();//
        if(currentMasuIndex[currentPlayer] >= 28)
        {
            Debug.Log ("GOOOOOOOOOOOOOAL!!!!!!!");
            //Vector2 tmp = MassGameObjects[27].transform.position;
            //Players[currentPlayer].transform.position = tmp;
            GoalPlayer[currentPlayer] = true;
            currentMasuIndex[currentPlayer] = 27;
        }
        //ここからマスのイベント開始！！！
        Debug.Log(currentPlayer);
        Debug.Log(currentMasuIndex[currentPlayer]);
        Debug.Log("0:" + currentMasuIndex[0]);
        Debug.Log("1:" + currentMasuIndex[1]);
        MassGameObjects[currentMasuIndex[currentPlayer]].GetComponent<masusyori>().ActiveCellEvent(this, currentPlayer,playerInfomationText,sai123,sai456);
        Debug.Log(currentPlayer + "の一二三" + sai123[currentPlayer]);
        Debug.Log(currentPlayer + "の四五六" +sai456[currentPlayer]);



        currentPlayer = ChangePlayer(currentPlayer,Players.Length-1);
        for (int i = 0; i < Players.Length - 1; i++)
        {
            if(GoalPlayer[currentPlayer])//Goalしたプレイヤーをスキップ
            {   
                currentPlayer = ChangePlayer(currentPlayer,Players.Length-1);
            }
        }
        
        
        ダイス振れる = true;
        yield return null;
    }

    /*
    public void OnPointerClick(PointerEventData e) 
    {
        if(ダイス振れる)
        {
            ダイス振れる = false;
            StartCoroutine(GoAheadWithAnim());
        }
	}
    */
    //DiceRollスクリプトのサイコロの目の数だけ駒を進ませる
    //発火関数（外部から発火させる）
    public void GoEvent(int dnum)
    {
        tempDiceValue = dnum;

        if (ダイス振れる)
        {
            ダイス振れる = false;
            StartCoroutine(GoAheadWithAnim());
        }
    }

}
