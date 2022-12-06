using System;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField, BoxGroup("Panels")] private GameObject boardPanel;
    [SerializeField, BoxGroup("Panels")] private GameObject warningPanel;
    [SerializeField, BoxGroup("Texts")] private Text gridSizeText;
    [SerializeField, BoxGroup("Texts")] private TextMeshProUGUI matchCountText;

    public Transform BoardPanelTransform => boardPanel.transform;

    private GameSettings settings => SettingsManager.GameSettings;
    private int minBoardSize => settings.MinBoardSize;
    private int maxBoardSize => settings.MaxBoardSize;
    
    public void OnRebuildButtonClick()
    {
        int boardSize = 0;
        Int32.TryParse(gridSizeText.text, out boardSize);
        
        if (boardSize > minBoardSize || boardSize < maxBoardSize)
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

    public void UpdateMatchCount(int i)
    {
        matchCountText.text = $"Match Count : {i}";
    }

}
