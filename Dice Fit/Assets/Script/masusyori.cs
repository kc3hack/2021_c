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
    [SerializeField] KindOfEvent kindOfEvent;
    [SerializeField] Color blue;
    [SerializeField] Color red;
    [SerializeField] Color yellow;
    [SerializeField] Color goal;
    [SerializeField] Color start;
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
                sp.color = blue;
                break;
            case KindOfEvent.red:
                sp.color = red;
                break;
            case KindOfEvent.yellow:
                sp.color = yellow;
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

        switch (kindOfEvent)
        {
            case KindOfEvent.blue:
                //青mass
                text.text = playernumber + "は青マスに止まりました";
                break;
            case KindOfEvent.red:
                //赤mass
                text.text = playernumber + "は赤マスに止まりました";
                break;
            case KindOfEvent.yellow:
                //黄mass
                text.text = playernumber + "は黄マスに止まりました";
                //ここから沼
                int itemrand = Random.Range(0, 100);
                if (itemrand > 50)
                {
                    sai123[playernumber]++;
                    text.text = playernumber + "は一二三賽を手に入れた";
                }else
                {
                    sai456[playernumber]++;
                    text.text = playernumber + "は四五六賽を手に入れた";
                }


                break;
            case KindOfEvent.goal:
                //赤mass
                text.text = playernumber + "はゴールに止まりました";
                break;
            case KindOfEvent.start:
                break;
            default:
                break;
        }
    }
}
