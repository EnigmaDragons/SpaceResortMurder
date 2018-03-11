﻿using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Dialogs
{
    public class ChatBox : IVisual, IAutomaton
    {
        private readonly int _maxLineWidth;
        private readonly SpriteFont _spriteFont;
        private readonly double _millisToCharacter = 35;
        private string _currentlyDisplayedMessage;
        private string _messageToDisplay;
        private long _totalMessageTime;

        public ChatBox(string message, int maxLineWidth, SpriteFont spriteFont)
        {
            this._spriteFont = spriteFont;
            this._maxLineWidth = maxLineWidth;
            _currentlyDisplayedMessage = "";
            _messageToDisplay = WrapText(message);
        }

        public bool IsMessageCompletelyDisplayed()
        {
            return _currentlyDisplayedMessage.Length == _messageToDisplay.Length;
        }

        public void ShowMessage(string message)
        {
            _currentlyDisplayedMessage = "";
            _messageToDisplay = WrapText(message);
            _totalMessageTime = 0;
        }

        public void CompletelyDisplayMessage()
        {
            _currentlyDisplayedMessage = _messageToDisplay;
            _totalMessageTime = (int)(_millisToCharacter * _messageToDisplay.Length);
        }

        public void Update(TimeSpan deltaMillis)
        {
            _totalMessageTime += deltaMillis.Milliseconds;
            var length = (int)((double)_totalMessageTime / (double)_millisToCharacter);
            length = _messageToDisplay.Length < length ? _messageToDisplay.Length : length;
            _currentlyDisplayedMessage = _messageToDisplay.Substring(0, length);
        }

        public void Draw(Transform2 parentTransform)
        {
            UI.DrawText(_currentlyDisplayedMessage, parentTransform.Location, Color.White);
        }

        private string WrapText(string text)
        {
            var words = text.Split(' ');
            var sb = new StringBuilder();
            var lineWidth = 0f;
            var spaceWidth = _spriteFont.MeasureString(" ").X;
            foreach (var word in words)
            {
                var size = _spriteFont.MeasureString(word);
                if (lineWidth + size.X < _maxLineWidth)
                {
                    sb.Append(word + " ");
                    lineWidth += size.X + spaceWidth;
                }
                else
                {
                    sb.Append("\n" + word + " ");
                    lineWidth = size.X + spaceWidth;
                }
            }
            return sb.ToString();
        }
    }
}