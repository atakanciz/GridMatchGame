using UnityEngine;

public class BoardManager : MonoSingleton<BoardManager>
{
    [SerializeField] private Grid gridButtonPrefab;
    
    private int boardSize;
    private int gridSize;
    
    private Grid[,] grids;


    public void CreateBoard(int boardSize)
    {
        ClearBoard();
        this.boardSize = boardSize;

        grids = new Grid[boardSize, boardSize];
        gridSize = Screen.width / boardSize;
        
        CreateGrids();
        SetGridsNeighbours();
    }

    private void SetGridsNeighbours()
    {
        //will set the neighbors here
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
        if (grids.Length > 0)
        {
            foreach (var grid in grids)
            {
                Destroy(grid);
            }
        }
    }
}
