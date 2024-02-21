using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace FileWatcherEx
{
    /// <summary>
    /// Interface around .NET FileSystemWatcher to be able to replace it with a fake implementation
    /// </summary>
    public interface IFileSystemWatcherWrapper
    {
        string Path { get; set; }

#if NET6_0_OR_GREATER
        Collection<string> Filters { get; }
#endif
#if NETSTANDARD2_0_OR_GREATER
        string Filter { get; set; }
#endif
        bool IncludeSubdirectories { get; set; }
        bool EnableRaisingEvents { get; set; }
        NotifyFilters NotifyFilter { get; set; }

        event FileSystemEventHandler Created;
        event FileSystemEventHandler Deleted;
        event FileSystemEventHandler Changed;
        event RenamedEventHandler Renamed;
        event ErrorEventHandler Error;
    
        int InternalBufferSize { get; set; }

        public ISynchronizeInvoke SynchronizingObject { get; set; }

        void Dispose();
    }

    /// <summary>
    /// Production implementation of  IFileSystemWrapper interface.
    /// Backed by the existing FileSystemWatcher
    /// </summary>
    public class FileSystemWatcherWrapper : FileSystemWatcher, IFileSystemWatcherWrapper
    {
        // intentionally empty
    }

}
