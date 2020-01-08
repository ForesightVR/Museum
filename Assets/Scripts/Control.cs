// GENERATED AUTOMATICALLY FROM 'Assets/Control.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Control : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @Control()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Control"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""a9da1bbb-5696-438e-bc97-9bd0c8eddc5e"",
            ""actions"": [
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Value"",
                    ""id"": ""339a5ff7-1b92-46f4-9170-71df26aa5908"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightStick"",
                    ""type"": ""Value"",
                    ""id"": ""13a373db-9e0d-4485-a3f8-aa036279082c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f6a7f782-c3e9-4b9b-b996-30175b865792"",
                    ""path"": ""<OculusTouchController>{LeftHand}/thumbstick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b9f2ebf-97f0-4bff-9974-16dc0bb82eb7"",
                    ""path"": ""<OculusTouchController>{RightHand}/thumbstick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_LeftStick = m_Controls.FindAction("LeftStick", throwIfNotFound: true);
        m_Controls_RightStick = m_Controls.FindAction("RightStick", throwIfNotFound: true);
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

    // Controls
    private readonly InputActionMap m_Controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_Controls_LeftStick;
    private readonly InputAction m_Controls_RightStick;
    public struct ControlsActions
    {
        private @Control m_Wrapper;
        public ControlsActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftStick => m_Wrapper.m_Controls_LeftStick;
        public InputAction @RightStick => m_Wrapper.m_Controls_RightStick;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @LeftStick.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLeftStick;
                @LeftStick.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLeftStick;
                @LeftStick.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLeftStick;
                @RightStick.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRightStick;
                @RightStick.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRightStick;
                @RightStick.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRightStick;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
                @RightStick.started += instance.OnRightStick;
                @RightStick.performed += instance.OnRightStick;
                @RightStick.canceled += instance.OnRightStick;
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);
    public interface IControlsActions
    {
        void OnLeftStick(InputAction.CallbackContext context);
        void OnRightStick(InputAction.CallbackContext context);
    }
}
