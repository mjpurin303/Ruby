using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3f;
    public int maxHealth=5;
    int currentHealth;
    Rigidbody2D rb;
    Animator anim;
    Vector2 lookDirection = new Vector2(1f,0);
    public int health{
        get{return currentHealth;}
    }
    public float timeInvincible=2f;
    bool isInvicible;
    float invincibleTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth=maxHealth;
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal,vertical);
        if(move.sqrMagnitude > 0f){
            lookDirection.Set(move.x,move.y);
            lookDirection.Normalize();
        }
        anim.SetFloat("Look X",lookDirection.x);
        anim.SetFloat("Look Y",lookDirection.y);
        anim.SetFloat("Speed",move.magnitude);

        Vector2 position = rb.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rb.MovePosition(position);

        if(isInvicible){
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0){
                isInvicible = false;
            }
        }
    }
    public void ChangeHealth(int amount){
        if(amount < 0 ){
            if(isInvicible) return;
            isInvicible= true;
            invincibleTimer = timeInvincible;
            anim.SetTrigger("Hit");
        }
        currentHealth = Mathf.Clamp(currentHealth + amount,0,maxHealth);
        Debug.Log(currentHealth +"/"+maxHealth);
    }
}
