using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayControl : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] groups;

    GameObject newIns, oldIns;

    public void displayNext(int myBlock)
    {
        oldIns = newIns;
        Destroy(oldIns);
        //myBlock = GameObject.Find("createBlock").GetComponent<CreateBlock>().newBlock;
        // Vector3 newpos = transform.position + new Vector3(1, 1, 0);
        Debug.Log("displayNext:" + myBlock.ToString());
        newIns = Instantiate(groups[myBlock], transform.position, Quaternion.identity) as GameObject;
    }
    //public int i;
    //int myBlock;
    // Start is called before the first frame update
    void Start()
    {
        newIns = Instantiate(groups[0], transform.position, Quaternion.identity) as GameObject;
        //createNext();
    }

    // GameObject.Find("Canvas/Score").GetComponent<UImanager>().GameOver();
    //public void createNext()
    //{
    //    //createRandom();
    //    newToOld();
    //    //GameObject ins = Instantiate(groups[oldBlock], transform.position, Quaternion.identity) as GameObject;
    //    displayNext();
    //}



    // GameObject.Find("Canvas/Score").GetComponent<UImanager>().GameOver();


}
