using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class masusyori : MonoBehaviour
{
    enum KindOfEvent
    {
        blue = 0,
        red,
        yellow,
        goal,
        start,
    }
    string[] bluekintoresyu = {"腕立て伏せ20回!","スクワット20回!","腹筋20回!"};
    string[] redkintoresyu = {"腕立て伏せ50回!","腹筋50回!","ジャックナイフ30回!"};
    string[] Itemsyu = {"123サイコロ","456サイコロ"};
    [SerializeField] KindOfEvent kindOfEvent;
    [SerializeField] Color blue;
    [SerializeField] Color red;
    [SerializeField] Color yellow;
    [SerializeField] Color goal;
    [SerializeField] Color start;
    [SerializeField] GameObject BlueKintoreWindow;
    [SerializeField] GameObject RedKintoreWindow;
    [SerializeField] GameObject ItemtoretaWindow;

    [SerializeField] Text Bluetext;
    [SerializeField] Text Redtext;
    [SerializeField] Text Itemtext;
    // Start is called before the first frame update
    void Start()
    {
        ChangeColor();
    }

    void ChangeColor(){
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        
        switch (kindOfEvent)
        {
            case KindOfEvent.blue:
                sp.color = new Color(132f / 255f, 231f / 255f, 201f / 255f);
                break;
            case KindOfEvent.red:
                sp.color = new Color(254f / 255f, 107f / 255f, 0f / 255f);
                break;
            case KindOfEvent.yellow:
                sp.color = new Color(254f / 255f, 215f / 255f, 0f / 255f);
                break;
            case KindOfEvent.goal:
                sp.color = goal;
                break;
            case KindOfEvent.start:
                sp.color = start;
                break;
            default:
                break;
        }
    }

    public void ActiveCellEvent(PlayerMovement player,int playernumber, Text text, int[] sai123, int[] sai456){
        int tmp1 = 0;

        switch (kindOfEvent)
        {
            case KindOfEvent.blue:
                //青mass
                //text.text = playernumber + "は青マスに止まりました";
                tmp1 = Random.Range(0,100) % 3;
                Bluetext.text = "筋トレタイム!!\n" + bluekintoresyu[tmp1];
                BlueKintoreWindow.SetActive(true);
                break;
            case KindOfEvent.red:
                //赤mass
                //text.text = playernumber + "は赤マスに止まりました";
                tmp1 = Random.Range(0,100) % 3;
                Redtext.text = "筋トレタイム!!\n" + redkintoresyu[tmp1];
                RedKintoreWindow.SetActive(true);
                break;
            case KindOfEvent.yellow:
                //黄mass
                //text.text = playernumber + "は黄マスに止まりました";
                
                //ここから沼
                int itemrand = Random.Range(0, 100);
                if (itemrand > 50)
                {
                    sai123[playernumber]++;
                    //text.text = playernumber + "は一二三賽を手に入れた";
                    Itemtext.text = "アイテムゲット!!\n・" + Itemsyu[0];
                }else
                {
                    sai456[playernumber]++;
                    //text.text = playernumber + "は四五六賽を手に入れた";
                    Itemtext.text = "アイテムゲット!!\n・" + Itemsyu[1];
                }
                ItemtoretaWindow.SetActive(true);
                break;
            case KindOfEvent.goal:
                //赤mass
                //text.text = playernumber + "はゴールに止まりました";
                break;
            case KindOfEvent.start:
                break;
            default:
                break;
        }
    }

    
    public void HideWindow(){
        BlueKintoreWindow.SetActive(false);
        RedKintoreWindow.SetActive(false);
        ItemtoretaWindow.SetActive(false);
    }

}





