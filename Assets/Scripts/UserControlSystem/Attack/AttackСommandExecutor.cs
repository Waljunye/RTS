using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack—ommandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command) =>
        Debug.Log($"{name} attacked Unit {command.Target}");
}
