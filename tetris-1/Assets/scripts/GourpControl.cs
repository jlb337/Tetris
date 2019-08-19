using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GourpControl : MonoBehaviour
{

    float time;


    //平滑程度0.01-1
    float smooth;
    //public float baseInterval;
    //1-10,数值越大，越快
    public int speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        //baseInterval = 0.1;



        smooth = 1.0f / (float)speed;

        if (!isGridValid())
        {

            //通过find找到在Canvas/Score路径下的脚本：UImanager，再调用该脚本的GameOver方法。
            GameObject.Find("Canvas/Score").GetComponent<UImanager>().GameOver();
            Debug.Log("GAME OVER!");
            Destroy(gameObject);
            enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time >=  smooth)
        {
            time = Time.time;
            transform.position += new Vector3(0, -smooth * speed, 0);
            if (!isGridValid())
            {
                transform.position += new Vector3(0, smooth * speed, 0);
                setGridInvalid();
                TetrisGrid.deleteAllFullRow();


                FindObjectOfType<CreateBlock>().createNext();
                enabled = false;
            }
        }
        //控制左移
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!isGridValid())
            {
                transform.position += new Vector3(1, 0, 0);

            }
        }
        //Input.GetKey
        //控制右移
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!isGridValid())
            {
                transform.position += new Vector3(-1, 0, 0);

            }
        }
        //控制下移
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!isGridValid())
            {
                transform.position += new Vector3(0, 1, 0);

            }
        }
        //控制旋转
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);
            if (!isGridValid())
            {
                //transform.position += new Vector3(1, 0, 0);
                transform.Rotate(0, 0, 90);

            }
            //transform.position += new  Vector3(-1, 0, 0);
        }



        //if (TetrisGrid.isRowFull())
        //{
        //    setGridValid(h);
        //    moveGrid();

        //}


    }

    bool isGridValid()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = TetrisGrid.roundVec2(child.position);

            if (!TetrisGrid.isBlockInborder(v))
            {

                //Debug.Log("out\n");
                return false;
            }


            if (TetrisGrid.grid[(int)v.x, (int)v.y] != null)
            {
                return false;
            }

        }


        return true;
    }

    void setGridInvalid()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = TetrisGrid.roundVec2(child.position);
            TetrisGrid.grid[((int)v.x), (int)v.y] = child;
            //TetrisGrid.setGridInvalid(v);





        }
    }

}
