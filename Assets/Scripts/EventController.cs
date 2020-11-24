﻿// Brought to you by Jenni

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class EventController {

    #region Singleton

    private static bool isQuitting = false;
    private static EventController instance = null;
    public static EventController Instance {
        get {
            if (instance == null && !isQuitting) {
                instance = new EventController();
                Application.quitting += () => isQuitting = true;
            }
            return instance;
        }
    }

    private EventController() { }
    #endregion

    #region EventSource & Delegates
    // Game events that require multiple game objects to update
    // should all be listed here
    public delegate void OnResetHandler();
    public event OnResetHandler OnReset;

    public delegate void OnPauseHandler();
    public event OnPauseHandler OnPause;

    public delegate void OnResumeHandler();
    public event OnResumeHandler OnResume;

    public delegate void OnGameOverHandler();
    public event OnGameOverHandler OnGameOver;

    public delegate void OnLivesLeftHandler();
    public event OnLivesLeftHandler OnLivesLeft;

    // Character Specific Events to possibly move in the future
    public delegate void OnHealthPotFindHandler();
    public event OnHealthPotFindHandler OnHealthPotFind;

    public delegate void OnPlayerDeathHandler();
    public event OnPlayerDeathHandler OnPlayerDeath;

    public delegate void OnTreasureFindHandler();
    public event OnTreasureFindHandler OnTreasureFind;

    public delegate void OnObjectDestroyHandler();
    public event OnObjectDestroyHandler OnObjectDestroy;

    public delegate void OnCoinUpdateHandler();
    public event OnCoinUpdateHandler OnCoinUpdate;

    public delegate void OnTriggerUseHandler();
    public event OnTriggerUseHandler OnTriggerUse;

    public event Action<List<KeyType>> OnKeyHolderChange;

    public event Action OnKeyComboFail;

    public event Action OnButtonPushSuccess;

    public event Action OnDoorOpen;

    public event Action OnBridgeOpen;
    #endregion

    #region Class Methods
    public void BroadcastDoorOpen() {
        OnDoorOpen?.Invoke();
    }

    public void BroadcastBridgeOpen() {
        OnBridgeOpen?.Invoke();
    }
    public void BroadcastButtonPushSuccess() {
        OnButtonPushSuccess?.Invoke();
    }

    public void BroadcastKeyComboFail() {
        OnKeyComboFail?.Invoke();
    }

    public void BroadcastKeyHolderChange(List<KeyType> keys) {
        OnKeyHolderChange?.Invoke(keys);
    }

    public void BroadcastReset() {
        OnReset?.Invoke();
    }

    public void BroadcastPause() {
        OnPause?.Invoke();
    }

    public void BroadcastResume() {
        OnResume?.Invoke();
    }

    public void BroadcastGameOver() {
        OnGameOver?.Invoke();
    }

    public void BroadcastLivesLeft() {
        OnLivesLeft?.Invoke();
    }

    public void BroadcastHealthPotFind() {
        OnHealthPotFind?.Invoke();
        Debug.Log("Broadcast");
    }

    public void BroadcastOnPlayerDeath() {
        OnPlayerDeath?.Invoke();
        Debug.Log("Broadcast death");
    }

    public void BroadcastOnTreasureFind() {
        OnTreasureFind?.Invoke();
        Debug.Log("Broadcast Treasure");
    }

    public void BroadcastOnObjectDestroy() {
        OnObjectDestroy?.Invoke();
        Debug.Log("Broadcast Object Destroy");
    }

    public void BroadcastOnCoinUpdate() {
        OnCoinUpdate?.Invoke();
        Debug.Log("Broadcast Coin Update");
    }

    public void BroadcastOnTriggerUse() {
        OnTriggerUse?.Invoke();
        Debug.Log("Broadcast Trigger Use");
    }

    #endregion
}
