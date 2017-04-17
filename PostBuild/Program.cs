using System;
using System.IO;
using System.Security.Cryptography;
using System.Reflection;

namespace PostBuild
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Too few arguments.");
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("File {0} not found!", args[0]);

                return;
            }

            MD5 md5 = null;
            //SHA1 sha1 = null;
            FileStream fileStream = null;
            StreamWriter writer = null;
            try
            {
                AssemblyName assembly = AssemblyName.GetAssemblyName(args[0]);

                string path = Path.GetDirectoryName(args[0]);

                if (assembly.ProcessorArchitecture == ProcessorArchitecture.Amd64)
                {
                    path = Path.Combine(path, "BCS_Software64.exe");
                }
                else if (assembly.ProcessorArchitecture == ProcessorArchitecture.X86)
                {
                    path = Path.Combine(path, "BCS_Software32.exe");
                }
                else
                {
                    throw new InvalidProgramException();
                }

                if(File.Exists(path))
                    File.Delete(path);

                File.Copy(args[0], path);

                md5 = MD5.Create();
                //sha1 = SHA1.Create();

                fileStream = File.Open(path, FileMode.Open);

                string md5Hash = BitConverter.ToString(md5.ComputeHash(fileStream)).Replace("-", string.Empty).ToLower();
                //string sha1Hash = BitConverter.ToString(sha1.ComputeHash(fileStream)).Replace("-", string.Empty).ToLower();

                Console.WriteLine("md5:  {0}", md5Hash);
                //Console.WriteLine("sha1: {0}", sha1Hash);

                writer = new StreamWriter(File.Open(Path.ChangeExtension(path, "md5"), FileMode.Create));

                writer.Write("md5: {0}", md5Hash);

                writer.Dispose();

                writer = new StreamWriter(File.Open(Path.ChangeExtension(path, "sha1"), FileMode.Create));

                //writer.Write("sha1: {0}", sha1Hash);

                writer.Dispose();

                writer = new StreamWriter(File.Open(Path.Combine(Path.GetDirectoryName(path), "version.info"), FileMode.Create));

                writer.WriteLine(assembly.Version.ToString());

                Console.WriteLine("Version: {0}", assembly.Version.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //sha1?.Dispose();
                md5?.Dispose();
                fileStream?.Dispose();
                writer?.Dispose();
            }
        }
    }
}
