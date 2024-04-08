using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGroundObjects : MonoBehaviour
{
    private int rows;
    private int col;
    private float offset;
    private float translationX;

    [SerializeField] GameObject dirtGroup;
    [SerializeField] GameObject holeGroup;

    [SerializeField] GameObject dirtPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.rows = 4;
        this.col = 4;
        this.offset = 3;
        this.translationX = 4.5f;


        generateDirt();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateDirt()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col; j++)
            {
                var dirtObj = Instantiate(dirtPrefab, new Vector3(i * offset - translationX, -3.3f, j * offset), Quaternion.identity);
                dirtObj.transform.SetParent(dirtGroup.transform);
                
            }
        }
    }
}
