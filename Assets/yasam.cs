using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yasam : MonoBehaviour
{
    Animator animasyon;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        animasyon = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tuzak"))
        {
            animasyon.SetTrigger("patladi");
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void YenidenBaslat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
