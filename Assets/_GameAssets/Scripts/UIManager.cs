using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField, BoxGroup("Panels")] private GameObject boardPanel;
    [SerializeField, BoxGroup("Panels")] private GameObject warningPanel;
    [SerializeField, BoxGroup("Texts")] private TextMeshPro gridSizeText;
    
    public Transform BoardPanelTransform => boardPanel.transform;

    public void OnRebuildButtonClick()
    {
        int boardSize = int.Parse(gridSizeText.text);
        if (boardSize > 0 || boardSize < 15)
        {
            BoardManager.Instance.CreateBoard(boardSize);
        }
        else
        {
            EnableWarningPopUp();
        }
    }

    private void EnableWarningPopUp()
    {
        warningPanel.SetActive(true);
    }

    private void OnCloseButtonClick()
    {
        warningPanel.SetActive(false);
    }
}
