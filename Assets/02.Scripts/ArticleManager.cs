using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

using UnityEngine;

public class ArticleManager : MonoBehaviour
{
    private List<Article> _articles = new List<Article>();
    public List<Article> Articles => _articles;
    private IMongoCollection<Article> _articleCollection;
    public UI_ArticleList UI_ArticleList;


    public static ArticleManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        Init();
        // 몽고DB로부터 article 조회
        // 1. 몽고DB 연결
        // 2. 특정 데이터베이스 연결
        // 3. 특정 컬렉션 연결
        // 4. 모든 문서 읽어오기
        // 5. 읽어온 문서 만큼 New article()해서 데이터 채우고
        // 6. _articles에 넣기

    }
    public void Init()
    {
        string connectionString = "mongodb+srv://skim035:mongoMango@cluster0.1oomfpp.mongodb.net/";
        MongoClient mongoClient = new MongoClient(connectionString);
        IMongoDatabase sampleDB = mongoClient.GetDatabase("metaverse");
        _articleCollection = sampleDB.GetCollection<Article>("articles");
        FindAll();
    }
    public void FindAll()
    {
        // 4. 모든 문서 읽어오기
        // 4.1 WriteTime을 기준으로 '정렬
        // Sort메서드를 이용해서 도큐먼트를 정렬할 수 있다.
        // 매개변수로는 어떤 Key로 정렬할 것인지 전달해주면 된다.

        var sort = new BsonDocument();
        sort["WriteTime"] = -1;
        // +1. -> 오름차순 정렬 -> 낮은 값에서 높은 값으로 정렬한다.
        // -1 -> 내림차순 정렬 -> 높은 값에서 낮은 값으로 정렬한다.
        _articles = _articleCollection.Find(new BsonDocument()).Sort(sort).ToList();


/*        // var dataList = _articleCollection.Sort(new BsonDocument("WriteTime")).ToList();
        _articles.Clear();

        foreach (var articleData in dataList)
        {
            Article newArticle = new Article();
            newArticle.ArticleType = (ArticleType)articleData["ArticleType"].ToInt64();
            newArticle.Name = articleData["Name"].ToString();
            newArticle.Content = articleData["Content"].ToString();
            newArticle.Like = (int)articleData["Like"];

            string articleDateString = articleData["WriteTime"].ToString();
            DateTime articleDate = DateTime.Parse(articleDateString);
            newArticle.WriteTime = articleDate;
            _articles.Add(newArticle);
        }*/
    }

    public void FindNotice()
    {

        _articles = _articleCollection.Find(data => (int)data.ArticleType == (int)ArticleType.Notice).ToList();

    }
    public void Write(ArticleType articleType, string content)
    {
        Article article = new Article()
        {
            ArticleType = articleType,
            Name = "김성준",
            Content = content,
            Like = 0,
            WriteTime = DateTime.Now,
        };
        _articleCollection.InsertOne(article);

    }
    public void Modify(Article targetArticle, string content, bool isNotice)
    {
        var contentUpdate = Builders<Article>.Update.Set("Content", content);
        var typeUpdate = Builders<Article>.Update.Set("ArticleType", isNotice ? ArticleType.Notice : ArticleType.Normal);
        UpdateResult result = _articleCollection.UpdateOne(data => data.Id == targetArticle.Id, contentUpdate);
        _articleCollection.UpdateOne(data => data.Id == targetArticle.Id, typeUpdate);
    }
    public void Delete(Article article)
    {
        var filter = Builders<Article>.Filter.Eq("_id", article.Id);
        var result = _articleCollection.DeleteOne(d=> d.Id == article.Id);

    }
    public void AddLike(Article article)
    {
        var updateDefinition = Builders<Article>.Update.Inc("Like", 1); //DB에 있는 정보보다 1증가
        UpdateResult result = _articleCollection.UpdateOne(data => data.Id == article.Id, updateDefinition);
    }
}







        // 1. Filestream 으로 텍스트 저장
        // 2. 객체직렬화 -> Binary 저장
        // 3. Playerprefs



/*        // 1. 객체를 Json형태로 변환한 다음 'data.txt'에 저장하고 확인한다.
*//*        ArticleData articleData = new ArticleData(_articles);
        string jsonData = JsonUtility.ToJson(articleData);
        Debug.Log(jsonData);*//*
        // 유니티의 특별한 파일 저장 경로
        // 유니티만이 쓸 수 있는 파일 저장 경로를 가지고 있다.
        Debug.Log(Application.persistentDataPath);
        string path = Application.persistentDataPath;
*//*        StreamWriter sw = File.CreateText($"{path}/data.txt");
        sw.Write(jsonData);
        sw.Close();*//*

        string txt = File.ReadAllText($"{path}/data.txt");
        _articles = JsonUtility.FromJson<ArticleData>(txt).Data;*/


/*        string data = JsonUtility.ToJson(_articles);
        FileStream fs = new FileStream("c:\\User\\data.txt", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(data);
        sw.Close();*/






    // 2. 데이터를 하드코딩한 코드를 지운다.
    
    // 3. 'data.txt' 로부터 json을 읽어와서 객체들을 초기화한다.

    
