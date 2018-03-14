﻿using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Text;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues
{
    public abstract class Dialogue
    {
        public string Dialog;

        public bool IsNew => !CurrentGameState.HasViewedItem(Dialog);
        public bool AutoPlay { get; protected set; } = false;

        protected Dialogue(string dialog)
        {
            Dialog = dialog;
        }

        public abstract bool IsActive();

        public void StartImmediateDialog(Action<string[]> onStart)
        {
            Event.Publish(new ItemViewed(Dialog));
            Event.Publish(new ThoughtGained(Dialog));
            onStart(GameResources.GetDialogueLines(Dialog));
        }

        public VisualClickableUIElement CreateButton(Action<string[]> onClick, int i, int count)
        {
            var buttonWidth = 1380;
            var xOff = -684;
            var xInc = 67;
            var yInc = 92;
            var xPos = Math.Max(i * xInc + xOff,(int) DefaultFont.ScaledFontSet.MeasureString(GameResources.GetDialogueOpener(Dialog)).X - buttonWidth + 165);
            var yPos = 400 + i * yInc;
            var t = new Transform2(new Vector2(xPos, yPos), new Size2(buttonWidth, 64)).ToRectangle();
            return new ImageTextButton(t, GetOnClick(onClick), GameResources.GetDialogueOpener(Dialog),
                "Convo/DialogueButton", "Convo/DialogueButton-Hover", "Convo/DialogueButton-Press")
            {
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(50, yPos), Rotation2.Default, new Size2(buttonWidth - xPos, 64), 1.0f),
                TextAlignment = HorizontalAlignment.Left
            };
        }

        private Action GetOnClick(Action<string[]> onClick)
        {
            return IsNew
                ? (() =>
                    {
                        Event.Publish(new DialogMemoryGained(Dialog, CurrentGameState.CurrentLocationImage));
                        Event.Publish(new ThoughtGained(Dialog));
                        onClick(GameResources.GetDialogueLines(Dialog));
                    })
                : (Action)(() => onClick(GameResources.GetDialogueLines(Dialog)));
        }
    }
}
