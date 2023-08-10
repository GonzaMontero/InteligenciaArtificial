using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    private List<State> states;
    private int currentStateIndex = 0;

    private void Start()
    {
        states = new List<State>();

        //Add all states to List and run a forEach in order to set the init
    }

    private void Update()
    {
        //Perform the current state
    }
}
