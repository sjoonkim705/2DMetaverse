using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonTest : MonoBehaviour
{
    void Start()
    {
        // 1. person.json 파일을 보고 유추해서 데이터를 담을 수 있는 클래스를 만들어라
        // 2. 리소스 폴더로부터 person.json 내용을 읽어오기
        // 3. 클래스 A의 객체를 만들고 읽어온 내용을 역직렬화하기
        // 4. 클래스 A의 이름, 나이, 취미들을 Debug.Log로 출력하기
        // string jsonText = File.ReadAllText($"{Application.dataPath}/Resources/person.json");
        string jsonText = Resources.Load<TextAsset>("person").text;
        Person loadedPerson = JsonUtility.FromJson<Person>(jsonText);
        
        Debug.Log(loadedPerson.Name);
        Debug.Log(loadedPerson.Age);
        foreach (var hobby in loadedPerson.Hobby)
        {
            Debug.Log(hobby);
        }


    }

}
