﻿using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class YouAreStillResposible : Dialogue
    {
        public YouAreStillResposible() : base(nameof(YouAreStillResposible)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ExplainTheCloningMachine));
        }
    }
}