using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WebOpen : MonoBehaviour
{
    public static WebOpen instance;

    Dictionary<string, string> balladData_high;
    Dictionary<string, string> balladData_low;
    Dictionary<string, string> danceData_high;
    Dictionary<string, string> idolData_high;

    Dictionary<string, string> actionData_high;
    Dictionary<string, string> actionData_low;
    Dictionary<string, string> dramaData_high;
    Dictionary<string, string> dramaData_low;
    Dictionary<string, string> animationData;

    public AudioSource webopensound;

    private void Awake()
    {
        instance = this;

        webopensound = GetComponent<AudioSource>();

        // 노래
        balladData_high = new Dictionary<string, string>();
        balladData_high.Add("흔들리는 꽃들속에서 네 샴푸향이 느껴진거야/장범준", "https://www.youtube.com/watch?v=689GoEBjMhY");
        balladData_high.Add("마음을 드려요/아이유", "https://www.youtube.com/watch?v=MUSaT2B7Lt8");
        balladData_high.Add("좋은사람 있으면 소개시켜줘/조이", "https://www.youtube.com/watch?v=hoLzH1revMg");
        balladData_high.Add("오늘도 빛나는 너에게/마크툽", "https://www.youtube.com/watch?v=dmSUBdk4SY4");
        balladData_high.Add("주저하는 연인들을 위해/잔나비", "https://www.youtube.com/watch?v=5g4KsIizYhQ");
        balladData_high.Add("아로하/조정석", "https://www.youtube.com/watch?v=g8oRKbYrZ6Q");
        balladData_high.Add("행복", "https://www.youtube.com/watch?v=qGh0jk-f6to");
        balladData_high.Add("수고했어 오늘도", "https://youtu.be/1XGNqsXSASo");
        balladData_high.Add("괜찮아도 괜찮아", "https://youtu.be/j2aQ_NqeTNw");
        balladData_high.Add("행복의 주문", "https://youtu.be/eTeRPMU5l2Y");
        balladData_high.Add("This Is Me", "https://youtu.be/wEJd2RyGm8Q");

        balladData_low = new Dictionary<string, string>();
        balladData_low.Add("사랑이 맞을거야/윤미래", "https://www.youtube.com/watch?v=ONACez-twhc");
        balladData_low.Add("야생화/박효신", "https://www.youtube.com/watch?v=OxgiiyLp5pk");
        balladData_low.Add("새벽가로수 길/백지영", "https://www.youtube.com/watch?v=RLvpGqLdHZg");
        balladData_low.Add("잊지 말기로 해/성시경,권진아", "https://www.youtube.com/watch?v=8mw4SdN4J3s");
        balladData_low.Add("처음처럼/엠씨더맥스", "https://www.youtube.com/watch?v=cqzISZnLgCo");
        balladData_low.Add("늦은 밤 너의 집 앞 골목길에서/노을", "https://www.youtube.com/watch?v=3gaLOtoSs40");

        danceData_high = new Dictionary<string, string>();
        danceData_high.Add("어머님이 누구니/박진영", "https://www.youtube.com/watch?v=kUGQ7Tz4os0");
        danceData_high.Add("daddy/싸이", "https://www.youtube.com/watch?v=FrG4TEcSuRg");
        danceData_high.Add("break/빈지노", "https://www.youtube.com/watch?v=5DNZ5lj4TIY");
        danceData_high.Add("아무노래/지코", "https://www.youtube.com/watch?v=UuV2BmJ1p_I");
        danceData_high.Add("really really/위너", "https://www.youtube.com/watch?v=4tBnF46ybZk");
        danceData_high.Add("불타오르네/방탄소년단", "https://www.youtube.com/watch?v=ALj5MKjy2BU");
        danceData_high.Add("her/블락비", "https://www.youtube.com/watch?v=o0WCva5Stk4");

        idolData_high = new Dictionary<string, string>();
        idolData_high.Add("오늘부터 우리는/여자친구", "https://www.youtube.com/watch?v=YYHyAIFG3iI");
        idolData_high.Add("ah choo/러블리즈", "https://www.youtube.com/watch?v=DEd8ED2FdAg");
        idolData_high.Add("remember/에이핑크", "https://www.youtube.com/watch?v=bXlrqQKbjSM");
        idolData_high.Add("달라달라/있지", "https://www.youtube.com/watch?v=pNfTK39k55U");
        idolData_high.Add("덤더럼/에이핑크", "https://www.youtube.com/watch?v=uEdCukOaais");
        idolData_high.Add("Fancy/트와이스", "https://www.youtube.com/watch?v=mIXR-7u2Kas");
        idolData_high.Add("벌써 12시/청하", "https://www.youtube.com/watch?v=L15ZZX9n56M");
        idolData_high.Add("마지막처럼/블랙핑크", "https://www.youtube.com/watch?v=Amq-qlqbjYA");
        idolData_high.Add("빨간 맛/레드벨벳", "https://www.youtube.com/watch?v=WyiIGEHQP8o");
        idolData_high.Add("라타타/아이들", "https://www.youtube.com/watch?v=ilS4StY_6A4");

        // 영화
        actionData_high = new Dictionary<string, string>();
        actionData_high.Add("베테랑", "https://www.youtube.com/watch?v=ArOkpbMs1vk");
        actionData_high.Add("엑시트", "https://youtu.be/Soe7YEkStrk ");
        actionData_high.Add("럭키", "https://youtu.be/N2Cj3r7Ou-Y");
        actionData_high.Add("스파이", "https://youtu.be/A3Gw_eg6ih0 ");
        actionData_high.Add("내 안의 그놈", "https://www.youtube.com/watch?v=p9gUvMFwIRg ");
        actionData_high.Add("킹스맨", "https://www.youtube.com/watch?v=JZ3hwhrfz8s");
        actionData_high.Add("극한직업", "https://www.youtube.com/watch?v=y-sq5Y6ZWgg");

        actionData_low = new Dictionary<string, string>();
        actionData_low.Add("아저씨", "https://www.youtube.com/watch?v=tKZo8ZQrKVM&t=3s ");
        actionData_low.Add("이스케이프 플랜1 ", "https://www.youtube.com/watch?v=O5CZMDD1NCM ");
        actionData_low.Add("신세계", "https://www.youtube.com/watch?v=XJkG4Kiykm8 ");
        actionData_low.Add("투모로우", "https://www.youtube.com/watch?v=waoMEeFuqzs");
        actionData_low.Add("연인", "https://www.youtube.com/watch?v=aDpuGUVZiRc");
        actionData_low.Add("이스케이프:생존을 위한 탈출", "https://www.youtube.com/watch?v=cgboeMLjsZk");

        dramaData_high = new Dictionary<string, string>();
        dramaData_high.Add("라스트 홀리데이", "https://www.youtube.com/watch?v=01j2uOEYGoE");
        dramaData_high.Add("그린북", "https://youtu.be/10GpM_Nxr60");
        dramaData_high.Add("장수상회", "https://youtu.be/pB8cdYZK2LE ");
        dramaData_high.Add("에브리바디스 파인", "https://youtu.be/WTbz6qfbrF4");
        dramaData_high.Add("미드나잇선", "https://youtu.be/2VpAeQr9Hho");
        dramaData_high.Add("미스 리틀 선샤인", "https://youtu.be/YlIFNoA4164");
        dramaData_high.Add("마담 프루스트의 비밀정원", "https://www.youtube.com/watch?v=ICK_qLwcI_w");
        dramaData_high.Add("굿 윌 헌팅", "https://youtu.be/A-0vmlDT9Bg");
        dramaData_high.Add("어쩌다 로맨스", "https://www.youtube.com/watch?v=DrwR-lw5_zQ");


        dramaData_low = new Dictionary<string, string>();
        dramaData_low.Add("커런트 워(The Current War)", "https://youtu.be/6hbRJ-VZyfk ");
        dramaData_low.Add("기억의 밤", "https://youtu.be/dCD1YivaJjE");
        dramaData_low.Add("리틀 포레스트", "https://www.youtube.com/watch?v=KjeL_1U8bLQ");
        dramaData_low.Add("어메이징 메리", "https://www.youtube.com/watch?v=EKDD20YDGHE");
        dramaData_low.Add("프리즌 이스케이프", "https://www.youtube.com/watch?v=r7fo1rqmaBk ");
        dramaData_low.Add("국제시장", "https://youtu.be/8qROF7VtUQE ");
        dramaData_low.Add("행복을 찾아서", "https://www.youtube.com/watch?v=hTFdawWVhn");
        dramaData_low.Add("킹스 스피치", "https://www.youtube.com/watch?v=FnXVUjJNu6Q");
        dramaData_low.Add("굿 윌 헌팅", "https://youtu.be/A-0vmlDT9Bg");

        animationData = new Dictionary<string, string>();
        animationData.Add("인사이드아웃", "https://www.youtube.com/watch?v=O3IbEQU9AI8");
        animationData.Add("모아나", "https://www.youtube.com/watch?v=nTGnbiRMzU8");
        animationData.Add("몬스터 주식회사", "https://www.youtube.com/watch?v=FlMD2Rjpe9Q");
        animationData.Add("고양이의 보은", "https://www.youtube.com/watch?v=rRhcaDe3vH4");
        animationData.Add("슈렉", "https://youtu.be/9TSOjhI5fBQ");
        animationData.Add("쿵푸 팬더", "https://youtu.be/HTmkxrksgUI");
        animationData.Add("코코", "https://www.youtube.com/watch?v=V7WpSBAIOLs");
        animationData.Add("주토피아", "https://www.youtube.com/watch?v=3Lv-diPfhSk");
        animationData.Add("뮬란", "https://www.youtube.com/watch?v=BX0YEHP3-Vk");
        animationData.Add("토이스토리", "https://www.youtube.com/watch?v=abjl8RUuM-8");
        animationData.Add("인크레더블2", "https://www.youtube.com/watch?v=4CU-YiukLdg");
        animationData.Add("벅스라이프", "https://www.youtube.com/watch?v=OVnb7Zh7Ick");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dict)
    {
        System.Random rand = new System.Random();
        List<TValue> values = Enumerable.ToList(dict.Values);
        int size = dict.Count;
        while (true)
        {
            yield return values[rand.Next(size)];
        }
    }

    public IEnumerable<TKey> RandomKeys<TKey, TValue>(IDictionary<TKey, TValue> dict)
    {
        System.Random rand = new System.Random();
        List<TKey> keys = Enumerable.ToList(dict.Keys);
        int size = dict.Count;
        while (true)
        {
            yield return keys[rand.Next(size)];
        }
    }

    public void balladDataOpen()
    {
        Dictionary<string, string> mergeDic = balladData_high.Union(balladData_low).ToDictionary(x => x.Key, x => x.Value);

        foreach (string key in RandomKeys(mergeDic).Take(1))
        {
            Debug.Log("발라드추천:" + key);
            Application.OpenURL(mergeDic[key]);
        }
    }
    public void balladHighDataOpen()
    {
        foreach (string key in RandomKeys(balladData_high).Take(1))
        {
            Debug.Log("발라드(high)추천:" + key);
            Application.OpenURL(balladData_high[key]);
        }
    }
    public void balladLowDataOpen()
    {
        foreach (string key in RandomKeys(balladData_low).Take(1))
        {
            Debug.Log("발라드(low)추천:" + key);
            Application.OpenURL(balladData_low[key]);
        }
    }
    public void danceDataOpen()
    {
        foreach (string key in RandomKeys(danceData_high).Take(1))
        {
            Debug.Log("댄스곡 추천:" + key);
            Application.OpenURL(danceData_high[key]);
        }
    }
    public void idolDataOpen()
    {
        foreach (string key in RandomKeys(idolData_high).Take(1))
        {
            Debug.Log("아이돌노래 추천:" + key);
            Application.OpenURL(idolData_high[key]);
        }
    }

    public void actionDataOpen()
    {
        Dictionary<string, string> mergeDic = actionData_high.Union(actionData_low).ToDictionary(x => x.Key, x => x.Value);

        foreach (string key in RandomKeys(mergeDic).Take(1))
        {
            Debug.Log("액션영화 추천:" + key);
            Application.OpenURL(mergeDic[key]);
        }
    }
    public void actionHighDataOpen()
    {
        foreach (string key in RandomKeys(actionData_high).Take(1))
        {
            Debug.Log("액션영화(high) 추천:" + key);
            Application.OpenURL(actionData_high[key]);
        }
    }
    public void actionLowDataOpen()
    {
        foreach (string key in RandomKeys(actionData_low).Take(1))
        {
            Debug.Log("액션영화(low) 추천:" + key);
            Application.OpenURL(actionData_low[key]);
        }
    }
    public void dramaDataOpen()
    {
        Dictionary<string, string> mergeDic = dramaData_high.Union(dramaData_low).ToDictionary(x => x.Key, x => x.Value);
        foreach (string key in RandomKeys(mergeDic).Take(1))
        {
            Debug.Log("드라마영화 추천:" + key);
            Application.OpenURL(mergeDic[key]);
        }
    }
    public void dramaHighDataOpen()
    {
        foreach (string key in RandomKeys(dramaData_high).Take(1))
        {
            Debug.Log("드라마영화(high) 추천:" + key);
            Application.OpenURL(dramaData_high[key]);
        }
    }
    public void dramaLowDataOpen()
    {
        foreach (string key in RandomKeys(dramaData_low).Take(1))
        {
            Debug.Log("드라마영화(low) 추천:" + key);
            Application.OpenURL(dramaData_low[key]);
        }
    }
    public void animationDataOpen()
    {
        foreach (string key in RandomKeys(animationData).Take(1))
        {
            Debug.Log("애니메이션 추천:" + key);
            Application.OpenURL(animationData[key]);
        }
    }
}
