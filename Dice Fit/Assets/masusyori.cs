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
            default:
                break;
        }
    }

    public void ActiveCellEvent(PlayerMovement player,int playernumber, Text text){

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
                


                break;
            default:
                break;
        }
    }
}
