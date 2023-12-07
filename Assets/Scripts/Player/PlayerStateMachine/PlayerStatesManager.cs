/*
 *  Basically Player Movement Manager... 
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerStateMachine
{
    public class PlayerStatesManager : MonoBehaviour
    {
        PlayerBaseState m_currentState = null;

        PlayerStateFactory m_factory = null;
        public PlayerStateFactory factory { get => m_factory; set => m_factory = value; }

        /* Game Component */
        Rigidbody2D m_rb = null;
        public Rigidbody2D rb { get => m_rb; }

        Animator m_animator = null;
        public Animator Animator { get => m_animator; }


        /* Local Variable */

        [Header("Move")]
        [SerializeField] private float m_playerMaxSpeedX = 10f;
        public float playerMaxSpeedX { get => m_playerMaxSpeedX; }

        [SerializeField] private float m_playerMoveSpeedX = 100f;
        public float playerMoveSpeedX { get => m_playerMoveSpeedX; }

        [SerializeField] private float m_playerAirMaxSpeedX = 5f;
        public float playerAirMaxSpeedX { get => m_playerAirMaxSpeedX; }

        [SerializeField] private float m_playerAirMoveSpeedX = 10f;
        public float playerAirMoveSpeedX { get => m_playerAirMoveSpeedX; }

        [Header("Jump")]
        public bool desireToJump = false;

        [SerializeField] private float m_maxJumpHeight = 1.5f;
        public float maxJumpHeight { get => m_maxJumpHeight; }

        [SerializeField] public float maxJumpTime = 1.0f;

        [SerializeField] public float jumpTimeCounter = 0;

        [SerializeField] private float m_jumpCancelRate = 15.0f;
        public float jumpCancelRate { get => m_jumpCancelRate; }

        [SerializeField] private int m_maxJumpCount = 2;
        public int maxJumpCount { get => m_maxJumpCount; }

        [SerializeField] public int jumpCounts = 0;

        private CameraManager.Dimension m_dimension;
        public CameraManager.Dimension dimension { get => m_dimension; }

        public bool isDimensionSwitch = false;

        private bool m_canAttack = false;
        public bool canAttack { get => m_canAttack; set => m_canAttack = value; }

        [Header("Jump Detect")]
        [SerializeField] Vector2 m_groundCheckBoxShift;
        [SerializeField] Vector2 m_groundCheckBoxSize;
        [SerializeField] LayerMask m_whatIsGround;

        [Header("Effect")]
        [SerializeField]
        private Color m_hurtColor;
        public Color HurtColor { get => m_hurtColor; }
        [SerializeField]
        private Material m_material;
        public Material Material { get => m_material; }

        [Header("Sound")]
        [SerializeField]
        private AudioSource m_footStepSound;
        public AudioSource FootStepSound { get => m_footStepSound; }

        [SerializeField]
        private AudioSource m_fallSound;
        public AudioSource FallSound { get => m_fallSound; }

        [SerializeField]
        private AudioSource m_swingSound;
        public AudioSource SwingSound { get => m_swingSound; }

        [SerializeField]
        private AudioSource m_smiteSound;
        public AudioSource SmiteSound { get => m_smiteSound; }

        [SerializeField]
        private AudioSource m_jumpSound;
        public AudioSource JumpSound { get => m_jumpSound; }

        [SerializeField]
        private AudioSource m_hurtSound;
        public AudioSource HurtSound { get => m_hurtSound; }

        [Header("Status")]
        [SerializeField] [ReadOnly]
        private String m_currentStateString;
        [SerializeField] [ReadOnly]
        private bool m_onGround;

        /* Input Parameter */
        private bool m_isMovePress = false;
        public bool isMovePress { get => m_isMovePress; }

        private Vector2 m_moveValue = Vector2.zero;
        public Vector2 moveValue { get => m_moveValue; }

        private bool m_isJumpPress = false;
        public bool isJumpPress { get => m_isJumpPress; }

        private bool m_isJumpRelease = false;
        public bool isJumpRelease { get => m_isJumpRelease; }

        private bool m_isAttackPress = false;
        public bool isAttackPress { get => m_isAttackPress; set => m_isAttackPress = value; }

        private bool m_isAppQuiting = false;

        private void Start()
        {
            // get game component
            m_rb = GetComponent<Rigidbody2D>();
            m_animator = GetComponentInChildren<Animator>();

            // state setup
            m_factory = new PlayerStateFactory(this);
            m_currentState = factory.Idle(); // Initial State
            m_currentState.EnterState();

            // variable initialize
            jumpCounts = m_maxJumpCount;

            //effect initialize
            m_material.SetColor("_TintColor", Color.clear);

        }
        private void Update()
        {
            m_currentState.UpdateState();
            m_onGround = CheckOnFloor();
        }

        private void FixedUpdate()
        {
            m_currentState.FixedUpdateState();
        }

        private void OnEnable()
        {
            CameraManager.Instance.OnSwitchCallback += OnSwitch;
        }

        private void OnApplicationQuit()
        {
            m_isAppQuiting = true;
        }

        private void OnDisable()
        {
            if (!m_isAppQuiting)
                CameraManager.Instance.OnSwitchCallback -= OnSwitch;
        }

        public void SwitchState(PlayerBaseState newState)
        {
            m_currentState.ExitState();

            newState.EnterState();

            this.m_currentState = newState;
            this.m_currentStateString = m_currentState.ToString();
        }

        /* 
         * force: -moveValue * m_playerMoveSpeedX 
         * limit: m_playerMaxSpeedX
         */
        internal void MoveWithLimit(Vector2 force, float limit)
        {
            rb.AddForce(new Vector2(force.x, 0f), ForceMode2D.Force);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -limit, limit), rb.velocity.y);
        }

        /* 
         * force: -moveValue * m_playerMoveSpeed
         * limit: m_playerMaxSpeed
         */
        internal void MoveWithLimit3D(Vector2 force, float limit)
        {
            rb.AddForce(force, ForceMode2D.Force);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -limit, limit),
                                        Mathf.Clamp(rb.velocity.y, -limit, limit));
        }

        public bool CheckOnFloor()
        {
            bool onGround = Physics2D.OverlapBox((Vector2)transform.position + m_groundCheckBoxShift, m_groundCheckBoxSize, 0, m_whatIsGround) != null;

            return onGround;
        }

        public bool CanJump()
        {
            return CheckOnFloor() || (jumpCounts > 0);
        }

        public void FacingRight()
        {
            //transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            transform.localScale = Vector3.one;
        }
        public void FacingLeft()
        {
            //transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        public void HurtState()
        {
            SwitchState(m_factory.Hurt());
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
            Gizmos.DrawCube(transform.position + new Vector3(m_groundCheckBoxShift.x, m_groundCheckBoxShift.y, 0.0f), m_groundCheckBoxSize);
        }


        #region Input Callback

        public void OnSwitch(CameraManager.Dimension dimension)
        {
            isDimensionSwitch = true;
            m_dimension = dimension;
        }

        public void OnJump(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                m_isJumpPress = true;
                m_isJumpRelease = false;

                desireToJump = true;
            }
            if (ctx.canceled)
            {
                m_isJumpPress = false;
                m_isJumpRelease = true;

                desireToJump = false;
            }
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                m_isMovePress = true;
                m_moveValue = ctx.ReadValue<Vector2>();
            }
            if (ctx.canceled)
            {
                m_isMovePress = false;
                m_moveValue = ctx.ReadValue<Vector2>();
            }
        }

        public void OnAttack(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                m_isAttackPress = true;
            }
            if (ctx.canceled)
            {
                m_isAttackPress = false;
            }
        }
        #endregion
    }
}
