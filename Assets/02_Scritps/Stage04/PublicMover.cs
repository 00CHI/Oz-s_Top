using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ü������ ����
public class PublicMover : MonoBehaviour
{
    Vector3 pos; //������ġ

    public float delta; // ��(��)�� �̵������� (x)�ִ밪

    public float speed; // �̵��ӵ�


    void Start()
    {

        pos = transform.position;

    }


    void Update()
    {

        Vector3 v = pos;

        //Mathf.Sin == delta ���� �ٴٸ��� �� ���� ó�� () ����ؼ� �տ��� ���� �־���.
        v.x += delta * Mathf.Sin(Time.time * speed);
        // �¿� �̵��� �ִ�ġ �� ���� ó��

        transform.position = v;

    }
}


