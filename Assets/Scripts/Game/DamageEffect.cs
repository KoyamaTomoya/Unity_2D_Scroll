using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    private const float APLHA_THRESHOLD = 0.5f;
    private const float DAMAGE_EFFECT_SPEED = 6.0f;

    [SerializeField]
    private Image screenEffectObj;

    [SerializeField]
    private PlayerManager pm;

    // 画面エフェクトのアルファ値
    private float effect_alpha;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.GetDamageFlag() && effect_alpha <= APLHA_THRESHOLD)
        {
            effect_alpha += (Time.deltaTime * DAMAGE_EFFECT_SPEED);
        }
        else
        { 
            effect_alpha = 0;
            pm.SetDamageFlag(false);
        }


        // エフェクト処理
        screenEffectObj.color = new Color(255, 0, 0, effect_alpha);
    }
}
