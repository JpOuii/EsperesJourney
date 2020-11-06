﻿// Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    [SerializeField] private KeyType keyType;

    public enum KeyType {
        None,
        Blue,
        Green,
        Red,
        Yellow,
        Black,
        Grey,
    }

    public KeyType GetKeyType() {
        return keyType;
    }

    public static Color GetColor(KeyType keyType) {
        switch (keyType) {
            default:
            case KeyType.Red: return Color.red;
            case KeyType.Green: return Color.green;
            case KeyType.Blue: return Color.blue;
            case KeyType.Yellow: return Color.yellow;
            case KeyType.Black: return Color.black;
            case KeyType.Grey: return Color.grey;
        }
    }
 }