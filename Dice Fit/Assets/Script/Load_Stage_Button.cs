using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Stage_Button : MonoBehaviour
{
    private GameObject GameManager;
    private float step_time;    // �o�ߎ��ԃJ�E���g�p
    private bool buttoncliced;
    private bool isSelected;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        buttoncliced = false;
        step_time = 0.0f;       // �o�ߎ��ԏ�����
        GameManager = GameObject.Find("GameManager");
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
