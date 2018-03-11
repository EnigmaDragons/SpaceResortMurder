﻿using Microsoft.Xna.Framework;

namespace SpaceResortMurder.LocationsX
{
    public class SecondRoom : Location
    {
        public SecondRoom() : base(nameof(SecondRoom), "Second Room", new Vector2(600, 250)) {}

        public override bool IsAvailable()
        {
            return true;
        }
    }
}