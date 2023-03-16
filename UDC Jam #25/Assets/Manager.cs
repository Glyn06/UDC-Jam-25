using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager instace;

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;

        }
    }

    [SerializeField] private CanvasGroup panel;
    [SerializeField] private float delay = 1.5f;
    [SerializeField] private TextMeshProUGUI timetext;
    [SerializeField] private TextMeshProUGUI enemycounttext;

    private bool beginfade = false;
    private float timer;

    private int enemiesKilled;
    private int seconds;
    private int minutes;
    private float timedPassed;

    public void SetBeginFade(bool fade)
    {
        beginfade = fade;
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
    }

    public void SetAllText()
    {
        timetext.text = minutes.ToString("00") + ":" + timedPassed.ToString("00");
        enemycounttext.text = enemiesKilled + " enemies";
    }

    private void Update()
    {
        timedPassed += Time.deltaTime;

        if (timedPassed >= 60)
        {
            minutes++;
            timedPassed = 0;
        }

        if (beginfade)
        {
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                panel.alpha += Time.deltaTime / 2;

                if (panel.alpha >= 1)
                {
                    beginfade = false;
                }
            }
        }
    }
}
