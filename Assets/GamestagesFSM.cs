using System;
using UnityEngine;

public class GamestagesFSM : MonoBehaviour
{
    public enum State
    {
        Menu,
        Running,
        Attacking,
        Finish,
        Loose
    }

    private State _currentState = State.Menu;
    public State CurrentState => _currentState;

    #region Singleton

    private static GamestagesFSM _instance;
    public static GamestagesFSM Instance => _instance;


    private void OnEnable()
    {
        if (Instance == null)
        {
            _instance = this;
        }

    }

    private void OnDestroy()
    {
        _instance = null;
    }

    #endregion


    public void Menu()
    {
        switch (CurrentState)
        {
            case State.Finish:
                _currentState = State.Menu;
                break;
            case State.Loose:
                _currentState = State.Menu;
                break;
            
        }
    }

    public void Running()
    {
        switch (CurrentState)
        {
            case State.Menu:
                _currentState = State.Running;
                break;
            case State.Attacking:
                _currentState = State.Running;
                break;
            
        }
    }

    public void Attacking()
    {
        switch (CurrentState)
        {
            
            case State.Running:
                _currentState = State.Attacking;
                break;
        }
    }

    public void Finish()
    {
        switch (CurrentState)
        {
            case State.Running:
                _currentState = State.Finish;
                break;
            
        }
    }
    public void Loose()
    {
        switch (CurrentState)
        {
            case State.Attacking:
                _currentState = State.Loose;
                break;
            case State.Running:
                _currentState = State.Loose;
                break;
            
        }
    }

   
}