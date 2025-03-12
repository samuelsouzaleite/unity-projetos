using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDcontroller : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image fishUIBar;

    [Header("Tools")]
    //[SerializeField] private Image axeui;
    //[SerializeField] private Image shovelui;
    //[SerializeField] private Image bucketui;
    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;
    

    private PlayerItems playerItems;
    private PlayerMove player;

    private void Awake() //Awake sempre é chamado antes do start, é bom usar quando quer evitar bugs
    {
        playerItems = FindAnyObjectByType<PlayerItems>();
        player = playerItems.GetComponent<PlayerMove>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        fishUIBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterUIBar.fillAmount = playerItems.currentWater / playerItems.waterLimit;
        woodUIBar.fillAmount = playerItems.totalWood / playerItems.woodLimit;
        carrotUIBar.fillAmount = playerItems.carrots / playerItems.carrotLimit;
        fishUIBar.fillAmount = playerItems.fishes / playerItems.fishesLimit;

        toolsUI[player.handlingObj].color = selectColor;

        for (int i = 0; i < toolsUI.Count; i++) //as vezes se o jogo for complexo, não é recomendado deixar o for no Update, mas em um método
        {                                       // Exemplo de método comentado no SlotFarm.cs
            if(i == player.handlingObj)
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
