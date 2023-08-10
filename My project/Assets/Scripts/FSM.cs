using System;
using System.Collections;
using System.Collections.Generic;

public class FSM
{
    public int currentStateIndex = 0;

    Dictionary<int, State> behaviours;

    private int[/*Estado Origen*/, /*Condición*/] /* = Estado Destino*/ relations;

    public FSM(int states, int flags)
    {
        currentStateIndex = -1;

        relations = new int[states, flags];

        for(int i = 0; i < states; i++)
        {
            for(int j = 0; j < flags; j++)
            {
                relations[i, j] = -1;
            }
        }

        behaviours = new Dictionary<int, State>();
    }

    public void SetRelation(int sourceState, int flag, int destinationState)
    {
        relations[sourceState, flag] = destinationState;
    }

    public void SetFlag(int flag)
    {
        if (relations[currentStateIndex, flag] != -1)
            currentStateIndex = relations[currentStateIndex, flag];
    }

    public void AddBehaviour(int state, Action behaviour)
    {
        if (behaviours.ContainsKey(state))
        {
            behaviours[state].behaviors.Add(behaviour);
        }
        else
        {
            State newState = new State();
            newState.behaviors = new List<Action>();
            newState.behaviors.Add(behaviour);
            behaviours.Add(state, newState);
        }
    }

    public void Update()
    {
        if (behaviours.ContainsKey(currentStateIndex))
        {
            foreach (Action behaviour in behaviours[currentStateIndex].behaviors)
            {
                behaviour?.Invoke();
            }
        }
    }
}
