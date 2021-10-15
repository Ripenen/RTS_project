using System;
using UnityEngine;

namespace UnitSelector
{
    public class SelectionBox
    {
        private readonly Texture2D _backgroundTexture;
        private readonly Texture2D _borderTexture;
        private readonly uint _borderWidth;
        
        public SelectionBox(Color backgroundColor, Color borderColor, uint borderWidth)
        {
            _borderWidth = borderWidth;
            
            _backgroundTexture = new Texture2D(1, 1);
            _borderTexture = new Texture2D(1, 1);
        
            _backgroundTexture.SetPixel(0, 0, backgroundColor);
            _borderTexture.SetPixel(0, 0, borderColor);
        
            _backgroundTexture.Apply();
            _borderTexture.Apply();
        }  

        public void Draw(Rect screenRect)
        {
            var invertedYRect = Rect.MinMaxRect(screenRect.position.x, Screen.height - screenRect.position.y,
                screenRect.xMax, Screen.height - screenRect.yMax);
            
            Graphics.DrawTexture(invertedYRect, _backgroundTexture);
            
            //Draw borders
            Graphics.DrawTexture(Rect.MinMaxRect(invertedYRect.xMin, invertedYRect.yMin, 
                invertedYRect.xMin - _borderWidth, invertedYRect.yMax), _borderTexture);
            Graphics.DrawTexture(Rect.MinMaxRect(invertedYRect.x, invertedYRect.y, 
                invertedYRect.xMax, invertedYRect.y + _borderWidth), _borderTexture);
            Graphics.DrawTexture(Rect.MinMaxRect(invertedYRect.x, invertedYRect.yMax - _borderWidth, 
                invertedYRect.xMax, invertedYRect.yMax), _borderTexture);
            Graphics.DrawTexture(Rect.MinMaxRect(invertedYRect.xMax + _borderWidth, invertedYRect.y, 
                invertedYRect.xMax, invertedYRect.yMax), _borderTexture);
        }
    }
}