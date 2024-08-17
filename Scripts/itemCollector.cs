using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
public class itemCollector : MonoBehaviour
{
    private int gemcount = 0;
    [SerializeField] private Text gemcounttext;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    
        if (collision.gameObject.CompareTag("Gem"))
            {
                Destroy(collision.gameObject);
                gemcount ++;
                gemcounttext.text = "X"+ gemcount;
            }
    
    }
}
