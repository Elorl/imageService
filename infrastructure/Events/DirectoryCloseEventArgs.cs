﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Events
{
    public class DirectoryCloseEventArgs : EventArgs
    {
        #region properties
        public string DirectoryPath { get; set; }
        public string Message { get; set; }             // The Message That goes to the logger
        #endregion
        /// <summary>
        /// constructor.
        /// </summary>
        /// <param name="dirPath">path</param>
        /// <param name="message">message</param>
        public DirectoryCloseEventArgs(string dirPath, string message)
        {
            DirectoryPath = dirPath;                    // Setting the Directory Name
            Message = message;                          // Storing the String
        }

    }
}
