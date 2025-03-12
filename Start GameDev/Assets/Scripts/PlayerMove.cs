using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //public float speed;
    //public float runSpeed;

    public bool isPaused;

    [SerializeField] private float speed; //usando o SerializeField faz com que também fique público a variável na unity
    [SerializeField] private float runSpeed;

    private PlayerItems PlayerItems;
    private Rigidbody2D rig;

    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;

    private Vector2 _direction;

    [HideInInspector] public int handlingObj; //O HideInInspector faz com que a variavel public não apareca na unity

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }
    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public bool isDigging
    {
        get { return _isDigging; }
        set { _isDigging = value; }
    }

    public bool isWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
        PlayerItems = GetComponent<PlayerItems>();
    }
    private void Update()
    {
        if(!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                handlingObj = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                handlingObj = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                handlingObj = 2;
            }

            OnInput();
            OnRun();
            OnRoll();
            OnCutting();
            OnDig();
            OnWatering();
        }
    }

       

    private void FixedUpdate()
    {
        if(!isPaused)
        {
            OnMove();
        }
        
    }

    #region Movement

    void OnWatering()
    {
        if (handlingObj == 2)
        {
            if (Input.GetMouseButtonDown(0) && PlayerItems.currentWater > 0) //&& = E (e tambem) quando quero adicionar outra condição pra ser feita junto com outra
            {
                
                isWatering = true;
                speed = 0;
            }
            if (Input.GetMouseButtonUp(0) || PlayerItems.currentWater < 0) // || = OU (Ou isso ou aquilo) quando é para ser outra opção quando não atingir a outra condição
            {
                isWatering = false;
                speed = initialSpeed;
            }

            if(isWatering) //enquanto for true
            {
                PlayerItems.currentWater -= 0.01f;
            }

        }
    }

    void OnDig()
    {
        if (handlingObj == 1) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDigging = true;
                speed = 0;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDigging = false;
                speed = initialSpeed;
            }

        }
    }

    void OnCutting()
    {
        if (handlingObj == 0) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                isCutting = true;
                speed = 0;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isCutting = false;
                speed = initialSpeed;
            }
        }
    }


    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRoll()
    {
        if (Input.GetMouseButtonDown(1))
        {
            speed = runSpeed;
            _isRolling = true;
        }
        
        if(Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
        }
    }
    #endregion
}