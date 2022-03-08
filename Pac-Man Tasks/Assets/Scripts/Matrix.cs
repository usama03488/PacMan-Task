using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix
{
    private int numberofRows;
    private int numberofColumns;
    public List<List<int>> Matrix1 = new List<List<int>>();
    public List<List<int>> Matrix2 = new List<List<int>>();
    public List<List<int>> Matrix3 = new List<List<int>>();
    List<int> ArrList = new List<int>();
    int[,] shipPosition;
    // Start is called before the first frame update
    public Matrix(int r, int c)
    {
        numberofRows = r;
        numberofColumns = c;
        shipPosition = new int[r, c];
        setArray();
    }
    public Matrix()
    {

    }
    void Start()
    {
        setArray();
        SetMatrix1(shipPosition);
        printmatrix();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setArray()
    {
        for (int i = 0; i < numberofRows; i++)
        {
            for (int j = 0; j < numberofColumns; j++)
            {

                shipPosition[i, j] = 0;


            }
        }
        SetMatrix1(shipPosition);

    }
    public void SetMatrix1(int[,] arr)
    {
        Matrix1 = new List<List<int>>();
        for (int i = 0; i < numberofRows; i++)
        {

            ArrList = new List<int>();

            for (int j = 0; j < numberofColumns; j++)
            {
                ArrList.Add(arr[i, j]);

            }
            Matrix1.Add(ArrList);



        }

    }
    public void printmatrix()
    {
        for (int i = 0; i < Matrix1.Count; i++)
        {
            for (int j = 0; j < Matrix1[0].Count; j++)
            {
                Debug.Log(Matrix1[i][j]);

            }
        }


    }
    public void Addition()
    {
        Matrix3 = new List<List<int>>();
        for (int i = 0; i < numberofRows; i++)
        {
            ArrList = new List<int>();
            for (int j = 0; j < numberofColumns; j++)
            {
                ArrList.Add(Matrix1[i][j] + Matrix2[i][j]);

            }
            Matrix3.Add(ArrList);
        }
    }
    public void Subtraction()
    {
        Matrix3 = new List<List<int>>();
        for (int i = 0; i < numberofRows; i++)
        {
            ArrList = new List<int>();
            for (int j = 0; j < numberofColumns; j++)
            {
                ArrList.Add(Matrix1[i][j] - Matrix2[i][j]);

            }
            Matrix3.Add(ArrList);
        }
    }
    public void SetElement(int r, int c, int value)
    {
        if (r < numberofRows && c < numberofColumns)
        {
            Matrix1[r][c] = value;

        }

    }
    public int GetElement(int r, int c)
    {
        if (r < numberofRows && c < numberofColumns)
        {
            return Matrix1[r][c];
        }
        else
            return 0;
    }
    public void SetRow(int r, int[] arr)
    {
        List<int> list1 = new List<int>();
        for (int i = 0; i < numberofColumns; i++)
        {
            list1.Add(arr[i]);

        }
        Matrix1.Insert(r, list1);



    }
    public void SetCol(int c, int[] arr)
    {
        List<int> list1 = new List<int>();
        if (c < numberofColumns)
        {
            for (int i = 0; i < numberofRows; i++)
            {
                list1.Add(arr[i]);

            }

        }




    }
    public void SwapRows(int r1, int r2)
    {
        if (r1 < numberofRows && r2 < numberofRows)
        {
            for (int j = 0; j < numberofColumns; j++)
            {
                int temp = Matrix1[r1][j];
                Matrix1[r1][j] = Matrix1[r2][j];
                Matrix1[r2][j] = temp;
            }
        }
        else
        {
            Debug.LogError("ROW SIZE OUT OF BOUND");
        }

    }
    public void Multiplication(Matrix matrix1, Matrix matrix2)
    {
        int sum = 0;
        Matrix3 = new List<List<int>>();

        if (matrix1.Matrix1[0].Count == matrix2.Matrix2.Count)
        {

            for (int i = 0; i < numberofRows; i++)
            {

                for (int j = 0; j < numberofColumns; j++)
                {
                    ArrList = new List<int>();
                    for (int z = 0; z < numberofRows; z++)
                    {
                        sum = sum + matrix1.Matrix1[i][z] * matrix2.Matrix2[z][j];
                    }
                    ArrList.Add(sum);
                    sum = 0;
                    Matrix3.Add(ArrList);
                }

            }
            Debug.Log("fUNCTION Called");
        }
        else
        {
            Debug.LogWarning("ROWS AND COLUMNS are not matched");
        }

    }
    public void SetDiagnols()
    {
        for (int i = 0; i < numberofRows; i++)
        {

            for (int j = 0; j < numberofColumns; j++)
            {
                if (i == j)
                {
                    Matrix1[i][j] = 1;
                }
                else
                {
                    Matrix1[i][j] = 0;
                }



            }

        }
    }
    public void SetInverseDiagnol()
    {
        int col = numberofColumns - 1;
        for (int i = 0; i < numberofRows; i++)
        {
            if (col >= 0)
            {
                Matrix1[i][col] = 1;
                col--;
            }



        }
    }
    void DeterminentMatrix()
    {

    }
    public bool IsRowSame(int rownum)
    {
        bool issame = false;
        if (rownum < numberofRows)
        {

            int a = Matrix1[rownum][0];
            if (a != 0)
            {
                for (int i = 0; i < numberofColumns; i++)
                {
                    if (a == Matrix1[rownum][i])
                    {
                        issame = true;
                    }
                    else
                    {
                        issame = false;
                        break;
                    }
                }
            }


        }

        return issame;


    }
    public bool IsColunmSame(int Colnum)
    {
        bool issame = false;
        if (Colnum < numberofRows)
        {

            int a = Matrix1[0][Colnum];
            if (a != 0)
            {
                for (int i = 0; i < numberofRows; i++)
                {
                    if (a == Matrix1[i][Colnum])
                    {
                        issame = true;
                    }
                    else
                    {
                        issame = false;
                        break;
                    }
                }

            }


        }

        return issame;


    }
    public bool IsDiagnolSame()
    {
        bool issame = false;
        int a = Matrix1[0][0];
        if (a != 0)
        {
            for (int i = 0; i < numberofRows; i++)
            {

                if (a == Matrix1[i][i])
                {
                    issame = true;
                }
                else
                {

                    issame = false;
                    break;
                }
            }
        }

        return issame;


    }
    public int getrow()
    {
        return numberofRows;

    }
    public int getcolumn()
    {
        return numberofColumns;
    }

}
