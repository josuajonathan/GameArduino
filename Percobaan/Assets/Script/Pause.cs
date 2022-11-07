using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : HighLightUI
{
    [SerializeField] private Image resumeImage;
    [SerializeField] private Image restartImage;
    [SerializeField] private Image mainMenuImage;

    public void Resume()
    {
        GameUI.Instance.Back();
    }

    public void Restart()
    {
        SoundManager.Instance.PlaySound(SoundType.Button);
        SceneHandler.Instance.LoadCurrentScene();
    }

    public void MainMenu()
    {
        SoundManager.Instance.PlaySound(SoundType.Button);
        SceneHandler.Instance.LoadSceneInIndex(0);
    }

    #region Pointer Highlight
    public void PointerResumeEnter()
    {
        resumeImage.color = HighLightButton(resumeImage);
    }

    public void PointerResumeExit()
    {
        resumeImage.color = UnHighLightButton(resumeImage);
    }

    public void PointerRestartEnter()
    {
        restartImage.color = HighLightButton(restartImage);
    }

    public void PointerRestartExit()
    {
        restartImage.color = UnHighLightButton(restartImage);
    }

    public void PointerMainMenuEnter()
    {
        mainMenuImage.color = HighLightButton(mainMenuImage);
    }

    public void PointerMainMenuExit()
    {
        mainMenuImage.color = UnHighLightButton(mainMenuImage);
    }
    #endregion Pointer Highlight
}
