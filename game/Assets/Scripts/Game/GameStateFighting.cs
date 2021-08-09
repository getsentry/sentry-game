using System.Collections.Generic;
using UnityEngine;

public class GameStateFighting : GameState
{
    private readonly BugSpawner _bugSpawner;

    private GameData _data;
    
    public GameStateFighting(GameStateMachine stateMachine) : base(stateMachine)
    {
        _data = GameData.Instance;
        _bugSpawner = BugSpawner.Instance;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        
        for (int i = 0; i < 5; i++)
        {
            var bug = _bugSpawner.Spawn();
            _data.bugs.Add(bug);
        }
    }

    public override void Tick()
    {
        base.Tick();

        if (_data.bugs.Count <= 0)
        {
            StateTransition(GameStates.Upgrading);
            return;
        }
    }
}
