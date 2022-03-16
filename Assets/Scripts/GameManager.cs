using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Text talk;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;


    public void Action(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            scanObject = scanObj;
            talk.text = scanObject.name;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNpc);
        }

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc){
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (isNpc)
        {
            talk.text = talkData;
        }else{
            talk.text = talkData;
        }
    }

}
