using System.Security;

namespace Narod
{
    namespace SteamGameFinder
    {
        public class SteamGameLocator
        {
            private static readonly string steamRegPath = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Valve\\Steam"; // not compatible with 32-bit

            private bool? steamInstalled = null;
            private string? steamInstallPath = null;
            private List<string> steamLibraryList = new List<string>();
            private List<GameStruct> steamGameList = new List<GameStruct>();

            /// <summary>
            /// A struct holding properties on games
            /// </summary>
            public struct GameStruct
            {
                public string steamGameID;
                public string steamGameName;
                public string steamGameLocation;
            }

            /// <summary>
            /// Returns a bool of whether Steam is installed or not.
            /// </summary>
            /// <returns>
            /// True = Steam is installed. False = Steam is not installed.
            /// </returns>
            /// <exception cref="SecurityException">Thrown if unsufficient permissions to check Steam install.</exception>
            public bool getIsSteamInstalled() // function to return a boolean of whether steam is installed or not
            {
                if (steamInstalled != null) { return (bool)steamInstalled; } // if this information is already stored, let's use that instead
                try // try statement, this could fail due to registry errors, or if the user does not have admin perms
                {
                    string? steamInstallPath = RegistryHandler.safeGetRegistryKey("InstallPath", steamRegPath); // uses a safe way of getting the registry key
                    if (steamInstallPath == null) { steamInstalled = false; return (bool)steamInstalled; } // if the safe registry returner is null, then steam is not installed
                    if (Directory.Exists(steamInstallPath) == false) { steamInstalled = false; return (bool)steamInstalled; } // if the folder location in the registry key is not on the system, then steam is not installed
                }
                catch (ArgumentNullException) { steamInstalled = false; return (bool)steamInstalled; } // unlikely to occur, but could be raised by safe registry returner, will return false as it would mean failed to find reg key
                catch (SecurityException sx) { throw sx; } // security exception, means user needs more perms. will throw this exception back to the program to resolve
                steamInstalled = true;
                return (bool)steamInstalled; // if other 'guard if statements' are passed, then steam is accepted to be installed
            }

            /// <summary>
            /// Returns a string of the location of where steam is installed.
            /// </summary>
            /// <returns>
            /// string - the full file path of where Steam is installed.
            /// </returns>
            /// <exception cref="DirectoryNotFoundException">Thrown if Steam is not installed.</exception>
            /// <exception cref="SecurityException">Thrown if unsufficient permissions to check Steam install path.</exception>
            public string getSteamInstallLocation()
            {
                if (steamInstallPath != null && Directory.Exists(steamInstallPath)) { return steamInstallPath; } // if this information is already stored, let's use that instead
                try // try statement, this could fail due to registry errors, or if the user does not have admin perms
                {
                    steamInstallPath = RegistryHandler.safeGetRegistryKey("InstallPath", steamRegPath); // uses a safe way of getting the registry key
                    if (steamInstallPath == null) { throw new DirectoryNotFoundException(); } // if the safe registry returner is null, then steam is not installed. throw directory not found exception
                    if (Directory.Exists(steamInstallPath) == false) { throw new DirectoryNotFoundException(); } // if the folder location in the registry key is not on the system, then steam is not installed. throw directory not found exception
                }
                catch (ArgumentNullException) { throw new DirectoryNotFoundException(); } // unlikely to occur, but could be raised by safe registry returner, will return false as it would mean failed to find reg key
                catch (SecurityException sx) { throw sx; } // security exception, means user needs more perms. will throw this exception back to the program to resolve
                return steamInstallPath; // if other 'guard if statements' are passed, then steam is accepted to be installed
            }

            /// <summary>
            /// Returns a list of strings with the locations of Steam library folders.
            /// </summary>
            /// <returns>
            /// List of strings with the full file location of the library folder.
            /// </returns>
            public List<String> getSteamLibraryLocations()
            {
                if (steamLibraryList.Count != 0) { return steamLibraryList; } // if this information is already stored, let's use that instead

                if(steamInstallPath == null) { getSteamInstallLocation(); } // if the steam install path has not already been fetched, fetch it

                StreamReader libraryVDFReader = File.OpenText(steamInstallPath + "\\steamapps\\libraryfolders.vdf");
                string? lineReader = libraryVDFReader.ReadLine();
                bool continueRead = true;
                while (continueRead)
                {
                    while (lineReader?.Contains("path") == false)
                    {
                        try
                        {
                            lineReader = libraryVDFReader.ReadLine(); // waiting to read in a line that looks like: "path"      "C:\location\to\library\folder"
                            if(lineReader == null) { break; }
                        }
                        catch (Exception) // End of file exception
                        {
                            continueRead = false; // stop reading
                            break; // break this loop
                        }
                    }
                    if(lineReader == null) { break; }
                    string cleanLine = lineReader.Replace("\"path\"", ""); // we then clean this up by removing the path part, leaving us with:         "C:\location\to\library\folder"
                    cleanLine = cleanLine.Split('"')[1]; // we then remove the leading spaces and quotes to get: C:\location\to\library\folder"
                    cleanLine = cleanLine.Replace("\"", ""); // we then remove the last quote to get: C:\location\to\library\folder

                    lineReader = libraryVDFReader.ReadLine(); // prevents it from getting stuck on the same library folder

                    if (Directory.Exists(cleanLine)) { steamLibraryList.Add(cleanLine); } // if the directory exists on the disk, then add it to the library list
                }
                return steamLibraryList;
            }

            /// <summary>
            /// Returns the install path of a game, by it's Steam install folder.
            /// </summary>
            /// <param name="gameName">The name of the folder Steam installs the game to.</param>
            /// <returns>
            /// GameStruct - useful properties being steamGameName and steamGameLocation.
            /// </returns>
            /// <exception cref="DirectoryNotFoundException">Thrown if the game is not installed.</exception>
            public GameStruct getGameInfoByFolder(string gameName)
            {
                if (steamGameList.Count != 0)
                {
                    foreach (GameStruct steamGame in steamGameList)
                    {
                        if (steamGame.steamGameName == gameName) { return steamGame; } // if game is already stored in our list, just return that instead
                    }
                }
                GameStruct gameInfo = new GameStruct();
                gameInfo.steamGameName = gameName;
                gameInfo.steamGameID = "0"; // not used

                if (steamLibraryList.Count == 0) { getSteamLibraryLocations(); } // if steam library locations are not set-up, fetch them

                foreach (string libraryFolder in steamLibraryList)
                {
                    string checkFolder = libraryFolder + "\\steamapps\\common\\" + gameName;

                    if (Directory.Exists(checkFolder)) { gameInfo.steamGameLocation = checkFolder; break; }
                }

                if (gameInfo.steamGameLocation != null) { return gameInfo; }

                throw new DirectoryNotFoundException(); // throw an exception to alert user that game is not installed
            }
        }
    }
}