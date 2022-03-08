using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    // Start is called before the first frame update
    private int X;
    private int Y;
    public float xspacing;
    public float zspacing;
    public Status status=Status.none;
    public GameObject visited;

    //in this function cell position is set
    public void setValues(int row, int col,float x,float y)
    {
        X = row;
        Y = col;
        xspacing = x;
        zspacing = y;   

    }
    //update fuction check the status of box that is visited or not
    public void Update()
    {
        if (status == Status.visited)
        {
         visited.SetActive(true);
         
        }
    }
    //this the status enum function
    public enum Status { none, visited }
    //this function return the row number of the current cell
    public int getRow()
    {

        return X;
    }
    //this function return the column of cell
    public int getColumn()
    {
        return Y;

    }
    //this function set the status of the cell
    public void setStatus(Status st)
    {
        status = st;
    }
    //this function return the status of cell
    public Status GetStatus()
    {
        return status;
    }

}
