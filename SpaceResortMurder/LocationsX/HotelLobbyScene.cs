﻿using MonoDragons.Core.AudioSystem;

namespace SpaceResortMurder.LocationsX
{
    public sealed class HotelLobbyScene : LocationScene
    {
        public HotelLobbyScene() 
            : base(nameof(HotelLobbyScene)) { }

        protected override string Name => "Hotel Lobby";

        protected override void OnInit()
        {
            Audio.PlayMusicOnce("HotelLobby");
        }

        protected override void DrawBackground()
        {
        }
    }
}
