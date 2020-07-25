using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public static class StaticVal
{
    public static int movieliking;
    public static int songliking;
    public static int Touchenable = 1;
    public static int scenenumber = 2;

    public static int questID =0;

    public static int playerCoin=43;
    public static float healingIndex = 0;

    public static int selectID = 0; // 0이면 일반, 1이면 힐링, 2이면 사진, 3이면 감정결과 확인

    public static int Post_bamboo_Num = 2; // 2이상이어야 클릭
    public static int newspaperOpenNum = 0;  // 3이어야 소식지 나옴

    public static int coinTree = 1; // 1일때 나무가 나오고, 한번 누르면 0
}
