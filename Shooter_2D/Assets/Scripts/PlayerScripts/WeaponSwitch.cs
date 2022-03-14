using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    public int _weaponScwitch = 0;
    public GameObject[] _bulletCounterText;

    private void Start()
    {
        SelectWeapon();
    }

    private void Update()
    {
        int currentWeapon = _weaponScwitch;
        ScrollWeapon();

        if (currentWeapon != _weaponScwitch)
        {
            SelectWeapon();
        }
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == _weaponScwitch)
            {
                weapon.gameObject.SetActive(true);
                _bulletCounterText[i].SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
                _bulletCounterText[i].SetActive(false);
            }
            i++;
        }
    }

    private void ScrollWeapon()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (_weaponScwitch <= 0)
            {
                _weaponScwitch = transform.childCount - 1;
            }
            else
            {
                _weaponScwitch--;
            }       
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (_weaponScwitch >= transform.childCount - 1)
            {
                _weaponScwitch = 0;
            }
            else
            {
                _weaponScwitch++;
            }
        }
    }
}
