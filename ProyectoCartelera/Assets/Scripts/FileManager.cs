using System.IO;

public static class FileManager
{
    public static string LoadJSONFile(string filePath, Enums.TypeOfFile type)
    {
        //switch (type)         // Subtituido por array en CONSTANTS.DIRECTORIES
        //{
        //    case Enums.TypeOfFile.Actors:
        //        filePath = UnityEngine.Application.dataPath + Constants.DIRECTORY_ACTORS + filePath + Constants.JSON_EXTENSION;
        //        break;
        //    case Enums.TypeOfFile.Movies:
        //        filePath = UnityEngine.Application.dataPath + Constants.DIRECTORY_MOVIES + filePath + Constants.JSON_EXTENSION;
        //        break;
        //    case Enums.TypeOfFile.Relation:
        //        filePath = UnityEngine.Application.dataPath + Constants.DIRECTORY_RELATIONS + filePath + Constants.JSON_EXTENSION;
        //        break;
        //}

        filePath = UnityEngine.Application.dataPath + Constants.DIRECTORIES[(int)type] + filePath + Constants.JSON_EXTENSION;
        if(File.Exists(filePath))
        {
            StreamReader data = new StreamReader(filePath);

            return data.ReadToEnd();
        }
        return null;
    }
}
