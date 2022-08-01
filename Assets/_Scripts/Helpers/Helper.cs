using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public static class Helper
{
    public static void PlayScaleUpDownAnim(this Transform transform, float scaleMultiplier, float duration, Ease inEase = Ease.Linear, Ease outEase = Ease.OutSine)
    {
        Vector3 defScale = transform.localScale;
        Vector3 targetScale = defScale * scaleMultiplier;

        transform.DOScale(targetScale, duration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                transform.DOScale(defScale, duration)
                    .SetEase(Ease.OutSine);
            });
    }

    public static void PlayScaleUpDownAnim(this Transform transform, Vector3 defaultScale, float scaleMultiplier, float duration,
        Ease inEase = Ease.Linear, Ease outEase = Ease.OutSine)
    {
        transform.DOKill();
        transform.localScale = defaultScale;
        
        Vector3 targetScale = defaultScale * scaleMultiplier;

        transform.DOScale(targetScale, duration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                transform.DOScale(defaultScale, duration)
                    .SetEase(Ease.OutSine);
            });
    }
}
