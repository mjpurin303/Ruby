using UnityEngine;
using TMPro;
using DG.Tweening;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4f;
    GameObject dialogBox;
    float timerDisplay;

    public TextMeshProUGUI text;
    string msg;

    void Start()
    {
        dialogBox=transform.GetChild(0).gameObject;
        dialogBox.transform.localScale=Vector3.zero;
        timerDisplay=-1f;
        msg = text.text;
        text.text="";
    }

    // Update is called once per frame
    void Update()
    {
        if(timerDisplay >=0){
            timerDisplay -= Time.deltaTime;
            if(timerDisplay < 0){
                dialogBox.transform.DOScale(Vector3.zero ,0.3f)
                .OnComplete(()=>text.text="");
            }
        }
    }
    public void DisplayDialog(){
        timerDisplay=displayTime;
        DOTween.Sequence().
        Append(dialogBox.transform.DOScale(Vector3.one * 0.01f,0.3f)).
        Append(text.DOText(msg,2f));
    }
}
