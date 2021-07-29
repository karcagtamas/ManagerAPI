using System;
using System.Reflection;
using System.Runtime.Loader;

namespace ManagerAPI.Backend
{
    /// <summary>
    /// Custom Assembly loader
    /// </summary>
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        /// <summary>
        /// Load unmanaged lib
        /// </summary>
        /// <param name="absolutePath">Absolute path</param>
        /// <returns>IntPtr of dll</returns>
        public IntPtr LoadUnmanagedLibrary(string absolutePath)
        {
            return this.LoadUnmanagedDll(absolutePath);
        }

        /// <summary>
        /// Load unmanaged dll
        /// </summary>
        /// <param name="unmanagedDllName">unmanaged Dll name</param>
        /// <returns>IntPtr of dll</returns>
        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            return this.LoadUnmanagedDllFromPath(unmanagedDllName);
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="assemblyName">assembly name</param>
        /// <returns>Assembly</returns>
        protected override Assembly Load(AssemblyName assemblyName)
        {
            throw new NotImplementedException();
        }
    }
}
