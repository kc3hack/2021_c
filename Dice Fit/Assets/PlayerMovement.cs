using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] MassGameObjects;
    public int currentMasuIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData e) 
    {
        int tempDiceValue = Random.Range(0, 6) + 1;//ダイスの値をランダムに設定
        Debug.Log(tempDiceValue);
        if(currentMasuIndex + tempDiceValue <= 27)
        {
            currentMasuIndex+= tempDiceValue;
            Vector2 tmp = MassGameObjects[currentMasuIndex].transform.position;
            this.transform.position = tmp;
        }
        else
        {
            Debug.Log ("GOOOOOOOOOOOOOAL!!!!!!!");
            Vector2 tmp = MassGameObjects[27].transform.position;
            this.transform.position = tmp;
        }
        
	}

}
