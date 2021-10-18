using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnitSelector
{
    public class Selector : MonoBehaviour
    {
        public IEnumerable<Unit> SelectedUnits => _selectedUnits;

        [SerializeField] private SelectorArea _selectorArea;
        [SerializeField] private UnitsContainer _unitsContainer;

        private readonly List<Unit> _selectedUnits = new List<Unit>();

        public void StartSelecting()
        {
            _selectorArea.StartDraw(Input.mousePosition);
        }

        public void StopSelecting()
        {
            TrySelect(GetUnitsHittingInSelectorArea());
            _selectorArea.StopDraw();
        }

        public void Select()
        {
            _selectorArea.Draw(Input.mousePosition);
        }

        private void TrySelect(IEnumerable<Unit> units)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                _selectedUnits.Clear();
                foreach (var selectable in _selectedUnits.Cast<ISelectable>())
                    selectable.OnDeselect();
            }

            foreach (var unit in units)
            {
                if (unit is ISelectable selectable && !_selectedUnits.Contains(unit))
                {
                    selectable.OnSelect();
                    _selectedUnits.Add(unit);
                }
            }
        }

        private IEnumerable<Unit> GetUnitsHittingInSelectorArea()
        {
            var units = _unitsContainer.GetUnitsByCommander<PlayerUnitCommander>();

            return units.Where(unit => unit.IsVisible && _selectorArea.ContainsUnit(unit));
        }
    }
}