using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    private float enemySpeed;
    private bool slamming;

    public static GameManager Instance;


    public void Awake()
    {
        if (!Instance) Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setIsSlamming(bool slam)
    {
        this.slamming = slam;
    }

    public bool isSlamming()
    {
        return this.slamming;
    }


}
