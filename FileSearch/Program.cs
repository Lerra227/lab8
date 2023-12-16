
using System.IO.Compression;
using System.Runtime.CompilerServices;

Console.WriteLine("Enter the path:");
string path = Console.ReadLine();
Console.WriteLine("Enter the file name:");
string fileName = Console.ReadLine();

string filePath = ProcessDirectory(path, fileName);

using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
{
    StreamReader str = new StreamReader(fs);
    string data = str.ReadToEnd();
    string[] dataArray = data.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

    for (int i = 0; i < dataArray.Length; i++)
    {
        Console.WriteLine(dataArray[i]);

    }
}

Console.WriteLine("Want yoy to compress the file to .gz? (Y/N)");

string key = Console.ReadLine();
if (key == "Y" || key == "y") 
{
    CompressFile(filePath);
} 

 static void CompressFile(string path)
{
    FileStream sourceFile = File.OpenRead(path);
    FileStream destinationFile = File.Create(path + ".gz");
    byte[] buffer = new byte[sourceFile.Length];
    sourceFile.Read(buffer, 0, buffer.Length);
    using (GZipStream output = new GZipStream(destinationFile,
        CompressionMode.Compress))
    {
        Console.WriteLine("Compressing {0} to {1}.", sourceFile.Name,
            destinationFile.Name, false);
        output.Write(buffer, 0, buffer.Length);
    }
    // Close the files.
    sourceFile.Close();
    destinationFile.Close();
}
//string zipFileName = Path.GetDirectoryName(filePath);
//string zipPath = zipFileName + @"\result.zip";

//ZipFile.CreateFromDirectory(zipFileName, zipPath);
string ProcessDirectory(string targetDirectory, string FileName)
{
    if (!Directory.Exists(targetDirectory)) 
    { throw new Exception("This directory doesnt exist."); 
    }
    string[] result = Directory.GetFiles(targetDirectory, FileName, SearchOption.AllDirectories);
    if (result.Length == 0) { throw new Exception("File not found."); }
    if (result.Length > 1) { throw new Exception("There are several files with this name." +
        "\nPlease, enter uniqe file name"); }

    return result[0];

} 