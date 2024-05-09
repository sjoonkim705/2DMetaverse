using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MongoExample02 : MonoBehaviour
{
    void Start()
    {

        string connectionString = "mongodb+srv://skim035:mongoMango@cluster0.1oomfpp.mongodb.net/";
        MongoClient mongoClient = new MongoClient(connectionString);
        IMongoDatabase sampleDB = mongoClient.GetDatabase("sample_mflix");
        var movieCollection = sampleDB.GetCollection<BsonDocument>("movies");

        // 읽기, 쓰기, 수정, 삭제
        // 읽기
        // Find 메서드 : 컬렉션 담겨 있는 document를 조회하는 method
        // 
        // 사용 빈도 매우 높음 -> 중요
        BsonDocument data = movieCollection.Find(new BsonDocument()).FirstOrDefault();
        Debug.Log(data["plot"]);
        
        // BsonDocument는 (binary) json을 표현하는 자료형이다.
        // new BsonDocument(); --> { }

        // 2. 도큐먼트 10개 읽기
        var datas = movieCollection.Find(new BsonDocument()).Limit(10).ToList();
        foreach (var d in datas)
        {
            Debug.Log(d["title"]);
        }

        // 3. 2002년도에 개봉한 영화 찾기
        // 3-1. Bson값으로 쿼리
        BsonDocument filter = new BsonDocument();
        filter["year"] = 2002;
        var data2002 = movieCollection.Find(filter).Limit(5).ToList();
        
        // 3-2. '필터 쿼리'를 사용한 방식
        var filter2 = Builders<BsonDocument>.Filter.Eq("year", 2002);
        var data20022 = movieCollection.Find(filter).Limit(5).ToList();

        // 4. 논리연산자 (And,or,not)
        // if(1992 <= year && year <= 2002)
        var filterGte1992 = Builders<BsonDocument>.Filter.Gte("year", 1992);
        var filterLte1992 = Builders<BsonDocument>.Filter.Lte("year", 2002);
        var filterFinal = Builders<BsonDocument>.Filter.And(filterGte1992,filterLte1992);
        var data1992_2002 = movieCollection.Find(filterFinal).Limit(5).ToList();

        foreach(var d in data1992_2002)
        {
            Debug.Log(d["title"]);
        }

        // 5. where 연산자
        var whereFilter = Builders<BsonDocument>.Filter.Where(d => 1992 <= d["year"] && d["year"] <= 2002);

        // 6. 람다식
        var finalData = movieCollection.Find(d => 1992 <= d["year"] && d["year"] <= 2002).Limit(5).ToList();

    }

}
