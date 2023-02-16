using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hareket : MonoBehaviour
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



    private enum hareketDurumu { bekle, kosu, ziplama, dusme};
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
        /*if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7f);
        }*/

        yonX = Input.GetAxisRaw("Horizontal");
        //GetAxis - yavaþ þekilde artar ve azalýr
        //GetAxisRaw - doðrudan -1,0,1 arasýnda gider gelir


        if (Input.GetKey(KeyCode.LeftShift) && YerdeMi())
        {
            yonX *= 2;
        }
        if (Input.GetKey(KeyCode.LeftControl) && YerdeMi())
        {
            yonX /= 2;
        }

        rb.velocity = new Vector2(yonX * hareketGucu, rb.velocity.y);
        //rb.AddForce(new Vector2(yonX * 5, rb.velocity.y));
        //Debug.Log(yonX);

        if (Input.GetKeyDown(KeyCode.Space) && karakteryerde == true && Input.GetButtonDown("Jump") && YerdeMi())
        {
              
            rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
            karakteryerde = false;
            //rb.AddForce(new Vector2(0,7f));
        }

        AnimasyonGuncelle();
    }
    private void OnCollisionEnter2D(Collision2D temas)
    {
        if(temas.gameObject.tag == "zemin")
        {
            karakteryerde = true;
        }
        if (temas.gameObject.tag.Equals("Kapý"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (temas.gameObject.tag.Equals("tuzak"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (temas.gameObject.tag.Equals("Kapý-2"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (temas.gameObject.tag.Equals("Kapý-3"))
        {
            Application.LoadLevel(0);
        }
    }
}
