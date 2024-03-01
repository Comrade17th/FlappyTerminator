using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
   private PlayerMover _playerMover;
   private ScoreCounter _scoreCounter;
   private PlayerCollisionHandler _handler;

   public event Action GameOver;

   private void Awake()
   {
      _playerMover = GetComponent<PlayerMover>();
      _scoreCounter = GetComponent<ScoreCounter>();
      _handler = GetComponent<PlayerCollisionHandler>();
   }

   public void Reset()
   {
      _scoreCounter.Reset();
      _playerMover.Reset();
   }
}
