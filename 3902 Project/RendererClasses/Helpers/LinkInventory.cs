﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public class LinkInventory
    {
        // our dictionary inventory
        private Dictionary<ProjectileManager.ProjectileNames, int> _projectileInventory = new();

        // links current sword type
        public enum LinkSwordType { WOOD, IRON, MASTER, STAFF }
        private LinkSwordType _linkSwordType;
        public LinkSwordType CurrentLinkSword { get { return _linkSwordType; } set { _linkSwordType = value; } }

        // if link got shield upgrade
        private bool _linkShieldSmall;

        public bool LinkShield { get { return _linkShieldSmall; } set { _linkShieldSmall = value; } }

        private int _linkEmeraldAmount = 13;
        private int _linkNormalKeyAmount = 100;
        private int _linkProjectileAmount = 3;
        public int EmeraldAmount { get { return _linkEmeraldAmount; } set { _linkEmeraldAmount = value; } }
        public int KeyAmount { get { return _linkNormalKeyAmount; } set { _linkNormalKeyAmount = value; } }
        public int ProjectileAmount { get { return _linkProjectileAmount; } set { _linkProjectileAmount = value; } }


        public LinkInventory()
        {
            CurrentLinkSword = LinkSwordType.WOOD;
            // initialize link shield to be small
            LinkShield = false;

            // initializing some amounts for testing
            int amount = 10;
            _projectileInventory.Add(ProjectileManager.ProjectileNames.FireBall, amount);
            _projectileInventory.Add(ProjectileManager.ProjectileNames.BlueArrow, amount);
            _projectileInventory.Add(ProjectileManager.ProjectileNames.Bomb, amount);
            _projectileInventory.Add(ProjectileManager.ProjectileNames.Boomerang, amount);
        }

        public void AddItem(ProjectileManager.ProjectileNames name, int amount)
        {
            int newAmount = _projectileInventory.GetValueOrDefault(name) + amount;
            _projectileInventory.Remove(name);
            _projectileInventory.Add(name, newAmount);
        }

        public void RemoveItem(ProjectileManager.ProjectileNames name, int amount)
        {
            int newAmount = _projectileInventory.GetValueOrDefault(name) - amount;
            if (newAmount < 0) { newAmount = 0; }
            _projectileInventory.Remove(name);
            _projectileInventory.Add(name, newAmount);
        }

        public Dictionary<ProjectileManager.ProjectileNames, int> GetProjectileInventory()
        {
            return _projectileInventory;
        }
    }
}