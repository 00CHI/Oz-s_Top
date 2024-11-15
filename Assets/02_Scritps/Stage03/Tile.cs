using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TILE_TYPE
{
    RED,
    GREEN, 
    BLUE, 
    PURPLE,
    BLACK,
    NONE
}

public enum MOVE_TYPE
{
    HORIZONTAL,
    VERTICAL

}

public class Tile : MonoBehaviour
{
    private RuneStone runeStone;
    private Vector3 TilePosition;


    public TILE_TYPE TILE_TYPE;
    public MOVE_TYPE MOVE_TYPE;

    
    public float distance;
    public float moveSpeed;

    //eTYPE Type = eTYPE.NONE_TILE;
    TILE_TYPE Tile_Type = TILE_TYPE.NONE;

    RUENSTONE_TYPE Rune_Type = RUENSTONE_TYPE.NONE;

    // Start is called before the first frame update
    void Awake()
    {
        TilePosition = transform.position;
        runeStone = GetComponent<RuneStone>();
    }

    // Update is called once per frame
    void Update()
    {
        if (runeStone.isPlayer == true && runeStone.isKeyE == true)
        {
            switch (MOVE_TYPE)
            {
                case MOVE_TYPE.HORIZONTAL:

                    if (Tile_Type == (TILE_TYPE)Rune_Type)
                    {
                        if (runeStone.count == 0)
                        {
                            TilePosition = transform.position - new Vector3(distance, 0, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);

                            runeStone.count = 1;
                        }
                        else if (runeStone.count == 1)
                        {
                            TilePosition = transform.position - new Vector3(-distance, 0, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);

                            runeStone.count = 0;
                        }
                    }
                    break;

                case MOVE_TYPE.VERTICAL:

                    if (Tile_Type == (TILE_TYPE)Rune_Type)
                    {
                        if (runeStone.count == 0)
                        {
                            TilePosition = transform.position - new Vector3(0, distance, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);
                        }
                        else if (runeStone.count == 1)
                        {
                            TilePosition = transform.position - new Vector3(0, -distance, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);
                        }

                    }
                    break;
            }
        }
       
    }

}
