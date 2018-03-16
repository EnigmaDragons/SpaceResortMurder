﻿namespace SpaceResortMurder.State
{
    public static class CurrentGameState
    {
        public static GameState Value { get; private set; }

        public static string CurrentLocation
        {
            get => Value.CurrentLocation;
            set => Value.CurrentLocation = value;
        }

        public static string CurrentLocationImage
        {
            get => Value.CurrentLocationImage;
            set => Value.CurrentLocationImage = value;
        }

        static CurrentGameState()
        {
            Value = new GameState();
        }

        public static void Reset()
        {
            Value = new GameState();
        }

        public static void Load(string saveName)
        {
            Value = GameObjects.IO.Load<GameState>(saveName);
        }

        public static bool HasViewedItem(string item)
        {
            return Value.HasViewedItem(item);
        }

        public static bool IsThinking(string thought)
        {
            return Value.IsThinking(thought);
        }
        
        public static string RememberLocation(string dialog)
        {
            return Value.RememberLocation(dialog);
        }
    }
}
