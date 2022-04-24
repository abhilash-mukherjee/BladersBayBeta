using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_SD_Animate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject  versus,  timerImage;
    [SerializeField] private Image lowerPart, upperPart;
    [SerializeField] private Text timerText;
    [SerializeField] private float versusGoneTime = 1f;
    int timer = 3;
    private float timeElapsed = 0, rate = 0;

    public void StartAnimationAfterEventRecieved(float _time)
    {
        StartCoroutine(CallBattleAnimationFunction(_time));
    }
    IEnumerator CallBattleAnimationFunction(float _time)
    {
        yield return new WaitForSeconds(_time);
        StartBattleAnimation();
    }
    private void StartBattleAnimation()
    {

        StartCoroutine(TimerUpdateText());
        StartCoroutine(TimerUpdateSliderDesign());
    }

    IEnumerator TimerUpdateSliderDesign()
    {
        while (timer > 0)
        {
            lowerPart.fillAmount = Mathf.Lerp(0, 0.5f, timeElapsed / 3);
            upperPart.fillAmount = Mathf.Lerp(0, 0.5f, timeElapsed / 3);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }



    IEnumerator TimerUpdateText()
    {
        timerImage.SetActive(true);
        while (timer > 0)
        {
            timerText.text = timer.ToString();
            yield return new WaitForSeconds(1f);
            timer--;
        }
        timerImage.SetActive(false);
        versus.SetActive(true);
        yield return new WaitForSeconds(2f);
        // versus.gameObject.SetActive(false);

    }

    void Update()
    {
        if (versus.activeSelf)
        {
            versus.transform.localScale = Vector3.Lerp(new Vector3(2f, 2f, 2f), new Vector3(0.3604286f, 0.3604286f, 0.3604286f), rate*4f);
            rate += Time.deltaTime;
        }
    }

}
