using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log("Attack");
    }
}
