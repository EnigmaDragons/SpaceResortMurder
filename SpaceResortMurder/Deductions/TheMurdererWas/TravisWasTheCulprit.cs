﻿using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class TravisWasTheCulprit : Deduction
    {
        public TravisWasTheCulprit() : base(nameof(TravisWasTheCulprit)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(WhoIsStayingAtYourResort));
        }
    }
}
