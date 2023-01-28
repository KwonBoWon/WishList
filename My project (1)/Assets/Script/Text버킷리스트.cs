using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text버킷리스트 : MonoBehaviour
{
    public Text ChatText; // 실제 채팅이 나오는 텍스트
    public Text CharacterName; // 캐릭터 이름이 나오는 텍스트

    public GameObject chatbutton; // 채팅이끝남을 표시해주는 이미지
    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키
    public GameObject sceneButton; //씬이동버튼

    public string writerText = "";

    bool isButtonClicked = false;
    bool isTextEnd = false;
    public AudioSource textSound;
    void Start()
    {
        StartCoroutine(TextPractice());
        //textSound = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {   
        if(isTextEnd){
            foreach (var element in skipButton) // 버튼 검사
            {
                if (Input.GetKeyDown(element))
                {
                    isButtonClicked = true;
                }
            }
        }
    }

    
    IEnumerator NormalChat(string narrator, string narration, bool isLastChat)
    {
        int a = 0;
        CharacterName.text = narrator;
        writerText = "";
        chatbutton.SetActive(false);
        //텍스트 타이핑 효과
        textSound.Play();
        for (a = 0; a < narration.Length; a++)
        {   
            isTextEnd = false;
            writerText += narration[a];
            ChatText.text = writerText;
            yield return new WaitForSeconds(0.1f);
            if(a == narration.Length-1){
                textSound.Stop();
                isTextEnd = true;
                chatbutton.SetActive(true);
                if(isLastChat){
                    textSound.Stop();
                    sceneButton.SetActive(true);
                }
            }
        }

        //키를 다시 누를 떄 까지 무한정 대기
        while (true)
        {
            if (isButtonClicked)
            {
                isButtonClicked = false;

                break;
            }
            yield return null;
        }
    }

    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("곽두팔", "그래 맞아 나는 해야 할 것이 남아있어", false));
        yield return StartCoroutine(NormalChat("곽두팔", "하지만 24시간 내로 전부 해낼 수 있을까...", false));
        yield return StartCoroutine(NormalChat("곽두팔", "좋아 뭐라도 먼저 해 보는거야", false));
        yield return StartCoroutine(NormalChat("시스템", "이제 탭키로 버킷리스트를 볼 수 있다.", true));
    }
}
