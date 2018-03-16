﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Animations;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Credits
{
    public abstract class BasicJamCreditSegment : IAnimation
    {
        private List<HorizontalFlyInAnimation> _elements = new List<HorizontalFlyInAnimation>();
        
        private int _countdown;

        public abstract string Image { get; }
        public abstract string Role { get; }
        public abstract string Name { get; }

        public void Update(TimeSpan delta)
        {
            _elements.ForEach(x => x.Update(delta));
        }

        public void Draw(Transform2 parentTransform)
        {
            _elements.ForEach(x => x.Draw(parentTransform));
        }

        public void Start(Action onFinished)
        {
            _elements.Add(new HorizontalFlyInAnimation(
                new Label
                {
                    TextColor = UiStyle.TextGreen, Text = Role,
                    Transform = new Transform2(new Vector2(-600, 400), new Size2(500, 100)),
                    Font = UiFonts.Header
                }));
            _elements.Add(new HorizontalFlyInAnimation(
                new Label
                    { Text = Name,
                        Transform = new Transform2(new Vector2(1920, 550), new Size2(500, 75))
                    })
                { FromDir = HorizontalDirection.Right, ToDir = HorizontalDirection.Left });

            _countdown = _elements.Count;
            _elements.ForEach(x => x.Start(() => FinishedOne(onFinished)));
        }

        private void FinishedOne(Action onFinished)
        {
            _countdown--;
            if (_countdown == 0)
                onFinished();
        }
    }
}
