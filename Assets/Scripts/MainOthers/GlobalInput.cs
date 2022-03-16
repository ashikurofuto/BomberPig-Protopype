using UnityEngine;
using System;
using Buttons;

[Serializable]
public class States
{
    public InputStates InputState;
public enum InputStates
{
    Stand,
    Up,
    Down,
    Left,
    Right
}
}

public class GlobalInput : MonoBehaviour
{
    [SerializeField] private ButtonInfo UpButton;
    [SerializeField] private ButtonInfo DownButton;
    [SerializeField] private ButtonInfo LeftButton;
    [SerializeField] private ButtonInfo RightButton;
    [SerializeField] private Player Bomber;

    private IMove move;
    private IBomber bomber;
    private States states;

    private void Awake()
    {
        states = new States();
        move = Bomber;
        bomber = Bomber;
    }
    private void Update()
    {
        CheckStates();
        
    }

    private void CheckStates()
    {
        if (UpButton.isPressed)
        {
            states.InputState = States.InputStates.Up;
            move.UpMove();
        }
        else if (DownButton.isPressed)
        {
            states.InputState = States.InputStates.Down;
            move.DownMove();
        }
        else if (LeftButton.isPressed)
        {
            states.InputState = States.InputStates.Left;
            move.LeftMove();
        }
        else if(RightButton.isPressed)
        {
            states.InputState = States.InputStates.Right;
            move.RightMove();
        }
        else
        {
            states.InputState = States.InputStates.Stand;
            move.DontMove();
        }
        
    }

    public void Planted()
    {
        bomber.Plant();
    }
    public void DetonateBomb()
    {
        bomber.Detonate();
    }

  

}



