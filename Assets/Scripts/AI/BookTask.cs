using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTask : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public InventoryManager inventoryManager;
    public Section section;

    [SerializeField] SfxManager sfx;
    [SerializeField] AudioClip clip;

    [SerializeField] Color kidsColor;
    [SerializeField] Color horrorColor;
    [SerializeField] Color mysteryColor;
    [SerializeField] Color romanceColor;
    [SerializeField] Color scifiColor;
    [SerializeField] Color adventureColor;
    [SerializeField] Color superHeroColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        inventoryManager = InventoryManager.Instance;
    }
    
    public void SetSection(Section section)
    {
        this.section = section;

        switch (section)
        {
            case Section.KIDS:
                spriteRenderer.color = kidsColor;
                break;
            case Section.HORROR:
                spriteRenderer.color = horrorColor;
                break;
            case Section.MYSTERY:
                spriteRenderer.color = mysteryColor;
                break;
            case Section.ROMANCE:
                spriteRenderer.color = romanceColor;
                break;
            case Section.SCIFI:
                spriteRenderer.color = scifiColor;
                break;
            case Section.ADVENTURE:
                spriteRenderer.color = adventureColor;
                break;
            case Section.SUPERHERO:
                spriteRenderer.color = superHeroColor;
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<PlayerTask>(out PlayerTask playerTask))
        {
            if (inventoryManager.CheckSlots())
            {
                SfxManager sfxObj = Instantiate(sfx.gameObject, transform.position, Quaternion.identity).GetComponent<SfxManager>();
                sfxObj.PlaySound(clip);

                inventoryManager.SetSlot(this, spriteRenderer.color, section);
            }
        }
    }

}
