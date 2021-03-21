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
                //sp.color = blue;
                sp.color = new Color(132f / 255f, 231f / 255f, 201f / 255f);
                
                break;
            case KindOfEvent.red:
                //sp.color = red;
                sp.color = new Color(254f / 255f, 107f / 255f, 0f / 255f);
                break;
            case KindOfEvent.yellow:
                //sp.color = yellow;
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

        switch (kindOfEvent)
        {
            case KindOfEvent.blue:
                int menurand1 = Random.Range(1, 4);
                //青mass
                if (menurand1 == 1)
                {
                    text.text = playernumber + "は青マスに止まりました\n腕立て伏せ10回";
                }
                else if (menurand1 == 2)
                {
                    text.text = playernumber + "は青マスに止まりました\nスクワット20回";
                }
                else
                {
                    text.text = playernumber + "は青マスに止まりました\n腹筋20回";
                }
                break;
            case KindOfEvent.red:
                int menurand2 = Random.Range(1, 4);
                //赤mass
                if (menurand2 == 1)
                {
                    text.text = playernumber + "は赤マスに止まりました\n腕立て伏せ30回";
                }
                else if (menurand2 == 2)
                {
                    text.text = playernumber + "は赤マスに止まりました\nランジ20回";
                }
                else
                {
                    text.text = playernumber + "は赤マスに止まりました\n腹筋50回";
                }
                break;
            case KindOfEvent.yellow:
                //黄mass
                //ここから沼
                int itemrand = Random.Range(0, 100);
                if (itemrand > 50)
                {
                    sai123[playernumber]++;
                    text.text = playernumber + "は黄マスに止まりました\n一二三賽を手に入れた";
                }
                else
                {
                    sai456[playernumber]++;
                    text.text = playernumber + "は黄マスに止まりました\n四五六賽を手に入れた";
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
