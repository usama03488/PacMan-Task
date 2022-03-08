using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoGrid : MonoBehaviour
{
    public int rows;
    public int Columns;
    public float HorizontalSpacing;
    public float VerticalSpacing;
    private int counter;

    public List<List<GameObject>> cells;

    public GameObject cellPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        cells = new List<List<GameObject>>();

        InitializeCell();

    }

    // Update is called once per frame
    void Update()
    {

    }
    //this function intialize the grid
    void InitializeCell()
    {
        for (int i = 0; i < rows; i++)
        {
            cells.Add(new List<GameObject>());
            for (int j = 0; j < Columns; j++)
            {
                Transformposition();
                GameObject eachcell = Instantiate(cellPrefabs, new Vector3(HorizontalSpacing, 0, VerticalSpacing), transform.rotation);
                cells[i].Add(eachcell);
                eachcell.GetComponent<Cell>().setValues(i, j, HorizontalSpacing, VerticalSpacing);
                if (i == 0 || i == rows - 1 || j == 0 || j == Columns - 1)
                {
                    eachcell.GetComponent<Cell>().setStatus(Cell.Status.visited);
                }
                counter++;
            }
        }



    }
    //this function addd the spaces between the grid

    void Transformposition()
    {
        if (counter == rows)
        {
            VerticalSpacing += 1.5f;
            counter = 0;
            HorizontalSpacing = 2.5f;
        }
        else
        {
            HorizontalSpacing += 1.5f;
        }

    }
    public int Initializer()
    {
        int R = Random.Range(0, Columns);
        return R;
    }
}
