using UnityEngine;
using DG.Tweening;

public class HealthCollectable : MonoBehaviour
{
    AudioSource se;
    void Start()
    {
        se=GetComponent<AudioSource>();
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       //Debug.Log("triggerと接触:"+other);
       RubyController rubyCon = other.GetComponent<RubyController>();
       if(rubyCon != null){
        if(rubyCon.health == rubyCon.maxHealth){return;}
        rubyCon.ChangeHealth(1);
        se.Play();
        GetComponent<SpriteRenderer>().DOFade(0f,1f)
        .OnComplete(()=>Destroy(gameObject));
       }
    }

}
