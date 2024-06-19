using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image slotImage;
    public BookTask bookTask;
    public Section bookSection;
    public bool isEmpty = true;

    public void SetBookTask(BookTask bookTask, Color color, Section section)
    {
        //this.bookTask = bookTask;
        this.bookSection = section;
        slotImage.sprite = bookTask.spriteRenderer.sprite;
        slotImage.color = color;
        isEmpty = false;
        Destroy(bookTask.gameObject, 0.5f);
    }
    public void RemoveBookTaskWithReward()
    {
        RemoveBookTask();
        ScoreManager.Instance.AddScore(ScoreManager.Instance.bookScore);
    }
    public void RemoveBookTask()
    {
        bookSection = Section.NONE;
        slotImage.sprite = null;
        slotImage.color = Color.white;
        isEmpty = true;
        bookTask = null;
    }
}
