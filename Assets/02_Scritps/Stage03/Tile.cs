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
    public Transform[] TRPOS;

    public RuneStone runeStone;
    private Vector3 TilePosition;


    public TILE_TYPE TILE_TYPE;
    public MOVE_TYPE MOVE_TYPE;

    
    public float moveDistance;
    public float moveSpeed;

    public float EndPos;

    //eTYPE Type = eTYPE.NONE_TILE;
    TILE_TYPE Tile_Type = TILE_TYPE.NONE;

    RUENSTONE_TYPE Rune_Type = RUENSTONE_TYPE.NONE;

    // Start is called before the first frame update
    void Awake()
    {
        TilePosition = transform.position;

        EndPos = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (runeStone == null)
            return;

        if (runeStone.isPlayer == true && runeStone.ContinueRuen == (RUENSTONE_TYPE)TILE_TYPE)
       {
            //TilePosition = transform.position - new Vector3(distance, 0, 0);
            //transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);
            switch (MOVE_TYPE)
            {
                case MOVE_TYPE.HORIZONTAL:
                    {
                        if (runeStone.MoveLeft)//&& runeStone.count == 0
                        {
                            if (TilePosition.x <= TRPOS[0].position.x)
                            {
                                return;
                            }

                            TilePosition = transform.position - new Vector3(moveDistance, 0, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);

                        }
                        else if (runeStone.MoveLeft == false)//&& runeStone.count == 1
                        {
                            if (TilePosition.x >= TRPOS[1].position.x)
                            {
                                //runeStone.count = 0;
                                //direct_Type = LEFT_RIGHT.LEFT;
                                return;
                            }

                            TilePosition = transform.position - new Vector3(-moveDistance, 0, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);

                        }
                    }
                    break;

                case MOVE_TYPE.VERTICAL:

                    if (Tile_Type == (TILE_TYPE)Rune_Type)
                    {
                        if (runeStone.count == 0)
                        {
                            TilePosition = transform.position - new Vector3(0, moveDistance, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);

                            if (TilePosition.y >= TRPOS[0].position.y)
                            {
                                runeStone.count = 1;
                            }
                        }
                        else if (runeStone.count == 1)
                        {
                            TilePosition = transform.position - new Vector3(0, -moveDistance, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);

                            if (TilePosition.y >= TRPOS[1].position.y)
                            {
                                runeStone.count = 0;
                            }
                        }
                    }
                    break;
            }
        }

    }

}
