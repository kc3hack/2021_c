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
    private GameObject GameManager;
    PlayerMovement playerMovement;
    masusyori masusori;

    [SerializeField] GameObject ItemSelectWindow;

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
        GameManager = GameObject.Find("GameManager");

        playerMovement = GetComponent<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {

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
                GameManager.GetComponent<PlayerMovement>().GoEvent(preNum + 1);
                Debug.Log(preNum + 1);
                isRandom = false;
                SetnormalDice();
                playerMovement.Itemtukau.enabled = true;
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

    public void SetnormalDice(){
        dMode = EDiceMode.NORMAL_DICE;
        images = images_Normal;
        //diceImage.sprite = images[0];
        dNumMin = 0;
        dNumMax = 6;
    }
    public void Set123Dice()
    {   
        dMode = EDiceMode.DICE_OTT;
        images = images_123;
        diceImage.sprite = images[0];
        dNumMin = 0;
        dNumMax = 3;
        playerMovement.sai123[playerMovement.currentPlayer]--;
        UseItem();
    }
    public void Set456Dice()
    {
        dMode = EDiceMode.DICE_FFS;
        images = images_456;
        diceImage.sprite = images[0];
        dNumMin = 3;
        dNumMax = 6;
        playerMovement.sai456[playerMovement.currentPlayer]--;
        UseItem();
    }

    public void ShowWindow(){
        ItemSelectWindow.SetActive(true);
        playerMovement.SaiText123.text = "123sai (" + playerMovement.sai123[playerMovement.currentPlayer] + ")";
        playerMovement.SaiText456.text = "456sai (" + playerMovement.sai456[playerMovement.currentPlayer] + ")";
        if (playerMovement.sai123[playerMovement.currentPlayer] <= 0)
        {
            playerMovement.SaiButton123.enabled = false;
            playerMovement.SaiText123.color = new Color(0.2f,0.2f,0.2f,0.5f);
        }else{
            playerMovement.SaiButton123.enabled = true;
            playerMovement.SaiText123.color = new Color(132/255.0f,231/255.0f,201/255.0f,1);
        }
        if (playerMovement.sai456[playerMovement.currentPlayer] <= 0)
        {
            playerMovement.SaiButton456.enabled = false;
            playerMovement.SaiText456.color = new Color(0.2f,0.2f,0.2f,0.5f);
        }else{
            playerMovement.SaiButton456.enabled = true;
            playerMovement.SaiText456.color = new Color(132/255.0f,231/255.0f,201/255.0f,1);
        }
    }

    public void HideWindow(){
        ItemSelectWindow.SetActive(false);
        //masusori.BlueKintoreWindow.SetActive(false);
        //masusori.RedKintoreWindow.SetActive(false);
        //masusori.ItemtoretaWindow.SetActive(false);
    }

    public void UseItem(){
        playerMovement.Itemtukau.enabled = false;
    }
}
