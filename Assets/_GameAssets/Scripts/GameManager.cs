using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    private void OnEnable()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
    }

    public void ReloadLevel()
    {
        DOTween.KillAll();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}