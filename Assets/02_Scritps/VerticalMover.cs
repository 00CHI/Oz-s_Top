using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ü������ ����
public class VerticalMover : MonoBehaviour
{
    Vector3 pos; //������ġ
    Animator anim;

    public float delta = 2.0f; // ��(��)�� �̵������� (x)�ִ밪

    float speed = 1.5f; // �̵��ӵ�


    void Start()
    {

        pos = transform.position;

    }


    void Update()
    {

        Vector3 v = pos;

        //Mathf.Sin == delta ���� �ٴٸ��� �� ���� ó�� () ����ؼ� �տ��� ���� �־���.
        v.y += delta * Mathf.Sin(Time.time * speed);
        // �¿� �̵��� �ִ�ġ �� ���� ó��

        transform.position = v;

    }
}


