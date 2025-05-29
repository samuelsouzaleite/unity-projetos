using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;

public class SlotFarm : MonoBehaviour
{
    [Header("Áudio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip holeSFX;
    [SerializeField] private AudioClip carrotSFX;

    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]
    [SerializeField] private int digAmount; //quantidade de "escavação"
    [SerializeField] private float waterAmount; //total de agua para nascer uma cenoura
    
    [SerializeField] private bool detecting;
    private bool isPlayer; //fica verdadeiro quando o player está encostando

    private int initialDigAmount;
    private float currentWater;

    private bool dugHole;   
    private bool PlantedCarrot;   

    PlayerItems playerItems;

    private void Start()
    {
        playerItems = FindAnyObjectByType<PlayerItems>();
        initialDigAmount = digAmount;
    }

    private void Update()
    {

        if(dugHole) //enquanto for verdade...
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }

            //encheu o total de agua necessario
            if (currentWater >= waterAmount && !PlantedCarrot)
            {
                audioSource.PlayOneShot(holeSFX);
                spriteRender.sprite = carrot;

                PlantedCarrot = true; 
            }

            if (Input.GetKeyDown(KeyCode.E) && PlantedCarrot && isPlayer)
            {
                audioSource.PlayOneShot(carrotSFX);
                spriteRender.sprite = hole;
                playerItems.carrots++;
                currentWater = 0f;
            }
        }
        
    }

    public void OnHit() //isso é um método
    {
        digAmount--;

        if (digAmount <= initialDigAmount / 2)
        {
           spriteRender.sprite = hole;
            dugHole = true;
        }

        //if (digAmount <= 0)
        //{
        //    spriteRender.sprite = carrot;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dig"))
        {
            OnHit();
        }

        if(collision.CompareTag("Water"))
        {
            detecting = true;
        }

        if (collision.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            detecting = false;
        }

        if (collision.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }

}

