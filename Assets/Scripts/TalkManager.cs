using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
   Dictionary<int, string[]> talkData;

   void Awake()
   {
       talkData = new Dictionary<int, string[]>();
       GenerateData();
   }

   void GenerateData(){
       talkData.Add(1001, new string[] {"Hello Baby!!", "Wan ni pen wan a rai kan na"});
       talkData.Add(1000, new string[] {"Hello Baby!!", "Rak ter mak mak na ka"});
       talkData.Add(2000, new string[] {"Hello Baby!!", "Rak ter mak mak na ka"});
       talkData.Add(3000, new string[] {"Hello Baby!!", "Rak ter mak mak na ka"});
       talkData.Add(4000, new string[] {"Hello Baby!!", "Rak ter mak mak na ka"});
       talkData.Add(5000, new string[] {"Hello Baby!!", "Rak ter mak mak na ka"});
       talkData.Add(6000, new string[] {"Hello Baby!!", "Rak ter mak mak na ka"});
       talkData.Add(7000, new string[] {"Hello Baby!!", "Rak ter mak mak na ka"});
       talkData.Add(8000, new string[] {"Hello Baby!!", "Rak ter mak mak na ka"});
       talkData.Add(10000, new string[] {"Hello Baby!!", "Rak ter mak mak na ka"});
       talkData.Add(11000, new string[] {"Hello Baby!!", "Rak ter mak mak na ka"});
       talkData.Add(9000, new string[] {"Hello Baby!!", "Rak ter mak mak na ka"});

   }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
