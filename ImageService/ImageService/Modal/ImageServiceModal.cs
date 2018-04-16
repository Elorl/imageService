﻿using ImageService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ImageService.Modal
{
    public class ImageServiceModal : IImageServiceModal
    {
        #region Members
        private string m_OutputFolder;            // The Output Folder
        private int m_thumbnailSize;              // The Size Of The Thumbnail Size
        #endregion
        
        //properties
        public string OutputFolder
        {
            get
            {
                return this.m_OutputFolder;
            }
            set
            {
                this.m_OutputFolder = value;
            }
        }
        public int ThumbnailSize
        {
            get
            {
                return this.m_thumbnailSize;
            }
            set
            {
                this.m_thumbnailSize = value;
            }
        }

        public string AddFile(string path, out bool result)
        {
            string year = String.Empty, month= String.Empty, newPath = String.Empty;
            DateTime createdTimeOfPath = new DateTime();
            //try to get the created time of the file.
            try
            {
                createdTimeOfPath = File.GetCreationTimeUtc(path);
                year = createdTimeOfPath.Year.ToString();
                month = createdTimeOfPath.Month.ToString();
                newPath = createDir(year, month);
                //Thread.Sleep(500);
                newPath = newPath + Path.GetFileName(path);
                int i = 1;
                while(File.Exists(newPath))
                {
                    string newPathWithNum = newPath + Path.GetFileNameWithoutExtension(newPath) + i + Path.GetExtension(newPath);
                    File.Move(newPath, newPathWithNum);
                    ++i;
                };
                Thread.Sleep(10);
                File.Move(path, newPath);
            } catch(Exception exeption)
            {
                result = false;
                throw exeption;
            }
            string returnMsg;
            returnMsg = " File " + Path.GetFileName(path) + " moved to " + newPath;
            result = true;
            return returnMsg;
        }

        public string createDir(string year, string month)
        {
            try
            {
                DirectoryInfo outPutFold = Directory.CreateDirectory(m_OutputFolder);
                outPutFold.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                Directory.CreateDirectory(m_OutputFolder + "\\" + year);
                Directory.CreateDirectory(m_OutputFolder + "\\" + year + "\\" + month);
            } catch(Exception exeption)
            {
                throw exeption;
            }
            return m_OutputFolder + "\\" + year + "\\" + month + "\\";
        }
       
    }
}
