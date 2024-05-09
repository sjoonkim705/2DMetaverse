using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpanTest : MonoBehaviour
{

    private void Start()
    {
        // TimeSpan은 시간 간격을 나타내는 클래스
        // 시간을 조작하거나 두 날짜 사이의 차이를 계산할 수 있다.

        TimeSpan twoHour = new TimeSpan(2,0,0);
        Debug.Log(twoHour);
        Debug.Log(twoHour.TotalMinutes);
        Debug.Log(twoHour.TotalSeconds);

        DateTime xMasDate = new DateTime(DateTime.Today.Year, 12, 25);
        DateTime today = DateTime.Today;
        // DateTime에 대한 사칙연산은 "빼기'만 된다.
        TimeSpan diff = xMasDate - today;
        Debug.Log($"크리스마스까지 남은 일은 {diff.TotalDays}");

        // 2024. 2. 26일 기준으로
        // // 100일이 언제고, 며칠 남았는지?

        DateTime theDay = new DateTime(2024, 2, 26);
        DateTime hundredDay = theDay.AddDays(99);
        Debug.Log(hundredDay.ToString("yyyy년 MM월 dd일 ddd"));
        TimeSpan remaingDays = hundredDay-today;
        Debug.Log(remaingDays);

        // ISO 국제시간표기법
        // 예시) 2024-05-07T14:33:17
        string intNumber = "324";
        int number = Int32.Parse(intNumber);
        string stringDate = "2024-05-07T14:33:17";

        DateTime date = DateTime.Parse(stringDate);

    }
}
