using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pNumSelect : MonoBehaviour
{
    GameObject clickedGameObject;
    GameObject preclickedGameObject;

    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;
    public GameObject P5;
    public GameObject P6;

    public static int playNum;
    private bool isSlected;

    void Start()
    {
        isSlected = false;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            clickedGameObject = null;


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
            }

            if (clickedGameObject == P1)
            {
                Selected_Player_Num(1,P1);
            }else if (clickedGameObject == P2)
            {
                Selected_Player_Num(2, P2);
            }
            else if (clickedGameObject == P3)
            {
                Selected_Player_Num(3, P3);
            }
            else if (clickedGameObject == P4)
            {
                Selected_Player_Num(4, P4);
            }
            else if (clickedGameObject == P5)
            {
                Selected_Player_Num(5, P5);
            }
            else if (clickedGameObject == P6)
            {
                Selected_Player_Num(6, P6);
            }

        }



    }

    private void Selected_Player_Num(int pNum,GameObject clickedP)
    {
        playNum = pNum;
        isSlected = true;

        if (preclickedGameObject != null)
        {
            preclickedGameObject.GetComponent<Renderer>().material.color = Color.white;
            preclickedGameObject = clickedP;
        }
        else
        {
            preclickedGameObject = clickedP;
        }

        clickedP.GetComponent<Renderer>().material.color = Color.cyan;
        //Debug.Log(clickedP);
    }

    public static int GetPlayerNum()
    {
        return playNum;
    }

    public bool GetisSelected()
    {
        return isSlected;
    }

}
