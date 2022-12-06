using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private GameObject pressedImage;

    private List<Grid> neighbors;
    public List<Grid> Neighbors => neighbors;

    private bool isPressed;
    public bool IsPressed => isPressed;

    private int[] placement = new int[2];
    public int[] GridPlacement => placement;
    
    public void Initialize(int i, int j, int size)
    {
        SetVisual();
        neighbors = new List<Grid>();
        placement[0] = i;
        placement[1] = j;
        
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
        Vector3 pos = transform.localPosition;
        pos.x = (size / 2) + (i * size);
        pos.y = (size / 2) + (j * size);
        transform.position = pos;
    }

    public void AddNeighbour(Grid neighbor)
    {
        neighbors.Add(neighbor);
    }

    public void OnClick()
    {
        isPressed = !isPressed;
        SetVisual();
        
        if (isPressed)
            BoardManager.Instance.CheckBoardFrom(this);
        else
        {
            BoardManager.Instance.DropFromList(this);
        }
    }

    private void SetVisual()
    {
        pressedImage.SetActive(isPressed);
    }

    public void Clear()
    {
        isPressed = false;
        SetVisual();
    }
}
