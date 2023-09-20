using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class HandController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference m_ActionReference;
    public InputActionReference actionReference { get => m_ActionReference; set => m_ActionReference = value; }

    Type lastActiveType = null;

    public Animator animatorHandLeft;
   

    void Update()
    {
        if (actionReference != null 
            && actionReference.action != null 
            && actionReference.action.enabled 
            && actionReference.action.controls.Count > 0)
        {

            Type typeToUse = null;

            if (actionReference.action.activeControl != null)
            {
                typeToUse = actionReference.action.activeControl.valueType;
                
            }
            else
            {
                typeToUse = lastActiveType;
                
            }

            if (typeToUse == typeof(bool))
            {
                lastActiveType = typeof(bool);
                bool value = actionReference.action.ReadValue<bool>();
                
                //animatorHandLeft.SetFloat("Close", value);
            }
            else if (typeToUse == typeof(float))
            {
                lastActiveType = typeof(float);
                float value = actionReference.action.ReadValue<float>();
                animatorHandLeft.SetFloat("Close", value);
                
            }
        }
    }
}

