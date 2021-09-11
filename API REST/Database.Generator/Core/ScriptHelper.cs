using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;
using System.Linq;

namespace Database.Generator.Core
{
    public static class ScriptHelper
    {
        public static void RunScripts(MigrationBuilder migrationBuilder)
        {
            DirectoryInfo _viewsDirectory;
            DirectoryInfo _storedProcedureDirectory;

            string _baseFolderScripts = @"Database.Generator\";

            var rootFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"));

            _viewsDirectory = new DirectoryInfo($"{rootFolder}{_baseFolderScripts}").GetDirectories("Views").First();
            _storedProcedureDirectory = new DirectoryInfo($"{rootFolder}{_baseFolderScripts}").GetDirectories("StoredProcedure").First();

            var sqlFiles = _viewsDirectory.GetFiles("*.sql");
            var allFiles = sqlFiles.Union(_storedProcedureDirectory.GetFiles("*.sql"));

            foreach (var archivoSql in allFiles)
            {
                migrationBuilder.Sql(File.ReadAllText(archivoSql.FullName));
            }
        }
    }
}