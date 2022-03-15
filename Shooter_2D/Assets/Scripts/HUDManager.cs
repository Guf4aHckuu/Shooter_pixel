using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private Image _heathbarImage;

    public void HealthOfHero(float fHealthPoint, float fMaxHealthPoint)
    {
        _heathbarImage.fillAmount = fHealthPoint / fMaxHealthPoint;
        if (fHealthPoint <= 0)
        {
            //конец игры
        }
    }
}
