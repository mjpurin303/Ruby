using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed=1f;
    public bool isVertical;
    public float changeTime=2f;

    Rigidbody2D rb;
    float timer;
    int direction=1;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        timer=changeTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0){
            direction =-direction;
            timer = changeTime;
        }
        Vector2 pos = rb.position;
        if(isVertical){
            pos.y = pos.y + Time.deltaTime * speed * direction;

        }else{
            pos.x = pos.x + Time.deltaTime * speed * direction;

        }
        rb.MovePosition(pos);
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController rubyCon = other.gameObject.GetComponent<RubyController>();
        if(rubyCon != null){
            rubyCon.ChangeHealth(-1);
        }
        
    }
}
