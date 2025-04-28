using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StrowBerry : MonoBehaviour
{
    public GameObject message;
    // Start is called before the first frame update
    void Start()
    {
        /*
        transform.DOMove(new Vector3(-3f,0,0),1f)
        .SetLoops(5,LoopType.Incremental);
        */
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.DOFade(0,2f)
        .OnComplete(ShowMessage);
        
    }
    void ShowMessage(){
        message.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
