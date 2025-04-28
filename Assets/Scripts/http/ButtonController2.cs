using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.Accessibility;

public class ButtonController2 : MonoBehaviour
{
    public TMP_InputField et1;
    public TMP_InputField et2;
    public TMP_Text text;

    
    public void BtClick(){
        string x = et1.text;
        string y = et2.text;
        StartCoroutine(HttpConnect(x,y));
    }
    IEnumerator HttpConnect(string x, string y){
        WWWForm form = new WWWForm();
        form.AddField("x",x);
        form.AddField("y",y);
        string url = "https://joytas.net/php/calc.php";
        using(UnityWebRequest uwr = UnityWebRequest.Post(url,form)){
            yield return uwr.SendWebRequest();
            if(uwr.result != UnityWebRequest.Result.Success){
                Debug.Log(uwr.error);

            }else{
                text.text = uwr.downloadHandler.text;

            }
        }

    }
}
