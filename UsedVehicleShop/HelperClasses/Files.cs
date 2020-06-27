using System.IO;

namespace UsedVehicleShop.HelperClasses
{
    class Files
    {
        public static readonly string DataDir = "Data";
        public static readonly string VehicleFile = "vehicles.csv";
        private static char sep = Path.DirectorySeparatorChar;
        private static string pathDataDirRelease = "data";

        public static string VehicleFullPath { private set; get; }

        public static string AdjustPath(string[] args)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string path = "";

            switch (args.Length)
            {
                case 0:
                    goto default;
                case 1:
                    if (args[0] != "-r")
                    {
                        goto default;
                    }
                    path = pathDataDirRelease + sep;
                    break;
                case 2:
                    if (args[0] != "-r")
                    {
                        goto default;
                    }
                    pathDataDirRelease = args[1];
                    path = pathDataDirRelease + sep;
                    break;
                default:
                    string pathToProject = new DirectoryInfo(currentPath).Parent.Parent.FullName;
                    path = pathToProject + sep + DataDir + sep;
                    break;
            }

            return path;
        }

        public static string AdjustPath()
        {
            string currentPath = Directory.GetCurrentDirectory();
            string path = "";

            string pathToProject = new DirectoryInfo(currentPath).Parent.Parent.FullName;
            path = pathToProject + sep + DataDir + sep;



            VehicleFullPath = path + VehicleFile;

            return path;
        }
    }

}

