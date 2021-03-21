using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Load_Select_Button : MonoBehaviour
{
    private float step_time;    // 経過時間カウント用
    private bool buttoncliced;

    // Use this for initialization
    void Start()
    {
        buttoncliced = false;
        step_time = 0.0f;       // 経過時間初期化
    }

    

    // Update is called once per frame
    void Update()
    {
        if (buttoncliced == true)
        {
            // 経過時間をカウント
            step_time += Time.deltaTime;
        }

        // 0.5秒後に画面遷移（sceneへ移動）
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
