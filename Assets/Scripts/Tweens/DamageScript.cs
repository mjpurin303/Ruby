using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DamageScript : MonoBehaviour
{
    public Image[] enemys;
    public Text[] damages;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        for (int i = 0; i < enemys.Length; i++)
    {
        var enemy = enemys[i];
        // 敵の配置
        enemy.rectTransform.anchoredPosition =
            new Vector2((float)i * 300f - 300f, 0);
        // 敵をシェイク
        enemy.rectTransform.DOShakePosition(0.24f, 30f, 30)
            .SetDelay(0.3f).SetRelative(true);
        // 敵が消える
        enemy.DOFade(0, 0.6f).SetDelay(0.74f);
    }

    yield return new WaitForSeconds(0.2f);

    // ダメージ値と敵表示
    for (int i = 0; i < damages.Length; i++)
    {
        var text = damages[i];
        // ダメージ値の配置
        text.rectTransform.anchoredPosition =
            new Vector2((float)i * 300f - 300f, 0);
        // ダメージ値の初期スケールのセット
        text.rectTransform.localScale = Vector3.one * 5f;

        // スケールトゥイーン
        text.rectTransform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        // ダメージ値のカウントアップトゥイーン
        text.DOCounter(0, Random.Range(100, 9999), 0.3f);
        // 上に移動トゥイーン
        text.rectTransform.DOAnchorPos(new Vector2(0, 60f), 1f)
            .SetDelay(0.4f)
            .SetEase(Ease.InQuart)
            .SetRelative(true);
        // 消えるトゥイーン
        text.DOFade(0, 1f).SetDelay(0.4f).SetEase(Ease.Linear);
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
