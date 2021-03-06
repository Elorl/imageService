﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    /// <summary>
    /// A single Image object. used in gallery and also as a model of a the view of single image.
    /// </summary>
    public class Image
    {
        #region Properties
        /// <summary>
        /// representing all image info.
        /// </summary>

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Month")]
        public string Month { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Year")]
        public string Year { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ImagePath")]
        public string ImagePath { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ImageAbsPath")]
        public string ImageAbsPath { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ThumbnailPath")]
        public string ThumbnailPath { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ThumbnailAbsPath")]
        public string ThumbnailAbsPath { get; set; }
        #endregion

        #region constructor
        public Image(string name, string month, string year, string imageRelativePath, string imageAbsPath,  string thumbnailRelativePath, string thumbnailAbsPath)
        {
            Name = name;
            Month = month;
            Year = year;
            ImagePath = imageRelativePath;
            ImageAbsPath = imageAbsPath;
            ThumbnailPath = thumbnailRelativePath;
            ThumbnailAbsPath = thumbnailAbsPath;
        }
        #endregion

    }
}