using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTask : MonoBehaviour
{
    public Section section;
    public AITask aITask;
    
    public void RemoveTask()
    {
        section = Section.NONE;
        aITask.flipflop = true;
        aITask.RemoveTaskWithReward();
    }

    public void RemoveAI()
    {
        aITask.flipflop = false;
        aITask.completed = true;
        StartCoroutine(aITask.FadeToDelete());
        aITask = null;
    }

    public void SetTask(Section section, AITask aITask)
    {
        this.section = section;
        this.aITask = aITask;
    }
}
