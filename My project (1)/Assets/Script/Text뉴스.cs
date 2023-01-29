using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text뉴스 : MonoBehaviour
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

    public GameObject change;

    void Start()
    {   
        
        StartCoroutine(TextPractice());
        //textSound = gameObject.AddComponent<AudioSource>();
        //if(data.trip == 2){
        //    change.GetComponent<ChangeScene>().sceneName ="가방";
        //}
        if(data.cross ==1){
            change.GetComponent<ChangeScene>().sceneName ="사망";
        }
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
        yield return StartCoroutine(NormalChat("기자", "인터뷰 가능하세요?", false));
        yield return StartCoroutine(NormalChat("곽두팔", "뉴진스의 하입보이요", false));
        yield return StartCoroutine(NormalChat("기자", "네?", false));
        yield return StartCoroutine(NormalChat("곽두팔", "아 네 가능합니다", false));
        yield return StartCoroutine(NormalChat("기자", "조련사이신가요?", false));
        yield return StartCoroutine(NormalChat("곽두팔", "아니요, 조련사는 아니에요", false));
        yield return StartCoroutine(NormalChat("기자", "그럼 용감하게 코끼리를 제압하셧는데 어떻게 하신거죠?", false));
        yield return StartCoroutine(NormalChat("곽두팔", "아, 누군가는 해야할일이니까요", false));
        yield return StartCoroutine(NormalChat("곽두팔", "(방금 ㅈㄴ멋있었다;)", false));
        yield return StartCoroutine(NormalChat("곽두팔", "이제 버스타고 다시 가 볼까?", true));
    }

    
}
