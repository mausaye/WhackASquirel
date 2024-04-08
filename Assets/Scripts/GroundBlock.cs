using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBlock : MonoBehaviour
{
    //This is attached to the dirt object such that it is able to change
    [SerializeField] GameObject dirtPrefab;
    [SerializeField] GameObject squirrelPrefab;
    private GameObject squirrelGroup;

    private GameObject squirrel;
    private bool waitingToBeSummoned = false;

    // Start is called before the first frame update
    void Start()
    {

        squirrelGroup = GameObject.Find("Squirrels");
        //summonSquirrel();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!waitingToBeSummoned && !squirrel)
        {
            StartCoroutine(delayInstantiate(Random.Range(5, 25)));
            waitingToBeSummoned = true;
        }


    }

    IEnumerator delayInstantiate(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        summonSquirrel();
      
        
    }

    void summonSquirrel()
    {
        Vector3 currLocation = this.gameObject.transform.position;

        squirrel = Instantiate(squirrelPrefab, currLocation, Quaternion.identity);
        //Debug.Log("Squ created");
        squirrel.transform.SetParent(squirrelGroup.transform);
        waitingToBeSummoned = false;
    }




}
