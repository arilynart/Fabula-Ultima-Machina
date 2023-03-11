using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystems : MonoBehaviour
{

    public bool ally = false;

    public Transform battlePosition;
    private Animator animator;
    private void OnEnable()
    {
        animator = GetComponent<Animator>();

        animator.Play("IdleB");
    }

}
