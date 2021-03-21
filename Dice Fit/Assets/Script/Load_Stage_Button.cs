using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Stage_Button : MonoBehaviour
{
    private GameObject GameManager;
    private float step_time;    // 経過時間カウント用
    private bool buttoncliced;
    private bool isSelected;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        buttoncliced = false;
        step_time = 0.0f;       // 経過時間初期化
        GameManager = GameObject.Find("GameManager");
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
        if (step_time >= 0.5f && isSelected == true)
        {
            SceneManager.LoadScene("PlayerMovement");
        }
    }

    

    public void LoadScene()
    {
        isSelected = GameManager.GetComponent<pNumSelect>().GetisSelected();
        buttoncliced = true;


    }
}
