﻿
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Gui.models;
using infrastructure;


namespace Gui.LogVM
{
    public class LogVM 
    {

        #region members
        private LogModel logModel;
        #endregion

        #region Properties
        public ObservableCollection<LogItem> LogsCollection
        {
            get { return this.logModel.LogsCollection; }
            set => throw new NotImplementedException();
        }
        #endregion

        public LogVM()
        {
            this.logModel = new LogModel();
        }
    }
}
