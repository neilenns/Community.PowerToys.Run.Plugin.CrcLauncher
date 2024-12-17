// <copyright file="ProfileManager.cs" company="Neil Enns">
// Copyright (c) Neil Enns. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Community.PowerToys.Run.Plugin.Community.PowerToys.Run.Plugin.CrcLauncher
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using Wox.Plugin.Logger;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    /// <summary>
    /// Maintains a list of CRC profiles.
    /// </summary>
    public static class ProfileManager
    {
        private static readonly List<CrcProfile> Profiles = [];

        /// <summary>
        /// Gets the list of profiles.
        /// </summary>
        public static IReadOnlyList<CrcProfile> CrcProfiles => Profiles;

        /// <summary>
        /// Returns a list of profiles that match the specified query.
        /// </summary>
        /// <param name="query">The text to search for.</param>
        /// <returns>The list of matching profiles. If query is null or empty all profiles are returned. If no profiles match an empty list is returned.</returns>
        public static IEnumerable<CrcProfile> GetMatchingProfiles(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return CrcProfiles;
            }

            return CrcProfiles.Where(profile =>
                profile.Name != null && profile.Name.Contains(query, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Loads the profiles from disk.
        /// </summary>
        public static void LoadProfiles()
        {
            var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CRC", "Profiles");
            Profiles.Clear();

            if (!Directory.Exists(folderPath))
            {
                Log.Error("Profile folder not found.", typeof(ProfileManager));
                return;
            }

            var jsonFiles = Directory.GetFiles(folderPath, "*.json");

            foreach (var file in jsonFiles)
            {
                try
                {
                    string jsonContent = File.ReadAllText(file);
                    CrcProfile profile = JsonSerializer.Deserialize<CrcProfile>(jsonContent, options: new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    });

                    if (profile != null)
                    {
                        Log.Info($"Loaded profile {profile.Name} from {file}", typeof(ProfileManager));
                        profile.FilePath = file;
                        Profiles.Add(profile);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error($"Error loading profiles: {ex.Message}", typeof(ProfileManager));
                }
            }

            Log.Info($"Loaded {Profiles.Count} profiles.", typeof(ProfileManager));
        }
    }
}
