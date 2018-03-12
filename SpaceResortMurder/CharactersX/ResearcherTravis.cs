﻿using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class ResearcherTravis : Character
    {
        public ResearcherTravis() : base("Travis Falcon", "characters/scientist_guy", new Size2(400, 940)) {}

        public override string WhereAreYou()
        {
            return nameof(Lobby);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(700, 215), new Size2(200, 470));
        }
    }
}
