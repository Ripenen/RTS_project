using System;
using UnityEngine;
using Color = UnityEngine.Color;
using Vector2 = UnityEngine.Vector2;

namespace UnitSelector
{
    public class SelectorArea : MonoBehaviour
    {
        [SerializeField] private Color _backgroundSelectorColor;
        [SerializeField] private Color _borderSelectorColor;
        [SerializeField] private ScreenProjector _screenProjector;
        [SerializeField] private uint _borderWidth;
        
        private SelectionBox _selectionBox;
        private bool _isDrawing;
        private Rect _selectionRect;

        private void Start()
        {
            _selectionBox = new SelectionBox(_backgroundSelectorColor, _borderSelectorColor, _borderWidth);
        }

        public void StartDraw(Vector2 startPos)
        {
            _isDrawing = true;
        
            _selectionRect = new Rect(startPos, Vector2.zero);
        }
        public void Draw(Vector2 endPos)
        {
            if (!_isDrawing)
                throw new InvalidOperationException("Drawing not started");

            _selectionRect = Rect.MinMaxRect(_selectionRect.position.x, _selectionRect.position.y,
                endPos.x, endPos.y);
        }

        public void StopDraw()
        {
            _isDrawing = false;
        }

        public bool ContainsUnit(Unit unit)
        {
            if (!_isDrawing)
                throw new InvalidOperationException("Drawing is End");

            if (!unit.IsVisible)
                return false;
            
            var bounds = unit.WorldBounds;
            var unitScreenRect = _screenProjector.WorldBoundsToScreenRect(bounds);
        
            return _selectionRect.Overlaps(unitScreenRect, true); 
        }

        private void OnGUI()
        {
            if (_isDrawing)
            {
                _selectionBox.Draw(_selectionRect);
            }
        }
    }
}