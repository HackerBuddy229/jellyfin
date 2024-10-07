using System.Collections.Generic;

namespace MediaBrowser.Model.Dto;

/// <summary>
/// A data transfer object to represent a storage volume.
/// </summary>
public class VolumeDto
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VolumeDto"/> class.
    /// </summary>
    /// <param name="volumeIdentifier">The identifier of the volume.</param>
    public VolumeDto(string volumeIdentifier)
    {
        VolumeIdentifier = volumeIdentifier;
        LibraryIdentifiers = new List<string>();
    }

    /// <summary>
    /// Gets or sets the identifier of storage volume, on linux most often /dev/sdx.
    /// </summary>
    public string VolumeIdentifier { get; set; }

    /// <summary>
    /// Gets or sets the space remaining on the specific volume.
    /// </summary>
    public long SpaceRemaining { get; set; }

    /// <summary>
    /// Gets or sets the list of LibraryIdentifiers stored on the volume.
    /// </summary>
    public IList<string> LibraryIdentifiers { get; set; }
}
