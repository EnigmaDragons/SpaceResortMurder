﻿using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class WhySoFewPeopleAtTheResort : Dialogue
    {
        public WhySoFewPeopleAtTheResort() : base(nameof(WhySoFewPeopleAtTheResort)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(WhoIsStayingAtYourResort));
        }
    }
}
