using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3f;
    public int maxHealth=5;
    int currentHealth;
    public float timeInvincible=2f;
    bool isInvicible;
    float invincibleTimer;
    Rigidbody2D rb;
    Animator anim;
    Vector2 lookDirection = new Vector2(1f,0);

    public GameObject prefab;

    AudioSource se;
    public AudioClip cogSe;
    public AudioClip hitSe;
    
    public int health{
        get{return currentHealth;}
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth=maxHealth;
        anim = GetComponent<Animator>();
        se = GetComponent<AudioSource>();
        
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
        if(Input.GetKeyDown(KeyCode.C)){
            Launch();

        }
        if(Input.GetKeyDown(KeyCode.X)){
            Ray2D ray = new Ray2D(
                rb.position+Vector2.up * 0.2f,
                lookDirection
                );
            RaycastHit2D hit = Physics2D.Raycast(
                ray.origin,
                ray.direction,
                1.5f,
                LayerMask.GetMask("NPC")
                );
                //Debug.DrawRay(ray.origin,ray.direction * 1.5f,Color.green,1f);
                if(hit.collider != null){
                    //Debug.Log("Raycast has hit the object"+hit.collider.gameObject);
                    NonPlayerCharacter npc = hit.collider.GetComponent<NonPlayerCharacter>();
                    if(npc != null){
                        npc.DisplayDialog();
                    }
                }
        }
    }
    public void ChangeHealth(int amount){
        if(amount < 0 ){
            if(isInvicible) return;
            isInvicible= true;
            invincibleTimer = timeInvincible;
            anim.SetTrigger("Hit");
            se.PlayOneShot(hitSe);
        }
        currentHealth = Mathf.Clamp(currentHealth + amount,0,maxHealth);
        Debug.Log(currentHealth +"/"+maxHealth);
        UIHealthBar.instance.SetValue(currentHealth/(float)maxHealth);
    }
    void Launch(){
        GameObject cogBullet = Instantiate(
            prefab,
            rb.position+Vector2.up * 0.5f,
            Quaternion.identity
        );
        CogBulletController cogCon = cogBullet.GetComponent<CogBulletController>();
        cogCon.Launch(lookDirection,5f);
        se.PlayOneShot(cogSe);
        anim.SetTrigger("Launch");
    }
}
