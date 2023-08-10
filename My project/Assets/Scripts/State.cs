using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class State
{
    public GameObject target;

    public virtual void Init(GameObject target)
    {
        this.target = target;
    }

    public abstract void OnEnter();

    public abstract void OnExit();

    public abstract void Perform();
}