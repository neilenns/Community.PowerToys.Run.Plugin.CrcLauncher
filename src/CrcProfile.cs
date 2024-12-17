// <copyright file="CrcProfile.cs" company="Neil Enns">
// Copyright (c) Neil Enns. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Community.PowerToys.Run.Plugin.CrcLauncher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a CRC profile.
    /// </summary>
    public class CrcProfile
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the FilePath.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the last used date.
        /// </summary>
        public DateTime LastUsedAt { get; set; }

        /// <summary>
        /// Gets or sets the ARTCC ID.
        /// </summary>
        public string ArtccId { get; set; }

        /// <summary>
        /// Gets or sets the last used environment.
        /// </summary>
        public string LastUsedEnvironment { get; set; }

        /// <summary>
        /// Gets or sets the last used position ID.
        /// </summary>
        public string LastUsedPositionId { get; set; }

        /// <summary>
        /// Gets or sets the network rating.
        /// </summary>
        public string NetworkRating { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the controller info.
        /// </summary>
        public object ControllerInfo { get; set; }
    }
}
