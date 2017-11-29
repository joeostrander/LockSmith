using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

public static class Extensions
{
    public static string UncPath(this FileInfo fileInfo)
    {
        string filePath = fileInfo.FullName;

        if (filePath.StartsWith(@"\\"))
            return filePath;

        if (new DriveInfo(Path.GetPathRoot(filePath)).DriveType != DriveType.Network)
            return filePath;

        string drivePrefix = Path.GetPathRoot(filePath).Substring(0, 2);
        string uncRoot;

        using (var managementObject = new ManagementObject())
        {
            var managementPath = string.Format("Win32_LogicalDisk='{0}'", drivePrefix);
            managementObject.Path = new ManagementPath(managementPath);
            uncRoot = (string)managementObject["ProviderName"];
        }

        return filePath.Replace(drivePrefix, uncRoot);
    }
}
