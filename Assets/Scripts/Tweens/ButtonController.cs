using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text= transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        text.DOFade(0.5f,1f)
        .SetLoops(-1,LoopType.Yoyo);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
