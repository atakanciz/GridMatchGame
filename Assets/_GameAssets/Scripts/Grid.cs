using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private GameObject pressedImage;

    private List<Grid> neighbours;

    private bool isPressed;

    private int[] placement;
    public int[] GridPlacement => placement;
    
    public void Initialize(int i, int j, int size)
    {
        SetVisual();
        neighbours = new List<Grid>();
        placement[0] = i;
        placement[1] = j;
        
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
        Vector3 pos = transform.position;
        pos.x = (size / 2) + (i * size);
        pos.y = (size / 2) + (j * size);
        transform.position = pos;
    }

    public void AddNeighbour(Grid neighbor)
    {
        neighbours.Add(neighbor);
    }

    public void OnClick()
    {
        isPressed = !isPressed;
        SetVisual();
    }

    private void SetVisual()
    {
        pressedImage.SetActive(isPressed);
    }
}
