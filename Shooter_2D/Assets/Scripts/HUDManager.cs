using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private Image _heathbarImage;

    public void HealthOfHero(float iHealthPoint, float iMaxHealthPoint)
    {
        _heathbarImage.fillAmount = iHealthPoint / iMaxHealthPoint;
        if(iHealthPoint <= 0)
        {
            //конец игры
        }
    }

    /*public void CountBullets(int iCurrentBulletCounter)
    {
        //потом доделаю
        _bulletCounterText.text = iCurrentBulletCounter.ToString();
    }*/
}
