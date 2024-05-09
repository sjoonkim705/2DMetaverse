using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTimeTest : MonoBehaviour
{
    // Math -> 수학
    // Vector3 -> 위치, 방향
    // DateTime -> 날짜와 시간을 표현하는 클래스
    // 생성, 조작, 비교
    // DateTime 디바이스의 설정에 근거해서 데이터를 초기화한다.


    private void Start()
    {
        // year, month, day, hour, minute, second, millisceond
        DateTime birth = new DateTime(1990, 7, 28, 09, 30, 00);

        DateTime today = DateTime.Today;
        Debug.Log(today);

        DateTime now  = DateTime.Now;
        Debug.Log(now);

        // 2. 조작
        DateTime tomorrow = DateTime.Today.AddDays(1);
        Debug.Log(tomorrow);
        DateTime lastWeek = DateTime.Today.AddDays(-7);
        Debug.Log(lastWeek);

        // 3. 속성
        Debug.Log(tomorrow.Month);

        DateTime person1Birth = new DateTime(2000, 1, 1);
        DateTime person2Birth = new DateTime(2002, 5, 31);

        Debug.Log(person1Birth > person2Birth);

        Debug.Log($"{tomorrow.Year}년 {tomorrow.Month}월 {tomorrow.Day}일 {tomorrow.DayOfWeek}");

        Debug.Log(tomorrow.ToString("yyyy년MM월dd일ddd"));

        // UTC: 협정 세계 시간 (시간의 기준)
        // 영국의 그리니치 천문대
        // Local: 자기 지역 시간

        DateTime now2 = DateTime.Now;
        Debug.Log(now2.Kind);
        DateTime utcNow = DateTime.UtcNow;
        Debug.Log(utcNow);




    }
}
