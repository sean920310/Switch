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
        Rigidbody m_rb = null;
        public Rigidbody rb { get => m_rb; }


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

        [Header("Jump Detect")]
        [SerializeField] Vector2 m_groundCheckBoxShift;
        [SerializeField] Vector2 m_groundCheckBoxSize;
        [SerializeField] LayerMask m_whatIsGround;

        /* Input Parameter */
        private bool m_isMovePress = false;
        public bool isMovePress { get => m_isMovePress; }

        private Vector2 m_moveValue = Vector2.zero;
        public Vector2 moveValue { get => m_moveValue; }

        private bool m_isJumpPress = false;
        public bool isJumpPress { get => m_isJumpPress; }

        private bool m_isJumpRelease = false;
        public bool isJumpRelease { get => m_isJumpRelease; }

        private void Start()
        {
            // get game component
            m_rb = GetComponent<Rigidbody>();

            // state setup
            m_factory = new PlayerStateFactory(this);
            m_currentState = factory.Idle(); // Initial State
            m_currentState.EnterState();

            // variable initialize
            jumpCounts = m_maxJumpCount;



        }
        private void Update()
        {
            m_currentState.UpdateState();
        }

        private void FixedUpdate()
        {
            m_currentState.FixedUpdateState();
        }

        private void OnEnable()
        {
            CameraManager.Instance.OnSwitchCallback += OnSwitch;
        }

        private void OnDisable()
        {
            CameraManager.Instance.OnSwitchCallback -= OnSwitch;
        }

        public void SwitchState(PlayerBaseState newState)
        {
            m_currentState.ExitState();

            newState.EnterState();

            this.m_currentState = newState;
        }

        /* 
         * force: -moveValue * m_playerMoveSpeedX 
         * limit: m_playerMaxSpeedX
         */
        internal void MoveWithLimit(Vector2 force, float limit)
        {
            rb.AddForce(new Vector3(force.x, 0f, 0f), ForceMode.Force);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -limit, limit), rb.velocity.y);
        }

        /* 
         * force: -moveValue * m_playerMoveSpeed
         * limit: m_playerMaxSpeed
         */
        internal void MoveWithLimit3D(Vector2 force, float limit)
        {
            rb.AddForce(force, ForceMode.Force);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -limit, limit),
                                        Mathf.Clamp(rb.velocity.y, -limit, limit));
        }

        public bool CheckOnFloor()
        {
            Quaternion quaternion = Quaternion.identity;
            return Physics.OverlapBox(transform.position + new Vector3(m_groundCheckBoxShift.x, m_groundCheckBoxShift.y, transform.position.z), m_groundCheckBoxSize, quaternion, m_whatIsGround).Length > 0;
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
            transform.localScale = new Vector3(-1f,1f,1f);
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
                Debug.Log(m_moveValue);

            }
            if (ctx.canceled)
            {
                m_isMovePress = false;
                m_moveValue = ctx.ReadValue<Vector2>();
            }
        }
        #endregion
    }
}
