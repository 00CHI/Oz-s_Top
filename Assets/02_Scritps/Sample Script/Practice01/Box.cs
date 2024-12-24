using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Box : PlayerPractice
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Box Tag
        if (collision.gameObject.CompareTag("Box"))
        {
            float yGap = transform.position.y - collision.gameObject.transform.position.y;
            //Debug.LogError("GAP: " + yGap);

            if (yGap < 1)
            {
                anim.SetBool("isPull", true);
                anim.SetBool("isRun", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isJump", false);
            }
            else
            {
                anim.SetBool("isJump", false);
                anim.SetBool("isPull", false);
                anim.SetBool("isRun", true);
                anim.SetBool("isIdle", true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Box Tag
        if (collision.gameObject.CompareTag("Box"))
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isPull", false);
            anim.SetBool("isRun", true);
            anim.SetBool("isIdle", true);
        }
    }
}
