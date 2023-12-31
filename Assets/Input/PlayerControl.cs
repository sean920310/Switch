//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/PlayerControl.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControl: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""PlayerNormal"",
            ""id"": ""e849bd46-b203-4198-a87d-c92783f5a31f"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""97dd282d-9c97-4ce0-b5d0-ab74fb2cb456"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""1dcdd6ce-80d1-418e-82c4-d3309368eeb4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""87562f64-0863-4fb0-b3ee-25b51a8225a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""ae62e8d7-0e93-4e57-a998-4145259fc612"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""JumpDown"",
                    ""type"": ""Button"",
                    ""id"": ""a22faadb-1b42-4fa8-9688-61a4bd6da56f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Blocking"",
                    ""type"": ""Button"",
                    ""id"": ""1d5eddfe-5f2c-42a0-b72e-c909dda7b622"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e1b9398b-f9f9-478b-bdc5-1cba38af95c8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""42303009-e6ab-4ef1-84a7-5e91f7e29abe"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""2165854b-ce7f-458b-ad40-bffe28c01e43"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""c5845315-dd32-42df-94a1-f7b34f0704d3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""5933d793-48a2-4695-ab8e-96c4b57a2b0a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""b4deb136-e7b6-4d71-8fe7-e9e7bba61b13"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""984d1f5e-f531-443a-9349-075f57b9616c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0dcaaf13-7da1-4d08-ab02-ce5b4a650b41"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d14dc67-9e0f-407e-b01b-c6882ca33c0f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6589b2a0-3dc5-4a25-b248-98cf2154ed5d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Blocking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerRebinding"",
            ""id"": ""9e71f4c2-ef83-49cd-b69c-2aa012b6c424"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""99c2e6da-e76d-4235-a178-6b283b6688a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ffeb3600-18ed-4919-a617-cdd4d92dec17"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<VirtualMouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerNormal
        m_PlayerNormal = asset.FindActionMap("PlayerNormal", throwIfNotFound: true);
        m_PlayerNormal_Jump = m_PlayerNormal.FindAction("Jump", throwIfNotFound: true);
        m_PlayerNormal_Movement = m_PlayerNormal.FindAction("Movement", throwIfNotFound: true);
        m_PlayerNormal_Attack = m_PlayerNormal.FindAction("Attack", throwIfNotFound: true);
        m_PlayerNormal_Crouch = m_PlayerNormal.FindAction("Crouch", throwIfNotFound: true);
        m_PlayerNormal_JumpDown = m_PlayerNormal.FindAction("JumpDown", throwIfNotFound: true);
        m_PlayerNormal_Blocking = m_PlayerNormal.FindAction("Blocking", throwIfNotFound: true);
        // PlayerRebinding
        m_PlayerRebinding = asset.FindActionMap("PlayerRebinding", throwIfNotFound: true);
        m_PlayerRebinding_Newaction = m_PlayerRebinding.FindAction("New action", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerNormal
    private readonly InputActionMap m_PlayerNormal;
    private List<IPlayerNormalActions> m_PlayerNormalActionsCallbackInterfaces = new List<IPlayerNormalActions>();
    private readonly InputAction m_PlayerNormal_Jump;
    private readonly InputAction m_PlayerNormal_Movement;
    private readonly InputAction m_PlayerNormal_Attack;
    private readonly InputAction m_PlayerNormal_Crouch;
    private readonly InputAction m_PlayerNormal_JumpDown;
    private readonly InputAction m_PlayerNormal_Blocking;
    public struct PlayerNormalActions
    {
        private @PlayerControl m_Wrapper;
        public PlayerNormalActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_PlayerNormal_Jump;
        public InputAction @Movement => m_Wrapper.m_PlayerNormal_Movement;
        public InputAction @Attack => m_Wrapper.m_PlayerNormal_Attack;
        public InputAction @Crouch => m_Wrapper.m_PlayerNormal_Crouch;
        public InputAction @JumpDown => m_Wrapper.m_PlayerNormal_JumpDown;
        public InputAction @Blocking => m_Wrapper.m_PlayerNormal_Blocking;
        public InputActionMap Get() { return m_Wrapper.m_PlayerNormal; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerNormalActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerNormalActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerNormalActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerNormalActionsCallbackInterfaces.Add(instance);
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Crouch.started += instance.OnCrouch;
            @Crouch.performed += instance.OnCrouch;
            @Crouch.canceled += instance.OnCrouch;
            @JumpDown.started += instance.OnJumpDown;
            @JumpDown.performed += instance.OnJumpDown;
            @JumpDown.canceled += instance.OnJumpDown;
            @Blocking.started += instance.OnBlocking;
            @Blocking.performed += instance.OnBlocking;
            @Blocking.canceled += instance.OnBlocking;
        }

        private void UnregisterCallbacks(IPlayerNormalActions instance)
        {
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Crouch.started -= instance.OnCrouch;
            @Crouch.performed -= instance.OnCrouch;
            @Crouch.canceled -= instance.OnCrouch;
            @JumpDown.started -= instance.OnJumpDown;
            @JumpDown.performed -= instance.OnJumpDown;
            @JumpDown.canceled -= instance.OnJumpDown;
            @Blocking.started -= instance.OnBlocking;
            @Blocking.performed -= instance.OnBlocking;
            @Blocking.canceled -= instance.OnBlocking;
        }

        public void RemoveCallbacks(IPlayerNormalActions instance)
        {
            if (m_Wrapper.m_PlayerNormalActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerNormalActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerNormalActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerNormalActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerNormalActions @PlayerNormal => new PlayerNormalActions(this);

    // PlayerRebinding
    private readonly InputActionMap m_PlayerRebinding;
    private List<IPlayerRebindingActions> m_PlayerRebindingActionsCallbackInterfaces = new List<IPlayerRebindingActions>();
    private readonly InputAction m_PlayerRebinding_Newaction;
    public struct PlayerRebindingActions
    {
        private @PlayerControl m_Wrapper;
        public PlayerRebindingActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_PlayerRebinding_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_PlayerRebinding; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerRebindingActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerRebindingActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerRebindingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerRebindingActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(IPlayerRebindingActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(IPlayerRebindingActions instance)
        {
            if (m_Wrapper.m_PlayerRebindingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerRebindingActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerRebindingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerRebindingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerRebindingActions @PlayerRebinding => new PlayerRebindingActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IPlayerNormalActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnJumpDown(InputAction.CallbackContext context);
        void OnBlocking(InputAction.CallbackContext context);
    }
    public interface IPlayerRebindingActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
