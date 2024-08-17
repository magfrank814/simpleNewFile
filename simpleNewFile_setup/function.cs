using System.IO;
using System.Reflection;
using System.IO.Compression;

namespace simpleNewFile_setup
{
    public class function
    {
        
        public static void ExtractResourceToFile(string resourceName, string filePath)  
        {  
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))  
            using (FileStream fileStream = File.Create(filePath))  
            {  
                stream?.CopyTo(fileStream);  
            }


            
        }  
        
        
        
        public static void ExtractZipFile(string zipFilePath, string extractPath)  
        {  
            
            
  
            using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))  
            {  
                foreach (ZipArchiveEntry entry in archive.Entries)  
                {  
                    string destinationPath = Path.Combine(extractPath, entry.FullName);  
  
                    // 如果解压出来的文件是目录，则创建目录  
                    if (entry.FullName.EndsWith("/"))  
                    {  
                        Directory.CreateDirectory(destinationPath);  
                    }  
                    else  
                    {  
                        // 确保目录存在  
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));  
  
                        // 解压文件，如果文件已存在则覆盖  
                        entry.ExtractToFile(destinationPath, true); // 第二个参数为true表示覆盖已存在的文件  
                    }  
                }  
            }  
        }

        public static void ExtractResFile(string resFileName, string outputFile)
        {
            BufferedStream inStream = null;
            FileStream outStream = null;
            try
            {
                Assembly asm = Assembly.GetExecutingAssembly(); //读取嵌入式资源
                inStream = new BufferedStream(asm.GetManifestResourceStream(resFileName));
                outStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write);

                byte[] buffer = new byte[1024];
                int length;

                while ((length = inStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    outStream.Write(buffer, 0, length);
                }
                outStream.Flush();
            }
            finally
            {
                if (outStream != null)
                {
                    outStream.Close();
                }
                if (inStream != null)
                {
                    inStream.Close();
                }
            }




















        }





    }
}