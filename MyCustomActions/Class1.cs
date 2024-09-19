using System;
using System.IO;
using System.Reflection;
using Microsoft.Deployment.WindowsInstaller;
using static System.Collections.Specialized.BitVector32;

public class CustomActions
{
    [CustomAction]
    public static ActionResult MyCustomAction(Session session)
    {
        try
        {
            var interopFileName = "SQLite.Interop.dll";
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.GetName().Name;
            var env = Environment.Is64BitProcess ? "x64" : "x86";
            var resource = $"{assemblyName}.CA.{env}.{interopFileName}";
            var assemblyDirectory = Path.GetDirectoryName(assembly.Location);
            var dir = Directory.CreateDirectory($@"{assemblyDirectory}\{env}");
            var interopFilePath = Path.Combine(dir.FullName, interopFileName);

            using (var stream = assembly.GetManifestResourceStream(resource))
            {
                if (stream == null)
                {
                    session.Log("Error: Unable to find the embedded resource.");
                    return ActionResult.Failure;
                }
                using (var fs = new FileStream(interopFilePath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fs);
                }
            }

            // Continue with the rest of the work
            // Your SQLite code here

            return ActionResult.Success;
        }
        catch (Exception ex)
        {
            session.Log($"Error: {ex.Message}");
            return ActionResult.Failure;
        }
    }
}