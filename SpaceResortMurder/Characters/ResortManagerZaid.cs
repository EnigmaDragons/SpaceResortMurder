﻿using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogs;

namespace SpaceResortMurder.Characters
{
    public class ResortManagerZaid : Person
    {
        public ResortManagerZaid() : base("resort-manager-colored", new Size2(399, 937), new DidYouKillHimZaid()) {}

        public override string WhereAreYou()
        {
            return GameObjects.RoomNames.SecondRoom;
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(800, 200), new Size2(200, 470));
        }
    }
}
