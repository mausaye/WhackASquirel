using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelBehavior : MonoBehaviour
{
    private int speed;
    private int duration;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        speed = 3;
        duration = 4;
        //Debug.Log("Squirell Behavirot");
      //  StartCoroutine(delayDestroy(Random.Range(4,10)));
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator delayDestroy(int seconds)
    {
       // Debug.Log("called destroy");
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);


    }

    private void OnCollisionEnter(Collision collision)
    {

        if (gm.isSlamming())
        {
            Destroy(this.gameObject);
        } else
        {
            Debug.Log("touched squirrel wah wah");
        }
    }

}
