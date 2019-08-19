using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{

    public GameObject[] groups;
  
    int newBlock,oldBlock;
    // Start is called before the first frame update
    void Start()
    {
        //createRandom();
        newBlock = Random.Range(0, groups.Length);
        createNext();
    }

    void createRandom()
    {
        newBlock = Random.Range(0, groups.Length);
        GameObject.Find("NewNextBlock").GetComponent<DisplayControl>().displayNext(newBlock);
    }

    public void createNext()
    {
        //createRandom();
        newToOld();

        GameObject ins = Instantiate(groups[oldBlock], transform.position, Quaternion.identity) as GameObject;
        createRandom();
    }

    void newToOld()
    {
        oldBlock = newBlock;
    }

    
    //创建新的，展示出来
    //下一个


}
