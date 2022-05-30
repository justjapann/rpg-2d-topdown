using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

      void Start()
    {
          if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }

        else{
            Load();
        }

        UpdateCharacter(selectedOption);
    }

     private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
         
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    // Update is called once per frame
    void Update()
    {
        // Input
       movement.x =  Input.GetAxisRaw("Horizontal");
       movement.y =  Input.GetAxisRaw("Vertical");

       animator.SetFloat("Horizontal", movement.x);
       animator.SetFloat("Vertical", movement.y);
       animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
