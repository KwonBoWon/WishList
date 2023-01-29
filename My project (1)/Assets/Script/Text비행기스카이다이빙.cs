using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text비행기스카이다이빙 : MonoBehaviour
{
    public Text ChatText; // 실제 채팅이 나오는 텍스트
    public Text CharacterName; // 캐릭터 이름이 나오는 텍스트

    public GameObject chatbutton; // 채팅이끝남을 표시해주는 이미지
    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키

    public GameObject sceneButton; //씬이동버튼

    public bool isChoice = false;
    public GameObject choice1;
    public GameObject choice2;

    public string writerText = "";

    bool isButtonClicked = false;
    bool isTextEnd = false;
    bool isTextDone = false;
    public AudioSource textSound;

    public Data data;


    void Start()
    {
        StartCoroutine(TextPractice());
        //textSound = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {   
        if(isTextEnd){
            if(isChoice && isTextDone){
                choice1.SetActive(true);
                choice2.SetActive(true);

            }
            else{
                foreach (var element in skipButton) // 버튼 검사
                {
                    if (Input.GetKeyDown(element))
                    {
                        isButtonClicked = true;
                    }
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
                    isTextDone = true;
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

        yield return StartCoroutine(NormalChat("곽두팔", "가면 우선 스키를 탈까?", false));
        yield return StartCoroutine(NormalChat("곽두팔", "코끼리도 보고싶은데", false));
        yield return StartCoroutine(NormalChat("승무원", "현재 비행기 내부 문이 제대로 잠기지 않았습니다", false));
        yield return StartCoroutine(NormalChat("승무원", "그러나 안전에는 문제가 없으므로", false));
        yield return StartCoroutine(NormalChat("승무원", "승객 여러분은 동요하지 마시고 편안히 여행을 즐기시면 되겠습니다", false));
        yield return StartCoroutine(NormalChat("곽두팔", "이 가방 안에 낙하산이랑 스쿠버다이빙 장비가 있잖아?", false));
        yield return StartCoroutine(NormalChat("곽두팔", "이건 다시 올 수 없는 기회야!", true));
    }

    
}
