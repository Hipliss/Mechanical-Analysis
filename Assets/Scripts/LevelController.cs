using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] Image sliderFill;
    [SerializeField] Text castTimer;
    [SerializeField] GameObject castBar;

    [SerializeField] ybotController player;
    [SerializeField] AudioSource baseBgm;
    [SerializeField] AudioSource tigerBgm;

    float timerSpeed = 1.0f;


    public bool mounted;

    private void Start()
    {
        baseBgm.Play();
        baseBgm.volume = 1;

        tigerBgm.Stop();
        tigerBgm.volume = 0;
    }

    public void CastBar()
    {
        float barCount = 1 - sliderFill.fillAmount;

        if (sliderFill.fillAmount >= 1)
        {
            castBar.SetActive(false);
            player.Summon();
            baseBgm.Stop();
        }
        else if (sliderFill.fillAmount < 1)
        {
            player.Desummon();
        }

        if (Input.GetKeyDown(KeyCode.T) && mounted == false)
        {
            castBar.SetActive(true);
            mounted = true;
            tigerBgm.Play();
        }
        else if (Input.GetKeyDown(KeyCode.T) && mounted == true)
        {
            castBar.SetActive(false);
            mounted = false;
            baseBgm.Play();
        }

        if (mounted == true)
        {
            sliderFill.fillAmount += Time.deltaTime / timerSpeed;
            castTimer.text = "0" + barCount.ToString("F2");
            baseBgm.volume -= Time.deltaTime / timerSpeed;
            tigerBgm.volume += Time.deltaTime / timerSpeed;
        }
        else if (mounted == false)
        {
            sliderFill.fillAmount = 0;
            tigerBgm.volume -= Time.deltaTime / timerSpeed;
            baseBgm.volume += Time.deltaTime / timerSpeed;
        }
    }
}
