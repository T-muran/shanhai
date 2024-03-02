using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public Image hpImg;
    public Image hpEffectImg;

    public float maxHp = 100f;
    public float currentHp;
    public float buffTime = 0.5f;

    private Coroutine updateCoroutine;

    public static PlayerHealthController instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentHp = maxHp;
        UpdateHealthBar();
    }

    private void SetHealth(float health)
    {
        currentHp = Mathf.Clamp(health, 0f, maxHp);
        UpdateHealthBar();
        if (currentHp <= 0)
        {
            gameObject.SetActive(false);
            GameController.GetInstance().StateMachine.ChangeState(GameController.GameState.Fail.ToString());
            GameController.GetInstance().UIManager.Push(new EndPanel());
        }
    }

    private void IncreaseHealth(float amount)
    {
        SetHealth(currentHp += amount);
    }

    public void TakeDamage(float damageToTake)
    {
        SetHealth(currentHp -= damageToTake);
    }

    private void UpdateHealthBar()
    {
        hpImg.fillAmount = currentHp / maxHp;

        if (updateCoroutine != null)
        {
            StopCoroutine(updateCoroutine);
        }

        updateCoroutine = StartCoroutine(UpdateHpEffect());
    }

    private IEnumerator UpdateHpEffect()
    {
        float effectLength = hpEffectImg.fillAmount - hpImg.fillAmount;
        float elapsedTime = 0f;

        while(elapsedTime < buffTime && effectLength != 0)
        {
            elapsedTime += Time.deltaTime;
            hpEffectImg.fillAmount = Mathf.Lerp(hpImg.fillAmount + effectLength, hpImg.fillAmount, elapsedTime / buffTime);
            yield return null;
        }

        hpEffectImg.fillAmount = hpImg.fillAmount;
    }
}
