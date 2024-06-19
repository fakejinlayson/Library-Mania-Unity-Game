using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Section
{
    KIDS,
    HORROR,
    MYSTERY,
    ROMANCE,
    SCIFI,
    ADVENTURE,
    SUPERHERO,
    NONE
}


public class ColliderSection : MonoBehaviour
{
    [SerializeField] PlayerTask player;
    [SerializeField] Section section;

    private bool isTriggering = false;

    [SerializeField] SfxManager sfx;
    [SerializeField] AudioClip clip;

    [SerializeField] List<ParticleSystem> particles = new List<ParticleSystem>();

    void Update()
    {
        if (isTriggering == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Slot slot = InventoryManager.Instance.ReturnSlotAtIndex(0);
                if (slot.bookSection == section)
                {
                    slot.bookSection = Section.NONE;
                    InventoryManager.Instance.RemoveSlotAtIndex(0);
                    PlayParticles();
                    SfxManager sfxObj = Instantiate(sfx.gameObject, transform.position, Quaternion.identity).GetComponent<SfxManager>();
                    sfxObj.PlaySound(clip);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Slot slot = InventoryManager.Instance.ReturnSlotAtIndex(1);
                if (slot.bookSection == section)
                {
                    slot.bookSection = Section.NONE;
                    InventoryManager.Instance.RemoveSlotAtIndex(1);
                    PlayParticles();
                    SfxManager sfxObj = Instantiate(sfx.gameObject, transform.position, Quaternion.identity).GetComponent<SfxManager>();
                    sfxObj.PlaySound(clip);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Slot slot = InventoryManager.Instance.ReturnSlotAtIndex(2);
                if (slot.bookSection == section)
                {
                    slot.bookSection = Section.NONE;
                    InventoryManager.Instance.RemoveSlotAtIndex(2);
                    PlayParticles();
                    SfxManager sfxObj = Instantiate(sfx.gameObject, transform.position, Quaternion.identity).GetComponent<SfxManager>();
                    sfxObj.PlaySound(clip);
                }
            }
        }
    }

    public void PlayParticles()
    {
        foreach (ParticleSystem particle in particles)
        {
            particle.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player.gameObject)
        {
            isTriggering = true;
            if (player.section == this.section)
            {
                player.RemoveTask();
                PlayParticles();
                SfxManager sfxObj = Instantiate(sfx.gameObject, transform.position, Quaternion.identity).GetComponent<SfxManager>();
                sfxObj.PlaySound(clip);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player.gameObject)
        {
            isTriggering = false;
        }
    }
}
