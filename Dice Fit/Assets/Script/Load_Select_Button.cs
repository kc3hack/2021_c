using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Load_Select_Button : MonoBehaviour
{
    private float step_time;    // �o�ߎ��ԃJ�E���g�p
    private bool buttoncliced;

    // Use this for initialization
    void Start()
    {
        buttoncliced = false;
        step_time = 0.0f;       // �o�ߎ��ԏ�����
    }

    

    // Update is called once per frame
    void Update()
    {
        if (buttoncliced == true)
        {
            // �o�ߎ��Ԃ��J�E���g
            step_time += Time.deltaTime;
        }

        // 0.5�b��ɉ�ʑJ�ځiscene�ֈړ��j
        if (step_time >= 0.5f)
        {
            SceneManager.LoadScene("Select_Menu");
        }

    }

    public void LoadScene()
    {
        buttoncliced = true;
    }



}
