using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Stage_Button : MonoBehaviour
{
    private GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        bool isSelected = GameManager.GetComponent<pNumSelect>().GetisSelected();

        if (isSelected == true)
        {
            SceneManager.LoadScene("PlayerMovement");
            //SceneManager.LoadScene("GameScene");
        }

    }
}
