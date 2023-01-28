using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text병원절망 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("곽두팔", "내가 24시간뒤에 죽는다니... 믿을수 없어", false));
        yield return StartCoroutine(NormalChat("곽두팔", "나 사나이 곽두팔 이대로 죽을 순 없어", false));
        yield return StartCoroutine(NormalChat("곽두팔", "이대로 죽기엔 못해본 것들이 너무 많아...", false));
        yield return StartCoroutine(NormalChat("곽두팔", "24시간을 어떻게 써야하지...", false));
        yield return StartCoroutine(NormalChat("곽두팔", "내가 해보고 싶었던게 뭐였지?", false));
        yield return StartCoroutine(NormalChat("곽두팔", "맞아 버킷리스트를 적어 놨었어", true));
    }
}
