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

    float timerSpeed = 1.0f;

    bool mounted;

    public void CastBar()
    {
        if (sliderFill.fillAmount >= 1)
        {
            castBar.SetActive(false);
            player.Summon();
        }

        if (Input.GetKeyDown(KeyCode.T) && mounted == false)
        {
            castBar.SetActive(true);
            mounted = true;

        }
        else if (Input.GetKeyDown(KeyCode.T) && mounted == true)
        {
            castBar.SetActive(false);
            mounted = false;
        }

        if (mounted == true)
        {
            sliderFill.fillAmount += Time.deltaTime / timerSpeed;
        }
        else if (mounted == false)
        {
            sliderFill.fillAmount = 0;
        }
    }
}
