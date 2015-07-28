//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Panoptic.Areas.Ops.Models
{
    /// <summary>
    /// Stores information about the status of a machine hard drive.
    /// </summary>
    public class MachineHardDriveStatusModel
    {
        /// <summary>
        /// Gets the amount of space in Gb that is still available.
        /// </summary>
        public double AvailableInGb
        {
            get
            {
                return Size - UsedInGb;
            }
        }

        /// <summary>
        /// Gets or sets the drive letter of the disk.
        /// </summary>
        public string Drive
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the name of the disk.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the percentage of the disk that is in use.
        /// </summary>
        public double PercentageInUse
        {
            get
            {
                return (int)Math.Round(UsedInGb / Size * 100);
            }
        }

        /// <summary>
        /// Gets or sets the size of the disk.
        /// </summary>
        public double Size
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the amount of disk space that is currently in use.
        /// </summary>
        public double UsedInGb
        {
            get;
            set;
        }
    }
}
