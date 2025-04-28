using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    RectTransform target;
    // Start is called before the first frame update
    void Start()
    {

        target = GetComponent<RectTransform>();
        target.localScale=Vector3.zero;

        

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            target.DOAnchorPos(new Vector2(350f,0),0.6f)
            .SetEase(Ease.OutBack);
            target.DOLocalRotate(new Vector3(360f,0,0),0.6f,RotateMode.FastBeyond360)
            .SetEase(Ease.OutCubic);
            
            target.DOScale(1f,0.6f).SetEase(Ease.OutBack,5f);



        }
        
    }
}
