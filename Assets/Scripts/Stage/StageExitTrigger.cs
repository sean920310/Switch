using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageExitTrigger : MonoBehaviour
{
    // Stage Exit Trigger Action
    public delegate void StageExitTriggerAction(Collider2D collision);
    public event StageExitTriggerAction onStageExitTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Stage Exit Trigger Enter");
        onStageExitTrigger?.Invoke(collision);
    }

}
