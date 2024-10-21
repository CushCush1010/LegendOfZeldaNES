﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public interface IEnvironmentFactory
    {

        void setLevel(int level);
        int getLevel();
        void loadLevel();
        Dictionary<BlockManager.BlockNames, List<Rectangle>> getCollidables();
        Rectangle getRoomDimensions();
    }
}
