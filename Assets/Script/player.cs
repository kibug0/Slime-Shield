//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.1
//     from Assets/Script/Player.inputactions
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

public partial class @player : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""8834d437-c0d0-4363-b936-82cdcb7e74bc"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""1114eb84-072d-4813-9820-886fe392114b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ChangeEnemy1"",
                    ""type"": ""Button"",
                    ""id"": ""84f3f365-7824-4eed-877b-a45e237de5ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChangeEnemy2"",
                    ""type"": ""Button"",
                    ""id"": ""b9844f32-1250-411b-b84b-b1dc8788848e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChangeEnemyAll"",
                    ""type"": ""Button"",
                    ""id"": ""3bb60211-5644-449a-9893-f140f8062728"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Walk"",
                    ""id"": ""51fe5619-734b-42fe-8b31-017f29461cda"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""40a45a6b-1a40-4746-869f-21e2d5280a2d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9f760f03-7cc4-423d-b010-d654eb61537e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ef5a0185-7fb2-4fcc-9b2d-959766b9dd70"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""223a6e98-ed70-48d4-9d3f-e5b565c331f8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""efd171c0-fd1e-4b06-9abb-f4b264c1889e"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeEnemy1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b66603f-0d4c-48ba-923a-73599fe652fd"",
                    ""path"": ""<Keyboard>/f2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeEnemy2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f779386-0fa1-4964-be2e-259662aab6e6"",
                    ""path"": ""<Keyboard>/f3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeEnemyAll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Walk = m_Player.FindAction("Walk", throwIfNotFound: true);
        m_Player_ChangeEnemy1 = m_Player.FindAction("ChangeEnemy1", throwIfNotFound: true);
        m_Player_ChangeEnemy2 = m_Player.FindAction("ChangeEnemy2", throwIfNotFound: true);
        m_Player_ChangeEnemyAll = m_Player.FindAction("ChangeEnemyAll", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Walk;
    private readonly InputAction m_Player_ChangeEnemy1;
    private readonly InputAction m_Player_ChangeEnemy2;
    private readonly InputAction m_Player_ChangeEnemyAll;
    public struct PlayerActions
    {
        private @player m_Wrapper;
        public PlayerActions(@player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Player_Walk;
        public InputAction @ChangeEnemy1 => m_Wrapper.m_Player_ChangeEnemy1;
        public InputAction @ChangeEnemy2 => m_Wrapper.m_Player_ChangeEnemy2;
        public InputAction @ChangeEnemyAll => m_Wrapper.m_Player_ChangeEnemyAll;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @ChangeEnemy1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeEnemy1;
                @ChangeEnemy1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeEnemy1;
                @ChangeEnemy1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeEnemy1;
                @ChangeEnemy2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeEnemy2;
                @ChangeEnemy2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeEnemy2;
                @ChangeEnemy2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeEnemy2;
                @ChangeEnemyAll.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeEnemyAll;
                @ChangeEnemyAll.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeEnemyAll;
                @ChangeEnemyAll.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeEnemyAll;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @ChangeEnemy1.started += instance.OnChangeEnemy1;
                @ChangeEnemy1.performed += instance.OnChangeEnemy1;
                @ChangeEnemy1.canceled += instance.OnChangeEnemy1;
                @ChangeEnemy2.started += instance.OnChangeEnemy2;
                @ChangeEnemy2.performed += instance.OnChangeEnemy2;
                @ChangeEnemy2.canceled += instance.OnChangeEnemy2;
                @ChangeEnemyAll.started += instance.OnChangeEnemyAll;
                @ChangeEnemyAll.performed += instance.OnChangeEnemyAll;
                @ChangeEnemyAll.canceled += instance.OnChangeEnemyAll;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnChangeEnemy1(InputAction.CallbackContext context);
        void OnChangeEnemy2(InputAction.CallbackContext context);
        void OnChangeEnemyAll(InputAction.CallbackContext context);
    }
}