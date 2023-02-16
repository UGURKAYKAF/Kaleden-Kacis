using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jump : MonoBehaviour
{
    float yonX = 0f;

    Rigidbody2D rb;

    BoxCollider2D collider;
    Animator animasyon;
    SpriteRenderer sprite;
    [SerializeField] LayerMask ziplamaAlani;

    [SerializeField] float hareketGucu = 7f;
    [SerializeField] float ziplamaGucu = 10f;

    public bool karakteryerde = true;



    private enum hareketDurumu { bekle, kosu, ziplama, dusme };
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animasyon = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }


    private bool YerdeMi()
    {
        return Physics2D.BoxCast(collider.bounds.center,
            collider.bounds.size, 0f, Vector2.down, .1f, ziplamaAlani);

        //RaycastHit2D raycastHit2D = Physics2D.BoxCast(collider.bounds.center,collider.bounds.size, 0f, Vector2.down, .1f, ziplamaAlani);
        //return raycastHit2D != null;
    }

    private void AnimasyonGuncelle()
    {
        hareketDurumu durum;
        if (yonX < 0)
        {
            sprite.flipX = true;
            durum = hareketDurumu.kosu;
            //animasyon.SetBool("kosuyor", true);
        }
        else if (yonX > 0)
        {
            sprite.flipX = false;
            durum = hareketDurumu.kosu;
            //animasyon.SetBool("kosuyor", true);
        }
        else
        {
            durum = hareketDurumu.bekle;
            //animasyon.SetBool("kosuyor", false);
        }

        if (rb.velocity.y > .1f)
        {
            durum = hareketDurumu.ziplama;
        }
        else if (rb.velocity.y < -.1f)
        {
            durum = hareketDurumu.dusme;
        }


        animasyon.SetInteger("durum", (int)durum);
    }

    // Update is called once per frame
    void Update()
    {


            rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
            karakteryerde = false;
          
        AnimasyonGuncelle();
    }
   
}
