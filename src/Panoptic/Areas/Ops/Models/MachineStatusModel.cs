//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Panoptic.Areas.Ops.Models
{
    /// <summary>
    /// Stores information about the status of a machine.
    /// </summary>
    public class MachineStatusModel
    {
        /// <summary>
        /// Gets or sets the collection containing the CPU usage history.
        /// </summary>
        public int[] CpuHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the percentage of CPU that is currently in use.
        /// </summary>
        public int CpuPercentage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection that contains information about all the
        /// machine hard drives and their status.
        /// </summary>
        public MachineHardDriveStatusModel[] Disks
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the amount of unused memory in Gb for the current machine.
        /// </summary>
        public double MemoryFreeInGb
        {
            get
            {
                return MemoryTotalInGb - MemoryInUseInGb;
            }
        }

        /// <summary>
        /// Gets or sets the amount of memory that is in use in Gb for the
        /// current machine.
        /// </summary>
        public double MemoryInUseInGb
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the amount of memory used as a percentage of the total amount of
        /// memory available for the current machine.
        /// </summary>
        public int MemoryInUsePercentage
        {
            get
            {
                return (int)Math.Round(MemoryInUseInGb / MemoryTotalInGb * 100);
            }
        }

        /// <summary>
        /// Gets or sets the total amount of memory available in Gb for the current machine.
        /// </summary>
        public double MemoryTotalInGb
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the notification text.
        /// </summary>
        public string Notification
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the status text.
        /// </summary>
        public ServiceStatus Status
        {
            get;
            set;
        }
    }
}
