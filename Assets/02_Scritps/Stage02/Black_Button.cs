using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Button : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    Vector3 TilePosition;

    public Transform TRPOS;
    bool isBox = false;

    public Sprite[] buttonSprite;
    public GameObject blackTile;

    public float distance;
    public float moveSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        TilePosition = blackTile.transform.position;

        spriteRenderer = GetComponent<SpriteRenderer>();
        isBox = false;
        spriteRenderer.sprite = buttonSprite[0];
    }

    private void Update()
    {
        if(isBox)
        {
            if(TilePosition.x > TRPOS.position.x)
            {
                spriteRenderer.sprite = buttonSprite[1];

                TilePosition = blackTile.transform.position - new Vector3(-distance, 0, 0);
                blackTile.transform.position = Vector3.MoveTowards(blackTile.transform.position, TilePosition, moveSpeed * Time.deltaTime);
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Box"))
        {
            isBox = true;
        }
    }
}
