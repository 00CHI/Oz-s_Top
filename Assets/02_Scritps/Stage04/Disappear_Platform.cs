using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapear_Platform : MonoBehaviour
{
    //bool isPlayer = false;
    public GameObject platform;
    private SpriteRenderer spriteRenderer;



    public float fadeDuration = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {

                Invoke("Disappear", 0.5f);

        }
    }


    //private void OnCollisionExit2D(Collision2D coll)
    //{
    //    if (coll.gameObject.CompareTag("Player"))
    //    {
    //        if (!isFadingIn)
    //        {
    //            Invoke("Appear", 2f);
    //        }
    //    }
    //}

    private void Appear()
    {
        platform.gameObject.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }

    void Disappear()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut());
    }

   

    IEnumerator FadeOut()
    {
        //isFadingOut = true;
        float startAlpha = spriteRenderer.color.a;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            Color color = spriteRenderer.color;
            color.a = Mathf.Lerp(startAlpha, 0, normalizedTime);
            spriteRenderer.color = color;
            yield return null;
        }

        //Color finalColor = spriteRenderer.color;
        //finalColor.a = 0;
        //spriteRenderer.color = finalColor;

        platform.gameObject.SetActive(false);

        //yield return new WaitForSeconds(1f);
        Invoke("Appear", 1f);


    }
    IEnumerator FadeIn()
    {

        float startAlpha = spriteRenderer.color.a;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            Color color = spriteRenderer.color;
            color.a = Mathf.Lerp(startAlpha, 1, normalizedTime);
            spriteRenderer.color = color;
            yield return null;
        }

        // 완전히 불투명하게 설정
        Color finalColor = spriteRenderer.color;
        finalColor.a = 1;
        spriteRenderer.color = finalColor;

        //isFadingIn = false;
    }
}
