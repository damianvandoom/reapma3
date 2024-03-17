using System.IO;

namespace ReaperToGrandma3.Classes
{
    public static class Helpers
    {
        public static void CheckFolderExistsAndCreate(string folderLocation)
        {
            if (!Directory.Exists(folderLocation))
            {
                Directory.CreateDirectory(folderLocation);
            }
        }

    }
}
