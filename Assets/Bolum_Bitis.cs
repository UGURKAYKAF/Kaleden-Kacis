using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bolum_Bitis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
/*
    // Update is called once per frame
    void Update()
    {
        
    }
*/
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Karakter")
        {
            Invoke("SonrakiSeviye", 1.5f);
        }
    }

    private void SonrakiSeviye()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
