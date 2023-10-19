using System.IO;
using System.Threading.Tasks;

namespace NECS.Extensions
{
    public static class FileInfoExtensions
    {

        public static void Rewind(this Stream stream) => stream.Position = 0;


        public static FileStream CreateStream(
          this FileInfo file,
          FileMode mode,
          FileAccess access,
          FileShare share = FileShare.ReadWrite,
          int bufferSize = 4096,
          FileOptions options = FileOptions.Asynchronous | FileOptions.SequentialScan
        ) => new FileStream(file.FullName, mode, access, share, bufferSize, options);
    }
}
