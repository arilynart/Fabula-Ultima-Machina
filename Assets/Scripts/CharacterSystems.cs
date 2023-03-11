using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterSystems : MonoBehaviour
{
    public delegate void UpdateHP();
    public event UpdateHP OnUpdateHP;

    private Animator animator;

    private int maxHP;
    public int MaxHP
    {
        get { return maxHP; }
        set
        {
            var previousHP = maxHP;
            maxHP = value;
            if (maxHP != previousHP) ChangeHP();
        }
    }
    private int currentHP;
    public int CurrentHP
    {
        get { return currentHP; }
        set
        {
            var previousHP = currentHP;
            currentHP = value;
            if (currentHP != previousHP) ChangeHP();
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        MaxHP = 20;
        CurrentHP = 20;
    }

    private void OnEnable()
    {
        animator.Play("IdleB");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && name.Substring(0 , 1) != "E") CurrentHP -= 5;
    }

    public void ChangeHP()
    {
        Debug.Log(name + " CurrentHP: " + CurrentHP.ToString() + " / " + MaxHP.ToString());
        OnUpdateHP?.Invoke();
    }
}
