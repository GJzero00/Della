using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillImageCD : MonoBehaviour
{
    public Image filledImageQ;  // 对应技能Q的填充图
    public Image filledImageW;  // 对应技能W的填充图

    PlayerAttack playerAttack;

    public float SkillCoolDownQ;
    public float SkillCoolDownW;

    bool isCoolingDownQ = false;
    bool isCoolingDownW = false;

    void Start()
    {
        filledImageQ = GameObject.Find("FillImageQ").GetComponent<Image>();
        filledImageW = GameObject.Find("FillImageW").GetComponent<Image>();
        playerAttack = GameObject.Find("playerattack").GetComponent<PlayerAttack>();

        SkillCoolDownQ = playerAttack.SkillCoolDownQ;
        SkillCoolDownW = playerAttack.SkillCoolDownW;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isCoolingDownQ)
        {
            filledImageQ.fillAmount = 1; 
            StartCoroutine(StartCooldownQ());
        }

        if (Input.GetKeyDown(KeyCode.W) && !isCoolingDownW)
        {
            filledImageW.fillAmount = 1; 
            StartCoroutine(StartCooldownW());
        }
    }

    IEnumerator StartCooldownQ()
    {
        isCoolingDownQ = true;
        float cooldownTime = SkillCoolDownQ;
        float currentTime = 0;

        while (currentTime < cooldownTime)
        {
            currentTime += Time.deltaTime;
            filledImageQ.fillAmount = 1 - (currentTime / cooldownTime); 
            yield return null;
        }

        isCoolingDownQ = false;
    }

    IEnumerator StartCooldownW()
    {
        isCoolingDownW = true;
        float cooldownTime = SkillCoolDownW;
        float currentTime = 0;

        while (currentTime < cooldownTime)
        {
            currentTime += Time.deltaTime;
            filledImageW.fillAmount = 1 - (currentTime / cooldownTime); 
            yield return null;
        }

        isCoolingDownW = false;
    }
}




