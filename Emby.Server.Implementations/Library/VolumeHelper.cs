using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using DiscUtils.Raw;
using MediaBrowser.Model.Library;

namespace Emby.Server.Implementations.Library;

/// <summary>
/// Contains methods meant to help handle and identify system storage volumes.
/// </summary>
public static class VolumeHelper
{
    /// <summary>
    /// Gets the storage volume for an absolute path.
    /// </summary>
    /// <param name="path">An absolute path located inside a storage volume.</param>
    /// <returns>A storage volume system identifier and its current mountpoint.</returns>
    public static Volume VolumeFromPath(string path)
    {
        // check for windows

        if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            if (Path.IsPathRooted(path))
            {
                return new Volume(Path.GetPathRoot(path)!, Path.GetPathRoot(path)!);
            }

            throw new ArgumentException("Path is not absolute");
        }

        // else unix

        // get all system volumes
        var systemVolumes = File.ReadAllText("/proc/mounts")
            .Split("\n").Select(line => line.Split(" "))
            .Where(pars => pars[0].Contains("/dev/", StringComparison.InvariantCulture))
            .Select(pars => new Volume(pars[0], pars[1])).ToList();

        // find mount points matching the path and sort by depth.
        return systemVolumes.Where(vol => path.StartsWith(vol.Mountpoint, StringComparison.InvariantCulture))
            .OrderByDescending(vol => vol.Mountpoint.Split().Count(sym => sym == "/")).First();
    }
}
