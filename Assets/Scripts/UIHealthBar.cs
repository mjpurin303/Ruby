using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance{get; private set;}
    public Image mask;
    float originalSize;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        originalSize=mask.rectTransform.rect.width;
        
    }

    public void SetValue(float value){
        //mask.reoctTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,originalSize * value);
        DOTween.To(
            ()=>mask.rectTransform.rect.width,
            x=>mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,x),
            originalSize*value,
            0.3f
        );

    }



        
}
