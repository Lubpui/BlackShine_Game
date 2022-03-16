using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDialog : MonoBehaviour
{
    public Text texttalk;
    public GameObject scanObject;

   
    public void Action(GameObject scanObj){
        scanObject = scanObj;
        texttalk.text = "Happy B Day" + scanObject.name + "to kun fan!!!";

    }
}
