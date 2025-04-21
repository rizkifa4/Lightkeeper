using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tes;
    [SerializeField] private TextMeshProUGUI _tes2;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _cooldownTimer;
    [SerializeField] private float _cooldownTimer2;
    private bool _isPause;
    private bool _cooldownTimerRunning = true;
    private bool _cooldownTimerRunning2 = true;
    private Coroutine _tesTimerCoroutine;
    public PlayerAnimation PlayerAnim { get; private set; }

    #region States
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerThrowState ThrowState { get; private set; }
    public PlayerBasicAttackState BasicAttackState { get; private set; }
    #endregion

    private void Awake()
    {
        StateMachine = new();
        IdleState = new(this, StateMachine, "Idle");
        MoveState = new(this, StateMachine, "Move");
        DashState = new(this, StateMachine, "Dash");
        JumpState = new(this, StateMachine, "Jump");
        InAirState = new(this, StateMachine, "InAir");
        ThrowState = new(this, StateMachine, "Throw");
        BasicAttackState = new(this, StateMachine, "BasicAttack");
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);

        _cooldownTimer = _cooldown;
        _cooldownTimer2 = _cooldown;

        StartCoroutine(TesTimer2());
    }

    private void Update()
    {
        SetPause();
        if (_isPause) return;

        StateMachine.CurrentState.Update();

        Timer();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void SetPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPause = !_isPause;
        }
    }

    private void Timer()
    {
        if (_cooldownTimerRunning)
        {
            TesTimer(ref _cooldownTimer, _tes);

            if (_cooldownTimer <= 0f)
            {
                _cooldownTimerRunning = false;

                _cooldownTimer = _cooldown;
            }
        }
    }

    private void TesTimer(ref float timer, TextMeshProUGUI cooldownText)
    {
        timer -= Time.deltaTime;
        timer = Mathf.Max(0, timer);

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        cooldownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator TesTimer2()
    {
        while (_cooldownTimerRunning2)
        {
            if (!_isPause)
            {
                TesTimer(ref _cooldownTimer2, _tes2);

                if (_cooldownTimer2 <= 0f)
                {
                    _cooldownTimerRunning2 = false;

                    _cooldownTimer2 = _cooldown;
                }
            }

            yield return null;
        }
    }

    public void ResetTimer()
    {
        if (_cooldownTimerRunning && _cooldownTimerRunning2) return;

        if (_tesTimerCoroutine != null)
        {
            StopCoroutine(_tesTimerCoroutine);
        }

        _cooldownTimerRunning2 = true;
        _cooldownTimerRunning = true;

        _tesTimerCoroutine = StartCoroutine(TesTimer2());
    }
}
