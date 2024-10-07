namespace MediaBrowser.Model.Library;

/// <summary>
/// A data volume.
/// </summary>
/// <param name="Identifier">The system identifier of a volume, could be for example /dev/sdx or C:\. </param>
/// <param name="Mountpoint">Where on the system is the volume mounter.</param>
public record Volume(string Identifier, string Mountpoint);
