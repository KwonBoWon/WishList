using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text ChatText; // 실제 채팅이 나오는 텍스트
    public Text CharacterName; // 캐릭터 이름이 나오는 텍스트

    public GameObject chatbutton; // 채팅이끝남을 표시해주는 이미지
    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키
    public GameObject sceneButton; //씬이동버튼

    public string writerText = "";

    bool isButtonClicked = false;
    bool isTextEnd = false;

    void Start()
    {
        StartCoroutine(TextPractice());
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
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return new WaitForSeconds(0.1f);
            if(a == narration.Length-1){
                isTextEnd = true;
                chatbutton.SetActive(true);
                if(isLastChat){
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
        yield return StartCoroutine(NormalChat("의사", "곽두팔씨, 안타깝지만 현재 희귀병이 온몸에 전이된 상태입니다...", false));
        yield return StartCoroutine(NormalChat("의사", "곽두팔씨에게 남은시간은... 24", false));
        yield return StartCoroutine(NormalChat("곽두팔", "24일이요?", false));
        yield return StartCoroutine(NormalChat("의사", "23:59분 55초...", false));
        yield return StartCoroutine(NormalChat("의사", "23:59분 50초...", false));
        yield return StartCoroutine(NormalChat("곽두팔", "24시간 이라는겁니까?", false));
        yield return StartCoroutine(NormalChat("의사", "네... 안타깝게 되었습니다.", false));
        yield return StartCoroutine(NormalChat("의사", "남은시간을 소중히 사용하시길 바랍니다...", true));
    }
}
