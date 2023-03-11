using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    public Image HPBar;
    private CharacterSystems system;

    private void Awake()
    {
        system = GetComponent<CharacterSystems>();
    }

    private void OnEnable()
    {
        system.OnUpdateHP += ChangeHP;
    }

    private void OnDisable()
    {
        system.OnUpdateHP -= ChangeHP;
    }

    public void ChangeHP()
    {
        HPBar.fillAmount = (float)system.CurrentHP / (float)system.MaxHP;
    }
}
