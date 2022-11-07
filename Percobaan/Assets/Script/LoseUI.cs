using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseUI : HighLightUI
{
    [SerializeField] private Image mainLagiImage;
    [SerializeField] private Image mainMenuImage;

    public void MainLagi()
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
    public void PointerMainLagiEnter()
    {
        mainLagiImage.color = HighLightButton(mainLagiImage);
    }

    public void PointerMainLagiExit()
    {
        mainLagiImage.color = UnHighLightButton(mainLagiImage);
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
