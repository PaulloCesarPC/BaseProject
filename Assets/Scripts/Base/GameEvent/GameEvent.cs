using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    /// <summary>
    /// The list of listeners that this event will notify if it is invoked.
    /// </summary>
    private readonly List<GameEventListener> eventListeners =
        new List<GameEventListener>();

    /// <summary>
    /// The list of listeners that this event will notify if it is invoked.
    /// </summary>
    private readonly List<Action> actions = new List<Action>();

    public void Invoke()
    {
        for (int i = actions.Count - 1; i >= 0; i--)
            actions[i].Invoke();

        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised();
    }

    public void AddListener(GameEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void RemoveListener(GameEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }

    public void AddListener(Action action)
    {
        if (!actions.Contains(action))
            actions.Add(action);
    }

    public void RemoveListener(Action action)
    {
        if (actions.Contains(action))
            actions.Remove(action);
    }
}