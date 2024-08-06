using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollwer : MonoBehaviour
{
    
    public Transform targetTransfrom;
    
    public float speed;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        //bring Player position
        transform.position = targetTransfrom.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransfrom != null)
        {
            //Screen maxX,minX 
            float clampedX = Mathf.Clamp(targetTransfrom.position.x, minX, maxX);
            //Screen maxY,minY
            float clampedY = Mathf.Clamp(targetTransfrom.position.y, minY, maxY);

            //smooth camera speed
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), speed);
            // Lerp : 선형보간 찾고 싶은 일부지점을 비율(t)로 표시하여 값을 예측해서 받아옴.
        }
    }
}
