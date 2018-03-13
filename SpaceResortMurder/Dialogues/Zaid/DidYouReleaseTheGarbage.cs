﻿using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class DidYouReleaseTheGarbage : Dialogue
    {
        public DidYouReleaseTheGarbage() : base(nameof(DidYouReleaseTheGarbage)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(GarbageAirlock));
        }
    }
}
