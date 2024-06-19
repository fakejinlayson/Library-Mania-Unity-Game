using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AITask : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    private SpriteRenderer thisSpriteRenderer;
    [SerializeField] Section section;
    [SerializeField] List <Sprite> spriteList;
    public bool flipflop = false;
    public bool completed = false;
    
    [SerializeField] SfxManager sfx;
    [SerializeField] AudioClip clip;

    public void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        
        // make random section
        section = (Section)Random.Range(0, (int)Section.NONE - 1);

        // set image to section
        spriteRenderer.sprite = spriteList[(int)section];

    }


    public IEnumerator FadeToDelete()
    {
        Color.Lerp(thisSpriteRenderer.color, Color.clear, 3);

        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }
    public void RemoveTaskWithReward()
    {
        ScoreManager.Instance.AddScore(ScoreManager.Instance.aiScore);
        RemoveTask();
    }

    public void RemoveTask()
    {
        spriteRenderer.sprite = null;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<PlayerTask>(out PlayerTask playerTask))
        {
            if (completed == true || flipflop == true)
            {
                return;
            }

            SfxManager sfxObj = Instantiate(sfx.gameObject, transform.position, Quaternion.identity).GetComponent<SfxManager>();
            sfxObj.PlaySound(clip, 0.3f);

            playerTask.SetTask(section, this);
        }
    }

    public void HandleFollowMovement(Vector3 targetPosition)
    {   
        gameObject.transform.position = (Vector3)targetPosition;
    }
}