﻿using System;
using NAudio.Wave;

namespace MonoDragons.Core.AudioSystem
{
    public static class Audio
    {
        private static Dampening _backgroundMusic;
        private static string _currentMusic = "";

        public static float MusicVolume { get; set; } = 1;
        public static float SoundVolume { get; set; } = 1;

        public static void PlaySound(string name)
        {
            PlaySound(name, 1.0f);
        }

        public static void PlaySound(string name, float volume)
        {
            AudioPlayer.Instance.Play(new PlayOnce($"Content/Sounds/{ name }.mp3", volume * SoundVolume));
        }

        public static void PlayMusicEffect(string name)
        {
            PlayMusicEffect(name, 1.0f);
        }

        public static void PlayMusicEffect(string name, float volume)
        {
            var input = new PlayOnce($"Content/Music/{ name }.mp3", volume * SoundVolume);

            if (_backgroundMusic != null)
            {
                _backgroundMusic.AddDampener();
                input.OnSoundFinished += OnMusicEffectFinished;
            }

            AudioPlayer.Instance.Play(input);
        }

        private static void OnMusicEffectFinished(object sender, EventArgs e)
        {
            ((PlayOnce)sender).OnSoundFinished -= OnMusicEffectFinished;
            _backgroundMusic.RemoveDampener();
        }

        public static void PlayMusicOnce(string name)
        {
            PlayMusicOnce(name, 0.5f);
        }

        public static void PlayMusicOnce(string name, float volume)
        {
            if (_currentMusic != name)
            {
                TransitionToSong(volume * MusicVolume, new PlayOnce($"Content/Music/{ name }.mp3"));
                _currentMusic = name;
            }
        }

        public static void PlayMusic(string name)
        {
            PlayMusic(name, 0.5f);
        }

        public static void PlayMusic(string name, float volume)
        {
            if (_currentMusic != name)
            {
                TransitionToSong(volume * MusicVolume, new Looping($"Content/Music/{ name }.mp3"));
                _currentMusic = name;
            }
        }

        public static void StopAllSound()
        {
            AudioPlayer.Instance.Stop();
        }

        public static void StopMusic()
        {
            PlayMusic("mute", 0);
        }

        private static void TransitionToSong(float volume, ISampleProvider song)
        {
            if (_backgroundMusic == null)
                _backgroundMusic = new Dampening(song, volume);
            else
            {
                var old = _backgroundMusic;
                _backgroundMusic = new Dampening(song, volume, old.Dampeners);
                old.Volume = 0;
            }
            AudioPlayer.Instance.Play(_backgroundMusic);
        }
    }
}
