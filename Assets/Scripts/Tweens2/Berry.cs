using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Berry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        DOTween.Sequence()
        .Append(transform.DOMoveX(5f,1f))
        .Append(transform.DOMoveY(1f,1f))
        .Append(transform.DOMoveX(-5f,1f))
        .Append(transform.DOScale(3.5f,0.3f))
        .Append(GetComponent<SpriteRenderer>().DOFade(0f,1f));
        */

        var seq = DOTween.Sequence();
        seq.Append(transform.DOMoveX(5f,1f));
        seq.Append(transform.DOMoveX(-5f,1.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
