using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


    public class OpenFiles
    {
        public enum PERMISSIONS
        {
            PERM_FILE_NONE = 0,
            PERM_FILE_READ = 1,
            PERM_FILE_WRITE = 2,
            PERM_FILE_CREATE = 4,
            PERM_FILE_EXECUTE = 8
        }

        [Flags()]
        public enum PermFile
        {
            // file network permissions 
            Read = 0x1,
            // user has read access 
            Write = 0x2,
            // user has write access 
            Create = 0x4,
            // user has create access 
            Perm08 = 0x8,
            // ? 
            Perm10 = 0x10,
            // ? 
            Perm20 = 0x20
            // ? 
        }

        public enum NERR
        {
            /// <summary>
            /// Operation was a success.
            /// </summary>
            NERR_Success = 0,
            /// <summary>
            /// More data available to read. dderror getting all data.
            /// </summary>
            ERROR_MORE_DATA = 234,
            /// <summary>
            /// Network browsers not available.
            /// </summary>
            ERROR_NO_BROWSER_SERVERS_FOUND = 6118,
            /// <summary>
            /// LEVEL specified is not valid for this call.
            /// </summary>
            ERROR_INVALID_LEVEL = 124,
            /// <summary>
            /// Security context does not have permission to make this call.
            /// </summary>
            ERROR_ACCESS_DENIED = 5,
            /// <summary>
            /// Parameter was incorrect.
            /// </summary>
            ERROR_INVALID_PARAMETER = 87,
            /// <summary>
            /// Out of memory.
            /// </summary>
            ERROR_NOT_ENOUGH_MEMORY = 8,
            /// <summary>
            /// Unable to contact resource. Connection timed out.
            /// </summary>
            ERROR_NETWORK_BUSY = 54,
            /// <summary>
            /// Network Path not found.
            /// </summary>
            ERROR_BAD_NETPATH = 53,
            /// <summary>
            /// No available network connection to make call.
            /// </summary>
            ERROR_NO_NETWORK = 1222,
            /// <summary>
            /// Pointer is not valid.
            /// </summary>
            ERROR_INVALID_HANDLE_STATE = 1609,
            /// <summary>
            /// Extended Error.
            /// </summary>
            ERROR_EXTENDED_ERROR = 1208,
            /// <summary>
            /// Base.
            /// </summary>
            NERR_BASE = 2100,
            /// <summary>
            /// Unknown Directory.
            /// </summary>
            NERR_UnknownDevDir = (NERR_BASE + 16),
            /// <summary>
            /// Duplicate Share already exists on server.
            /// </summary>
            NERR_DuplicateShare = (NERR_BASE + 18),
            /// <summary>
            /// Memory allocation was to small.
            /// </summary>
            NERR_BufTooSmall = (NERR_BASE + 23)
        }

        public struct FILE_INFO_3
        {
            public int fi3_Id;
            public PermFile fi3_Permissions;
            public int fi3_NumLocks;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string fi3_PathName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string fi3_UserName;
        }

        [DllImport("netapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int NetFileClose(
        string servername,
        int id);

        /// <summary>
        /// Sets the last-error code for the calling thread.
        /// </summary>
        /// <param name="dwErrorCode">The last-error code for the thread.</param>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void SetLastError(uint dwErrorCode);

        [DllImport("netapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int NetFileEnum(
         string servername,
         string basepath,
         string username,
         int level,
         ref IntPtr bufptr,
         int prefmaxlen,
         out int entriesread,
         out int totalentries,
         IntPtr resume_handle
        );

        [DllImport("netapi32.dll", EntryPoint = "NetServerEnum")]
        public static extern int NetServerEnum(
            [MarshalAs(UnmanagedType.LPWStr)] string servername,
            int level,
            out IntPtr bufptr,
            int prefmaxlen,
            out int entriesread,
            out int totalentries,
            int servertype,
            [MarshalAs(UnmanagedType.LPWStr)] string domain,
            IntPtr resume_handle);

        [DllImport("netapi32.dll", EntryPoint = "NetApiBufferFree")]
        public static extern int NetApiBufferFree(IntPtr buffer);


        public const int MAX_PREFERRED_LENGTH = -1; // originally 0

    }

