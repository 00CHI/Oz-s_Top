//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Scissors : MonoBehaviour
//{
//    Player04 player04;

//    public enum InfoType { Scissor01, Scissor02, Scissor03, Scissor04 }
//    public InfoType type;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {

//        if (collision.gameObject.CompareTag("Player"))
//        {

//            switch (type)
//            {
//                case InfoType.Scissor01:

//                    player04.tagScissor01 = true;
//                    break;
//                case InfoType.Scissor02:

//                    player04.tagScissor02 = true;
//                    break;
//                case InfoType.Scissor03:

//                    player04.tagScissor03 = true;
//                    break;
//                case InfoType.Scissor04:

//                    player04.tagScissor04 = true;
//                    break;
//            }
//        }
//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {

//        if (collision.gameObject.CompareTag("Player"))
//        {

//            switch (type)
//            {
//                case InfoType.Scissor01:

//                    player04.tagScissor01 = false;
//                    break;
//                case InfoType.Scissor02:

//                    player04.tagScissor02 = false;
//                    break;
//                case InfoType.Scissor03:

//                    player04.tagScissor03 = false;
//                    break;
//                case InfoType.Scissor04:

//                    player04.tagScissor04 = false;
//                    break;
//            }
//        }
//    }
//}
