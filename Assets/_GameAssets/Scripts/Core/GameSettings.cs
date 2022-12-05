using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Core/GameSettings", order = 2)]
public class GameSettings : ScriptableObject
{
    [BoxGroup("Board")] public int MinBoardSize;
    [BoxGroup("Board")] public int MaxBoardSize;
}