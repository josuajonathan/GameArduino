using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    #region singleton
    public static CountDown Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    #endregion singleton

    [SerializeField] private TMP_Text countDown;
    [SerializeField] private int m_Time;
    private int time;
    private int m_Minute, m_Second;
    private bool timerRun;
    private bool timerStop;

    public int Time => m_Time;
    public int Minute => m_Minute;
    public int Second => m_Second;

    private void Start()
    {
        time = m_Time;
        UpdateTimer();
        TextUpdate();
        timerRun = true;
        timerStop = false;
    }

    private void Update()
    {
        if (m_Time >= 0 && timerRun && !timerStop)
        {
            StartCoroutine(TimeLeft());
        }
        else
        if (m_Time < 0)
        {
            // lose
        }
    }

    public void UpdateTimer()
    {
        if (m_Time >= 0 && !timerStop)
        {
            m_Minute = m_Time / 60;
            m_Second = m_Time % 60;
        }
    }

    public void TextUpdate()
    {
        if (m_Minute < 10 && m_Second < 10)
        {
            countDown.text = "Time: 0" + m_Minute + ":0" + m_Second;
        }
        else if (m_Minute < 10 && m_Second >= 10)
        {
            countDown.text = "Time: 0" + m_Minute + ":" + m_Second;
        }
        else if (m_Minute >= 10 && m_Second < 10)
        {
            countDown.text = "Time: 0" + m_Minute + ":0" + m_Second;
        }
    }

    IEnumerator TimeLeft()
    {
        UpdateTimer();
        timerRun = false;
        yield return new WaitForSeconds(1);
        m_Time -= 1;
        TextUpdate();
        timerRun = true;
    }

    public void UseTimer(bool _timerStop)
    {
        this.timerStop = _timerStop;
    }

    public void ResetCountdown()
    {
        m_Time = time;
    }

    public void SetTime(int _time)
    {
        this.m_Time = _time;
    }
}
