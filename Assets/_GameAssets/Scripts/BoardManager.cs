using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DG.Tweening;
using UnityEngine;

public class BoardManager : MonoSingleton<BoardManager>
{
    [SerializeField] private Grid gridButtonPrefab;

    private int matchCount;
    
    private int boardSize;
    private int gridSize;
    
    private Grid[,] grids;


    public void CreateBoard(int boardSize)
    {
        pressedGrids = new List<Grid>();
        ClearBoard();
        this.boardSize = boardSize;
        grids = new Grid[boardSize, boardSize];
        gridSize = Screen.width / boardSize;
        
        CreateGrids();
        SetGridsNeighbours();
    }

    private void SetGridsNeighbours()
    {
        foreach (var grid in grids)
        {
            var i = grid.GridPlacement[0];
            var j = grid.GridPlacement[1];
            
            if(i != 0)
                grid.AddNeighbour(grids[i-1,j]);
            if(i != boardSize-1)
                grid.AddNeighbour(grids[i+1,j]);
            if(j != 0)
                grid.AddNeighbour(grids[i, j-1]);
            if(j != boardSize-1)
                grid.AddNeighbour(grids[i, j+1]);
        }
    }

    private void CreateGrids()
    {
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                Grid grid = Instantiate(gridButtonPrefab);
                grid.transform.SetParent(UIManager.Instance.BoardPanelTransform);
                grid.transform.position = Vector3.zero;
                
                grid.Initialize(i,j, gridSize);
                grids[i, j] = grid;
            }
        }
    }

    private void ClearBoard()
    {
        if (grids == null) return;
        
        if (grids.Length > 0)
        {
            foreach (var grid in grids)
            {
                Destroy(grid.gameObject);
            }
        }

        matchCount = 0;
        UIManager.Instance.UpdateMatchCount(matchCount);
    }

    private List<Grid> pressedGrids;
    
    public void CheckBoardFrom(Grid grid)
    {
        pressedGrids.Clear();
        RecursiveCheck(grid);
        if (pressedGrids.Count >= 3)
        {
            ClearPressedGrids();
        }
        //StartCoroutine(Clear());
    }

    private IEnumerator Clear()
    {
        yield return null;
        
    }

    private void RecursiveCheck(Grid grid)
    {
        if (!pressedGrids.Contains(grid))
        {
            pressedGrids.Add(grid);
            for (int i = 0; i < grid.Neighbors.Count; i++)
            {
                if (grid.Neighbors[i].IsPressed)
                {
                    RecursiveCheck(grid.Neighbors[i]);
                }
            }
        }
    }

    private void ClearPressedGrids()
    {
        foreach (var grid in pressedGrids)
        {
            grid.Clear();
        }
        pressedGrids.Clear();
        
        matchCount++;
        UIManager.Instance.UpdateMatchCount(matchCount);
    }

    public void DropFromList(Grid grid)
    {
        if (pressedGrids.Contains(grid))
        {
            for (int i = 0; i < pressedGrids.Count; i++)
            {
                if (pressedGrids[i] == grid)
                {
                    pressedGrids.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
