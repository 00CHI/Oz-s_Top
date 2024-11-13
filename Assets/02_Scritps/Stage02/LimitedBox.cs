using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedBox : MonoBehaviour
{
    public GameObject limited;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            limited.gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            limited.gameObject.SetActive(true);
        }
    }
}
