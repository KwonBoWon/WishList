using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tab : MonoBehaviour
{
    bool isSetActive = false;
    public GameObject buc;
    public GameObject time;
    public Data data;
    public Text timeText;

    void start(){
    
        
    }
    void SetTime(){

        timeText.text = data.hour +":" + data.min;
        return;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){

            SetTime();

            buc.SetActive(!isSetActive);
            time.SetActive(!isSetActive);
            isSetActive = !isSetActive;
        }
    }
}
