using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinUI : HighLightUI
{
    [SerializeField] private Image mainLagiImage;
    [SerializeField] private Image mainMenuImage;
    [SerializeField] private TMP_Text timeLeft;

    private void FixedUpdate()
    {
        TextUpdate();
    }

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

    public void TextUpdate()
    {
        if (CountDown.Instance.Minute < 10 && CountDown.Instance.Second < 10)
        {
            timeLeft.text = "Sisa Waktu : 0" + CountDown.Instance.Minute + ".0" + CountDown.Instance.Second;
        }
        else if (CountDown.Instance.Minute < 10 && CountDown.Instance.Second >= 10)
        {
            timeLeft.text = "Sisa Waktu : 0" + CountDown.Instance.Minute + "." + CountDown.Instance.Second;
        }
        else if (CountDown.Instance.Minute >= 10 && CountDown.Instance.Second < 10)
        {
            timeLeft.text = "Sisa Waktu : 0" + CountDown.Instance.Minute + ".0" + CountDown.Instance.Second;
        }
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
