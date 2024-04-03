using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa,
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj; //Janela do dialogo
    public Image profileSprite; //sprite do perfil
    public Text speechText; //texto da fala
    public Text actorNameText; //nome do npc

    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    //variáveis de controle
    public bool isShowing; //se a janela esta visível - usando na frente da variável [HideInInspector] fará ela ser privada mesmo colocando como public
    private int index; //index das sentenças(falas/textos)
    private string[] sentences;

    public static DialogueControl instance;

    //public bool IsShowing { get => isShowing; set => isShowing = value;  } //fará com que fique publico a variável booleana isShowing

    //awake é chamado antes de todos os starts() na hierarquia de execução  de scripts
    private void Awake()
    {
        instance = this;
    }

    //chamado ao inicializar
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    //pular próxima fase/fala
    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length -1) 
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else //quando terminam os textos 
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }
    //chamar a fala do npc
    public void Speech(string[] txt)
    {
        if (!isShowing) 
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
