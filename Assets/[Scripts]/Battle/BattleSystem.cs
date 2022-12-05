using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy, BattleOver, RunningTurn}
public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    BattleDialogBox dialogBox;

    public event Action<bool> OnBattleOver;
    
    BattleState state;
    int currentAction;

    // Start is called before the first frame update
    public void StartBattle()
    {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        dialogBox.EnableActionSelector(false);
        yield return dialogBox.TypeDialog("An enemy has appeared!");
        yield return new WaitForSeconds(1f);

        PlayerActions();
    }

    void PlayerActions()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose and action"));
        dialogBox.EnableActionSelector(true);
    }
    // Update is called once per frame
    public void HandleUpdate()
    {
        if(state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
    }

    void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
            {
                ++currentAction;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
            {
                --currentAction;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(currentAction == 1)
            {
                // Run
                StartCoroutine(TryToEscape());
            }
        }

        dialogBox.UpdateActionSelection(currentAction);
    }

    IEnumerator TryToEscape()
    {
        state = BattleState.Busy;

        yield return dialogBox.TypeDialog("Ran away safely!");

        OnBattleOver(true);
    }
}
