using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//전체적으로 수정
public class PublicMover : MonoBehaviour
{
    Vector3 pos; //현재위치

    public float delta; // 좌(우)로 이동가능한 (x)최대값

    public float speed; // 이동속도


    void Start()
    {

        pos = transform.position;

    }


    void Update()
    {

        Vector3 v = pos;

        //Mathf.Sin == delta 값에 다다르면 값 반전 처리 () 계속해서 앞에다 값을 넣어줌.
        v.x += delta * Mathf.Sin(Time.time * speed);
        // 좌우 이동의 최대치 및 반전 처리

        transform.position = v;

    }
}


