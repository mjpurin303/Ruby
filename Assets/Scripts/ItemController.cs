using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        transform.DOLocalMove(new Vector3(5f,0f,0f),2f)
        .SetEase(Ease.InOutQuart);
        */
        /*
        DOTween.To(
            ()=>transform.localPosition,
            x => transform.localPosition = x,
            new Vector3(5f,0,0),
            2f);
        */
        
        //transform.DOMoveX(5f,2f);
        transform.DORotate(new Vector3(0f,0f,720f),2f,RotateMode.FastBeyond360)
        .SetDelay(2f);



        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
