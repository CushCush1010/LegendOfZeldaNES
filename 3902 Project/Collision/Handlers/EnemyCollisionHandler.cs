﻿using _3902_Project;
using Microsoft.Xna.Framework;
using System;
using System.ComponentModel.Design;

public class EnemyCollisionHandler
{
    private EnemyManager _enemy;
    private ItemManager _item;
    private PlaySoundEffect _sound;

    public EnemyCollisionHandler() { }

    /// <summary>
    /// Load everything that this handler needs
    /// </summary>
    /// <param name="enemy">manager for enemies</param>
    public void LoadAll(EnemyManager enemy, ItemManager item, PlaySoundEffect sound)
    {
        _enemy = enemy;
        _item = item;
        _sound = sound;
    }

    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        if (objectB is BlockCollisionBox)
            HandleBlockCollision(objectA, objectB, side);
        else if (objectB is LinkProjCollisionBox)
            HandleLinkProjCollision(objectA, objectB, side);
    }

    private void HandleBlockCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        // Handle player collision with block
        Rectangle BoundsA = objectA.Bounds;
        Rectangle BoundsB = objectB.Bounds;

        switch (side)
        {
            case CollisionData.CollisionType.BOTTOM:
                BoundsA.Y = BoundsB.Top - BoundsA.Height; break;    // Move player above the block
            case CollisionData.CollisionType.TOP:
                BoundsA.Y = BoundsB.Bottom; break;                  // Move player below the block
            case CollisionData.CollisionType.RIGHT:
                BoundsA.X = BoundsB.Left - BoundsA.Width; break;    // Move player to the left of the block
            case CollisionData.CollisionType.LEFT:
                BoundsA.X = BoundsB.Right; break;                   // Move player to the right of the block
            default: break;
        }

        objectA.Sprite.PositionOnWindow = new(BoundsA.X, BoundsA.Y);
    }

    private void HandleLinkProjCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        if (!_enemy.IsDamaged(objectA.Sprite))
        {
            objectA.Health -= objectB.Damage;
            switch (objectA.Sprite)
            {
                // if had special enemies, could change their total damage time and stuff
                default: _enemy.SetDamageHelper(45, false, side, objectA.Sprite); break;
            }
            if (objectA.Health > 0)
                _sound.PlaySound(PlaySoundEffect.Sounds.Enemy_Zapped);
            else
            {
                _sound.PlaySound(PlaySoundEffect.Sounds.Enemy_Death);
                Random random = new();
                int currentOdds = random.Next(10);
                switch (objectA.Sprite)
                {
                    case GreenSlime:
                        if (currentOdds <= 5) _item.AddItem(ItemManager.ItemNames.FlashingEmerald, objectA.Sprite.PositionOnWindow, 4f);
                        else if (currentOdds <= 7) _item.AddItem(ItemManager.ItemNames.Rupees, objectA.Sprite.PositionOnWindow, 4f);
                        else _item.AddItem(ItemManager.ItemNames.Meat, objectA.Sprite.PositionOnWindow, 4f);
                        break;
                    case Darknut:
                        if (currentOdds <= 5) _item.AddItem(ItemManager.ItemNames.FlashingEmerald, objectA.Sprite.PositionOnWindow, 4f);
                        else if (currentOdds <= 7) _item.AddItem(ItemManager.ItemNames.Rupees, objectA.Sprite.PositionOnWindow, 4f);
                        else _item.AddItem(ItemManager.ItemNames.FlashingPotion, objectA.Sprite.PositionOnWindow, 4f);
                        break;
                    case BrownSlime:
                        if (currentOdds <= 5) _item.AddItem(ItemManager.ItemNames.FlashingEmerald, objectA.Sprite.PositionOnWindow, 4f);
                        else if (currentOdds <= 7) _item.AddItem(ItemManager.ItemNames.Rupees, objectA.Sprite.PositionOnWindow, 4f);
                        else _item.AddItem(ItemManager.ItemNames.FlashingLife, objectA.Sprite.PositionOnWindow, 4f);
                        break;
                    case BigBoss:
                        // enter win state
                        _item.AddItem(ItemManager.ItemNames.FlashingTriForce, objectA.Sprite.PositionOnWindow, 4f); break;
                }
                _enemy.UnloadEnemy(objectA);
            }

            Console.WriteLine("EnemyCollisionhandler: LinkProj hit, current health of enemy: " + objectA.Health);
        }
    }
}