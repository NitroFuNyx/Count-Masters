using System;
using System.Collections;
using UnityEngine;

public class GamestagesFSM : MonoBehaviour
{
    public enum State
    {
        Menu,
        Running,
        Attacking,
        Finish,
        Loose,
        CreatingTower,
        MovingForward
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

   

    #endregion

    public event Action RunningChanged;
    public event Action FinishedChanged;
    public event Action LooseChanged;
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
            case State.MovingForward:
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
            case State.Finish:
                _currentState = State.Running;
                break;
            
        }

        OnRunningChanged();
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
            case State.MovingForward:
                _currentState = State.Finish;
                break;
            
        }
        FinishedChanged?.Invoke();

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

        OnLooseChanged();
    }
    public void MovingForward()
    {
        switch (CurrentState)
        {
            case State.CreatingTower:
                _currentState = State.MovingForward;
                break;
            case State.Running:
                _currentState = State.MovingForward;
                break;
            
        }
    }
    public void CreatingTower()
    {
        switch (CurrentState)
        {
            case State.Running:
                _currentState = State.CreatingTower;
                break;
            
            
        }
    }

    protected virtual void OnRunningChanged()
    {
        RunningChanged?.Invoke();
    }

    protected virtual void OnFinishedChanged()
    {
        FinishedChanged?.Invoke();
    }

    protected virtual void OnLooseChanged()
    {
        LooseChanged?.Invoke();
    }
}