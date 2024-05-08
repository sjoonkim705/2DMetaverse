using JetBrains.Annotations;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;


public class MongoExample01 : MonoBehaviour
{

    void Start()
    {
        // var : 암시적 타입으로 데이터의 자료형을 자동으로 설정하는 키워드
        // r-value로부터 자동으로 타입을 유추
        
        // 단점: 자료형이 명확하지 않아서 휴먼에러 가능성
        // 언제쓰면 좋은가? 자료형이 너무 길경우
        //                  foreach 반복문에서 명확할경우

        int number = 3;
        float number2 = 2.3f;
        string myName = "티모";

        // MongoDB 연결
        // 연결 문자열 : 데이터베이스 연결을 위한 정보가 담겨있는 문자열
        string connectionString = "mongodb+srv://skim035:mongoMango@cluster0.1oomfpp.mongodb.net/";

        // - 프로토콜: mongodb+srv
        // - 아이디 : skim035
        // - 비밀번호 :
        // - 주소: cluster0.1oomfpp.mongodb.net/

        // 1. 접속
        MongoClient mongoClient = new MongoClient(connectionString);
        // 2. 데이터베이스가 리스트?
        List<BsonDocument> dbList = mongoClient.ListDatabases().ToList();
        foreach (BsonDocument db in dbList)
        {
            Debug.Log(db["name"]);
        }

        // 3. 특정 데이터베이스에 연결
        IMongoDatabase sampleDB = mongoClient.GetDatabase("sample_mflix");

        // 4. collection들 이름 확인
        List<string> collectionNames = sampleDB.ListCollectionNames().ToList();
        foreach (string name in collectionNames)
        {
            Debug.Log(name);
        }

        // 5. collection 연결
        var movieCollection = sampleDB.GetCollection<BsonDocument>("movies");
        long count = movieCollection.CountDocuments(new BsonDocument());


        // 6. 도큐먼트 하나만 읽기
        var firstDoc = movieCollection.Find(new BsonDocument()).FirstOrDefault();



    }

}
