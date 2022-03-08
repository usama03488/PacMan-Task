using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public MonoGrid grid;
    private int row, col;
    int currrow, currcol;
    int currentfilled = 0;
    private int startrow,finalrow,startcol,endcol;
    public GameObject visitedCube;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("PlayerIntializer", 2);


    }

    // Update is called once per frame
    //in the update function i handled the player movement
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currcol >= 0 && currcol < col)
            {

                if (currcol != 0)
                {
                    currcol--;
                }
                Debug.Log(grid.cells[currrow][currrow].GetComponent<Cell>().status);
                this.transform.position = grid.cells[currrow][currcol].transform.position + new Vector3(0, 1f, 0);
                if (grid.cells[currrow][currcol].GetComponent<Cell>().status == Cell.Status.none)
                {
                    grid.cells[currrow][currcol].GetComponent<Cell>().setStatus(Cell.Status.visited) ;
                    currentfilled++;
                    Debug.Log(currentfilled);

                }
                else if (grid.cells[currrow][currcol].GetComponent<Cell>().status == Cell.Status.visited)
                {
                    finalrow = currrow;
                    endcol = currcol;
                    StartCoroutine("FillBox");
                    
                }
                Percentage();
                Debug.Log(grid.cells[currrow][currcol].GetComponent<Cell>().status);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (currcol >= 0 && currcol < col)
            {
                if (currcol < col - 1)
                {
                    currcol++;
                }

                this.transform.position = grid.cells[currrow][currcol].transform.position + new Vector3(0, 1f, 0);
                if (grid.cells[currrow][currcol].GetComponent<Cell>().status == Cell.Status.none)
                {
                    grid.cells[currrow][currcol].GetComponent<Cell>().setStatus(Cell.Status.visited);
                    currentfilled++;
                    Debug.Log(currentfilled);

                }
                else if(grid.cells[currrow][currcol].GetComponent<Cell>().status == Cell.Status.visited)
                {
                    finalrow = currrow;
                    endcol = currcol;
                    StartCoroutine("FillBox");
                }
                Percentage();
                Debug.Log(grid.cells[currrow][currcol].GetComponent<Cell>().status);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (currrow >= 0 && currrow < row)
            {
                if (currrow != 0)
                {
                    currrow--;
                }

                this.transform.position = grid.cells[currrow][currcol].transform.position + new Vector3(0, 1f, 0);
                if (grid.cells[currrow][currcol].GetComponent<Cell>().status == Cell.Status.none)
                {
                    grid.cells[currrow][currcol].GetComponent<Cell>().setStatus(Cell.Status.visited);

                    currentfilled++;
                    Debug.Log(currentfilled);
                }
                else if (grid.cells[currrow][currcol].GetComponent<Cell>().status == Cell.Status.visited)
                {
                    finalrow = currrow;
                    endcol = currcol;
                    StartCoroutine("FillBox");
                }
                Percentage();
                Debug.Log(grid.cells[currrow][currcol].GetComponent<Cell>().status);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (currrow >= 0 && currrow < row)
            {
                if (currrow < row - 1)
                {
                    currrow++;
                }

                this.transform.position = grid.cells[currrow][currcol].transform.position + new Vector3(0, 1f, 0);
                if (grid.cells[currrow][currcol].GetComponent<Cell>().status == Cell.Status.none)
                {
                    grid.cells[currrow][currcol].GetComponent<Cell>().setStatus(Cell.Status.visited);
                    currentfilled++;
                    Debug.Log(currentfilled);
                }
                else if (grid.cells[currrow][currcol].GetComponent<Cell>().status == Cell.Status.visited)
                {
                    finalrow = currrow;
                    endcol = currcol;
                    StartCoroutine("FillBox");
                }
                Percentage();
                Debug.Log(grid.cells[currrow][currcol].GetComponent<Cell>().status);
            }
        }
    }
    //void VerticalMovementUpward()
    //{
    //    transform.position = new Vector3();
    //}
    //void VerticalMovementDownward()
    //{
    //    transform.position = new Vector3();
    //}
    //void HorizonalMovementleft()
    //{

    //}
    //void HorizonalMovementRight()
    //{

    //}
    void PlayerIntializer()
    {
        int a = grid.Initializer();
        currrow = a;
        currcol = a;
        this.transform.position = grid.cells[a][a].transform.position + new Vector3(0, 1f, 0);
        row = grid.rows;
        col = grid.Columns;
        startrow = currrow;
        startcol = currcol;
    }
    //in this function i tried to fill the boxes that we covered by visited boxes
    public IEnumerator FillBox()
    {
        yield return new WaitForSeconds(1);
   
        if (startrow < finalrow)
        {
            Debug.Log("corutine started 1");
            for (int i = startrow; i <= finalrow ; i++)
            {
                if (startcol < endcol)
                {
                    for(int j = startcol; j <= endcol; j++)
                    {
                        grid.cells[i][j].GetComponent<Cell>().setStatus(Cell.Status.visited);
                        startrow = finalrow;
                        startcol = endcol;
                    }
                }
                else if (startcol > endcol)
                {
                    for(int j = startcol; j >= endcol; j--)
                    {
                        grid.cells[i][j].GetComponent<Cell>().setStatus(Cell.Status.visited);
                        startrow = finalrow;
                        startcol = endcol;
                    }
                }

            }
        }
        else if (startrow > finalrow)
        {
           
            for (int i = startrow; i >=finalrow; i--)
            {
                Debug.Log("corutine started 2");
                if (startcol < endcol)
                {
                    for (int j = startcol; j <= endcol; j++)
                    {
                        Debug.Log("col started1");
                        grid.cells[i][j].GetComponent<Cell>().setStatus(Cell.Status.visited);
                        startrow = finalrow;
                        startcol = endcol;
                    }
                }
                else if (startcol > endcol)
                {
                    for (int j = startcol; j >= endcol; j--)
                    {
                        Debug.Log("col started2");
                        grid.cells[i][j].GetComponent<Cell>().setStatus(Cell.Status.visited);
                        startrow = finalrow;
                        startcol = endcol;
                    }
                }

            }
        }
    }
    //In this function we calculate the percentage of the grid
    public void Percentage()
    {
        if (currentfilled != 0)
        {
            Debug.Log("row" + row);
            int totalvalue = row * col;
        
           
            float per = (currentfilled/totalvalue) * 100;
            Debug.Log(per);
            if (per >= 70.0)
            {
                Debug.Log("Congragulation you have won the match");
            }

        }
        
    }
}
