﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Classes.DataClasses
{
    public class Stat : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int max;
        private int current;
        private int _base;

        public int Max
        {
            get { return max; }
            set 
            {
                max = value;
            }
        }
        public int Current
        {
            get { return current; }
            set 
            { 
                current = value; 
                if(current <= 0)
                {
                    Empty?.Invoke();
                }
                OnPropertyChanged();
            }
        }

        public int Base
        {
            get { return _base; }
            set
            {
                _base = value;
            }
        }

        public void Reset()
        {
            Current = max;
        }

        public Stat(int current)
        {
            this.current = current;
            max = current;
            _base = current;
        }

        public delegate void Event();
        public event Event Empty;
        
    }
}
