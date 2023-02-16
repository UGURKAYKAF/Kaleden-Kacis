using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraHareket : MonoBehaviour
{
    [SerializeField] Transform donusum;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(donusum.position.x, donusum.position.y, -10);
    }
}
