﻿//  Copyright 2014 Craig Courtney
//    
//  Helios is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  Helios is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace GadrocsWorkshop.Helios.ProfileEditor.UndoEvents
{
    public class DeleteMonitorUndoEvent : IUndoItem
    {
        private HeliosProfile _profile;
        private Monitor _monitor;
        private int _index;

        public DeleteMonitorUndoEvent(HeliosProfile profile, Monitor monitor, int index)
        {
            _profile = profile;
            _monitor = monitor;
            _index = index;
        }

        public void Undo()
        {
            if (_index < _profile.Monitors.Count)
            {
                _profile.Monitors.Insert(_index, _monitor);
            }
            else
            {
                _profile.Monitors.Add(_monitor);
            }
        }

        public void Do()
        {
            _profile.Monitors.RemoveAt(_index);
        }
    }
}
