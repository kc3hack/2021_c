using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class Dice_Roll : MonoBehaviour
{
    public GameObject dice;
    Rigidbody2D rb2D;
    private SpriteRenderer diceImage;
    private int preNum;
    float posY;

    Sprite[] images,images_Normal, images_123, images_456;

    private bool isRandom = false;

    EDiceMode dMode = EDiceMode.NORMAL_DICE;
    private int dNumMin = 0;
    private int dNumMax = 6;
    private GameObject Player1;

    // Start is called before the first frame update
    void Start()
    {
        //diceImage = dice.GetComponent<Image>();
        diceImage = dice.GetComponent<SpriteRenderer>();
        rb2D = dice.GetComponent<Rigidbody2D>();
        images_Normal = Resources.LoadAll<Sprite>("Image/Dice/Normal_Dice");
        images_123 = Resources.LoadAll<Sprite>("Image/Dice/123_Dice");
        images_456 = Resources.LoadAll<Sprite>("Image/Dice/456_Dice");
        images = images_Normal;
        Player1 = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            dMode = EDiceMode.NORMAL_DICE;
            images = images_Normal;
            diceImage.sprite = images[0];
            dNumMin = 0;
            dNumMax = 6;
        }
        else if (Input.GetKey(KeyCode.B))
        {
            dMode = EDiceMode.DICE_OTT;
            images = images_123;
            diceImage.sprite = images[0];
            dNumMin = 0;
            dNumMax = 3;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            dMode = EDiceMode.DICE_FFS;
            images = images_456;
            diceImage.sprite = images[0];
            dNumMin = 3;
            dNumMax = 6;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            OnClickDice();
        }

        if (isRandom)
        {
            //�T�C�R���������Ă���Ԃ͏��num���X�V���A�~�܂钼�O�̒l��preNum�Ɋi�[����
            if (!rb2D.IsSleeping())
            {
                int num = Random.Range(dNumMin, dNumMax);
                if (dMode == EDiceMode.DICE_FFS)
                {
                    diceImage.sprite = images[num-3];
                }
                else
                {
                    diceImage.sprite = images[num];
                }
                
                preNum = num;
            }
            else
            {
                Player1.GetComponent<PlayerMovement>().PlayerMove(preNum+1);
                Debug.Log(preNum + 1);
                isRandom = false;
            }
        }
    }


    private enum EDiceMode
    {
        NORMAL_DICE = 0,
        DICE_OTT = 1,
        DICE_FFS = 2
    }


    //�N���b�N�ŌĂԊO���X�N���v�g����ł���
    public void OnClickDice()
    {
        if (rb2D.IsSleeping() && !isRandom)
        {
            rb2D.AddForce(new Vector2(0f, 1000f));
            isRandom = true;
        }
    }

}
