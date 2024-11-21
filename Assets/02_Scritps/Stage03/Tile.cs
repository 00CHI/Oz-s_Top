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
    //HORIZONTAL,
    //VERTICAL
    LEFT,
    RIGHT,
    UP,
    DOWN
}


public class Tile : MonoBehaviour
{
    public RuneStone runeStone;
    //public RuneStone runeStone02;
    private Vector3 TilePosition;

    public Transform[] TRPOS;


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
        //runeStone = GetComponent<RuneStone>();GetComponent는 자식오브젝트에 있는 컴포넌트만 가져올 수 있음.
    }

    // Update is called once per frame
    void Update()
    {
        if (runeStone == null)
        {
            return;
        }

        if (runeStone.ContinueRuen == (RUENSTONE_TYPE)TILE_TYPE)// && runeStone.isKeyE == true
        {
            switch (MOVE_TYPE)
            {
                case MOVE_TYPE.LEFT:

                    if (Tile_Type == (TILE_TYPE)Rune_Type)
                    {
                        if (runeStone.MoveLeft)//runeStone.count == 0
                        {
                            if (TilePosition.x <= TRPOS[0].position.x)
                            {
                                return;
                            }

                            TilePosition = transform.position - new Vector3(distance, 0, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);

                        }
                        else if (runeStone.MoveLeft == false)//runeStone.count == 1
                        {
                            if(TilePosition.x >= TRPOS[1].position.x)
                            {
                                return;
                            }

                            TilePosition = transform.position - new Vector3(-distance, 0, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);
                        }

                    }
                    break;
                case MOVE_TYPE.RIGHT:

                    if (Tile_Type == (TILE_TYPE)Rune_Type)
                    {
                        if (runeStone.MoveLeft == false)//runeStone.count == 0
                        {
                            if (TilePosition.x <= TRPOS[0].position.x)
                            {
                                return;
                            }

                            TilePosition = transform.position - new Vector3(distance, 0, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);

                        }
                        else if (runeStone.MoveLeft)//runeStone.count == 1
                        {
                            if (TilePosition.x >= TRPOS[1].position.x)
                            {
                                return;
                            }

                            TilePosition = transform.position - new Vector3(-distance, 0, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);
                        }

                    }
                    break;
                case MOVE_TYPE.UP:

                    if (Tile_Type == (TILE_TYPE)Rune_Type)
                    {
                        if (runeStone.MoveLeft == false)//runeStone.count == 0
                        {
                            if (TilePosition.y <= TRPOS[0].position.y)
                            {
                                return;
                            }

                            TilePosition = transform.position - new Vector3(0, distance, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);

                        }
                        else if (runeStone.MoveLeft)//runeStone.count == 1
                        {
                            if (TilePosition.y >= TRPOS[1].position.y)
                            {
                                return;
                            }
                            TilePosition = transform.position - new Vector3(0, -distance, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);

                        }
                    }
                    break;

                case MOVE_TYPE.DOWN:

                    if (Tile_Type == (TILE_TYPE)Rune_Type)
                    {
                        if (runeStone.MoveLeft)//runeStone.count == 0
                        {
                            if (TilePosition.y <= TRPOS[0].position.y)
                            {
                                return;
                            }

                            TilePosition = transform.position - new Vector3(0, distance, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);

                        }
                        else if (runeStone.MoveLeft == false)//runeStone.count == 1
                        {
                            if (TilePosition.y >= TRPOS[1].position.y)
                            {
                                return;
                            }
                            TilePosition = transform.position - new Vector3(0, -distance, 0);
                            transform.position = Vector3.MoveTowards(transform.position, TilePosition, moveSpeed * Time.deltaTime);

                        }
                    }
                    break;

            }
        }
       
    }

}
