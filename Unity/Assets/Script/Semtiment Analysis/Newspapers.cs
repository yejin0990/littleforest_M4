using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Newspapers : MonoBehaviour
{
// 사용자의 힐링 지수에 따라 영화, 음악을 추천해주고 유튜브로 보여줌 (Webopen script 참고)
    public Text WeatherT;
    public Text TemperatureT;
    public Text HealingT;

    public Image weatherImage;

    public GameObject NewspaperU;

    public GameObject songButtonObject;
    public GameObject movieButtonObject;

    public AudioSource newssound;

    public static Newspapers instance;

    public GameObject newspapterButtonObject;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
        socket.instance.WeatherServer();
        newssound = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (StaticVal.newspaperOpenNum == 3)
        {
            newspapterButtonObject.SetActive(true);
        }
    }

    public void newsOpen()
    {
        if (StaticVal.Touchenable == 1)
        {
            newssound.Play();
            newspaperInit();
            NewspaperU.SetActive(true);   
        }
             
    }

    public void newsClose()
    {
        newssound.Play();
        NewspaperU.SetActive(false);
        StaticVal.Touchenable = 1;
    }

    public void newspaperInit() // 현재 날씨와 사용자의 힐링 지수 상태 시각적으로 보여줌
    {
        TemperatureT.text = socket.instance.temperature + '℃' + '/';
        WeatherT.text = socket.instance.weatherState;
        Debug.Log(TemperatureT.text.ToString());
        Debug.Log(WeatherT.text.ToString());

        if (WeatherT.text.Equals("Snow"))
        {
            weatherImage.sprite = Resources.Load<Sprite>("Weathericon/snow");
        }
        else if (WeatherT.text.Equals("Thunderstorm"))
        {
            weatherImage.sprite = Resources.Load<Sprite>("Weathericon/thunderstorm");
        }
        else if (WeatherT.text.Equals("Rain"))
        {
            weatherImage.sprite = Resources.Load<Sprite>("Weathericon/rain");
        }
        else if (WeatherT.text.Equals("Mist"))
        {
            weatherImage.sprite = Resources.Load<Sprite>("Weathericon/mist");
        }
        else if (WeatherT.text.Equals("Clouds"))
        {
            weatherImage.sprite = Resources.Load<Sprite>("Weathericon/clouds");
        }
        else if (WeatherT.text.Equals("Clear"))
        {
            weatherImage.sprite = Resources.Load<Sprite>("Weathericon/clear");
        }
        else if (WeatherT.text.Equals("Drizzle"))
        {
            weatherImage.sprite = Resources.Load<Sprite>("Weathericon/drizzle");
        }
        else if (WeatherT.text.Equals("Smoke"))
        {
            weatherImage.sprite = Resources.Load<Sprite>("Weathericon/smoke");
        }
        else if (WeatherT.text.Equals("Haze"))
        {
            weatherImage.sprite = Resources.Load<Sprite>("Weathericon/haze");
        }
        else
        {
            weatherImage.sprite = Resources.Load<Sprite>("Weathericon/noimage");
        }
        if (Healing.instance.healingVal >= 0.6)
        {

            HealingT.text = "좋음";
        }
        else if (Healing.instance.healingVal <= 0.3)
        {
            HealingT.text = "나쁨";
        }
        else
        {
            HealingT.text = "보통";
        }

    }

    public void movieButtonClick()
    {
        Debug.Log(StaticVal.movieliking);
        if (StaticVal.movieliking == 1)
        {
            likeActionMovie();
        }
        else if (StaticVal.movieliking == 2)
        {
            likeDramaMovie();
        }
        else if (StaticVal.movieliking == 3)
        {
            likeAnimationMovie();
        }
        else
        {
            Debug.Log("영화 취향을 알 수 없음.");
        }
    }

    public void songButtonClick()
    {
        Debug.Log(StaticVal.songliking);
        if (StaticVal.songliking == 1)
        {
            likeBalladSong();
        }else if (StaticVal.songliking == 2)
        {
            likeDanceSong();
        }
        else if (StaticVal.songliking == 3)
        {
            likeidolSong();
        }
        else
        {
            Debug.Log("노래 취향을 알 수 없음.");
        }
    }

    public void likeBalladSong() // WebOpen에 있는 딕셔너리 불러옴
    {
        if (Healing.de_healingVal > 0)
        {
            WebOpen.instance.balladDataOpen();
        }
        else
        {
            WebOpen.instance.balladHighDataOpen();
        }
    }
    public void likeDanceSong()
    {
        WebOpen.instance.danceDataOpen();
    }
    public void likeidolSong()
    {
        WebOpen.instance.idolDataOpen();
    }

    public void likeActionMovie()
    {
        if (Healing.de_healingVal > 0)
        {
            WebOpen.instance.actionDataOpen();
        }else
        {
            WebOpen.instance.actionHighDataOpen();
        }
    }
    public void likeDramaMovie()
    {
        if (Healing.de_healingVal > 0)
        {
            WebOpen.instance.dramaDataOpen();
        }
        else
        {
            WebOpen.instance.dramaHighDataOpen();
        }
    }
    public void likeAnimationMovie()
    {
        WebOpen.instance.animationDataOpen();
    }

    public void liking_firstClick()
    {
        if (StaticVal.songliking == 0) StaticVal.songliking = 1;
        else StaticVal.movieliking = 1;
        Debug.Log(StaticVal.songliking);
        Debug.Log(StaticVal.movieliking);
    }
    public void liking_secondClick()
    {
        if (StaticVal.songliking == 0) StaticVal.songliking = 2;
        else StaticVal.movieliking = 2;
        Debug.Log(StaticVal.songliking);
        Debug.Log(StaticVal.movieliking);
    }
    public void liking_thirdClick()
    {
        if (StaticVal.songliking == 0) StaticVal.songliking = 3;
        else StaticVal.movieliking = 3;
        Debug.Log(StaticVal.songliking);
        Debug.Log(StaticVal.movieliking);
    }

    public void liking_init()
    {
        StaticVal.songliking = 0;
        StaticVal.movieliking = 0;
    }
}
