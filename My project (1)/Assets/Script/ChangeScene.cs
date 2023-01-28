using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject panel;
    public Image image;

    public string sceneName;
    float fadeCount = 0;
    public GameObject[] check = new GameObject[5];
    

    public void FadeOut(){
        panel.SetActive(true);
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine(){
        fadeCount = 0;
        while(fadeCount <1.5f){
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
           
        }
    }
    public void SceneChange(){

        FadeOut();  
    }
    void Update()
    {
        if(fadeCount>=1.5f){
            SceneManager.LoadScene(sceneName);
        }
    }


    public void SceneChange1(){
        check[1].SetActive(true);
        FadeOut();  
    }
    public void SceneChange2(){
        check[2].SetActive(true);
        FadeOut();  
    }
    public void SceneChange3(){
        check[3].SetActive(true);
        FadeOut();  
    }
    public void SceneChange4(){
        check[4].SetActive(true);
        FadeOut();  
    }

}
