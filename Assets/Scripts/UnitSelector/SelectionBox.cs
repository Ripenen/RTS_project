using System;
using UnityEngine;

namespace UnitSelector
{
    public class SelectionBox
    {
        private readonly Texture2D _backgroundTexture;
        private readonly Texture2D _borderTexture;
        private readonly int _borderWidth;
        
        public SelectionBox(Color backgroundColor, Color borderColor, uint borderWidth)
        {
            _borderWidth = (int)borderWidth;
            
            _backgroundTexture = new Texture2D(1, 1);
            _borderTexture = new Texture2D(1, 1);
            
            _backgroundTexture.SetPixel(0, 0, backgroundColor);
            _borderTexture.SetPixel(0, 0, borderColor);
        
            _backgroundTexture.Apply();
            _borderTexture.Apply();
        }  

        public void Draw(Rect screenRect)
        {
            float xMin = screenRect.x;
            float xMax = screenRect.xMax;
            float yMin = screenRect.y;
            float yMax = screenRect.yMax;
            
            if (screenRect.x > screenRect.xMax)
            {
                xMin = screenRect.xMax;
                xMax = screenRect.x;
            }

            if (screenRect.y < screenRect.yMax)
            {
                yMin = screenRect.yMax;
                yMax = screenRect.y;
            }
            
            var invertedYRect = Rect.MinMaxRect(xMin, Screen.height - yMin,
                xMax, Screen.height - yMax);
            
            Graphics.DrawTexture(invertedYRect, _backgroundTexture);

            //Draw borders
            Graphics.DrawTexture(Rect.MinMaxRect(invertedYRect.x, invertedYRect.y, 
                invertedYRect.xMin + _borderWidth, invertedYRect.yMax), _borderTexture);
            Graphics.DrawTexture(Rect.MinMaxRect(invertedYRect.x, invertedYRect.y, 
                invertedYRect.xMax, invertedYRect.y + _borderWidth), _borderTexture);
            Graphics.DrawTexture(Rect.MinMaxRect(invertedYRect.x, invertedYRect.yMax - _borderWidth, 
                invertedYRect.xMax, invertedYRect.yMax), _borderTexture);
            Graphics.DrawTexture(Rect.MinMaxRect(invertedYRect.xMax - _borderWidth, invertedYRect.y, 
                invertedYRect.xMax, invertedYRect.yMax), _borderTexture);
        }
    }
}