using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject[] noktalar;
    private int noktaIndisi = 0;

    [SerializeField] private float hiz = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, noktalar[noktaIndisi].transform.position) < .1f)
        {
            noktaIndisi++;
            if (noktaIndisi >= noktalar.Length)
            {
                noktaIndisi = 0;
            }
        }
        this.transform.position = Vector2.MoveTowards(this.transform.position, noktalar[noktaIndisi].transform.position, Time.deltaTime * 2f);

    }
}
