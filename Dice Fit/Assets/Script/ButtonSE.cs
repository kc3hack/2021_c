using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSE : MonoBehaviour
{
    public AudioClip soundEnter;
    public AudioClip soundClick;

    private GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.Find("SEManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterButton()
    {
        Debug.Log("Enter");
        gameObject.GetComponent<AudioSource>().PlayOneShot(soundEnter);
    }

    public void ClickButton()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(soundClick);
    }


}
