/*
 *  Basically Player Movement Manager... 
 * 
 */

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
        public PlayerStateFactory Factory { get => m_factory; set => m_factory = value; }

        /* Game Component */
        Rigidbody m_rb = null;
        public Rigidbody rb { get => m_rb; }

        /* Input Parameter */
        private bool m_isMovePress = false;
        public bool isMovePress { get => m_isMovePress; }

        private Vector2 m_MoveValue = Vector2.zero;
        public Vector2 MoveValue { get => m_MoveValue; }

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
            m_currentState = Factory.Idle(); // Initial State
            m_currentState.EnterState();

            // variable initialize

        }
        private void Update()
        {
            m_currentState.UpdateState();
        }

        private void FixedUpdate()
        {
            m_currentState.FixedUpdateState();
        }

        public void SwitchState(PlayerBaseState newState)
        {
            m_currentState.ExitState();

            newState.EnterState();

            this.m_currentState = newState;
        }


        public void FacingRight()
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        public void FacingLeft()
        {
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }

        #region Input Callback
        public void OnJump(InputAction.CallbackContext ctx)
        {
            print("OnJump");
            if (ctx.performed)
            {
                m_isJumpPress = true;
                m_isJumpRelease = false;
            }
            if (ctx.canceled)
            {
                m_isJumpPress = false;
                m_isJumpRelease = true;
            }
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            print("OnMove");
            if (ctx.performed)
            {
                m_isMovePress = true;
                m_MoveValue = ctx.ReadValue<Vector2>();
            }
            if (ctx.canceled)
            {
                m_isMovePress = false;
                m_MoveValue = ctx.ReadValue<Vector2>();
            }
        }
        #endregion
    }
}
