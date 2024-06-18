using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MongoExample03 : MonoBehaviour
{
    // 도큐먼트 삽입 (Create)
    private void Start()
    {
        string connectionString = "mongodb+srv://skim035:mongoMango@cluster0.1oomfpp.mongodb.net/";
        MongoClient mongoClient = new MongoClient(connectionString);
        IMongoDatabase sampleDB = mongoClient.GetDatabase("metaverse");
        var collection = sampleDB.GetCollection<Article>("articles");
        
        // 1. 도큐먼트 하나 삽입
        // InsertOne(도큐먼트)
        Article article = new Article
        {
            Name = "김성준",
            Content = "공지사항입니다",
            Like = 20,
            WriteTime = DateTime.Now,

        };
        Debug.Log(article.Id);
        collection.InsertOne(article);

        // 2. 도큐먼트 여러개 삽입
        // InsertMany(List<도큐먼트>)
        List<Article> articles = new List<Article>()
        {
            new Article()
            {
                Name = "티모",
                Content = "안녕안녕",
                Like = 20,
                WriteTime = DateTime.Now,
            },       
            new Article()
            {
                Name = "티모5",
                Content = "호호안녕",
                Like = 42,
                WriteTime = DateTime.Now,
            },
                        
            new Article()
            {
                Name = "모모",
                Content = "안녕하하",
                Like = 42,
                WriteTime = DateTime.Now,
            }

        };
        collection.InsertMany(articles);

    }

}
