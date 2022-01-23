using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Classes
{
    public class DigisageFilePresenter
    {

        static Dictionary<string, string> extensionToProgram = new Dictionary<string, string>()
        {
            { "txt", "notepad.exe" },
            { "png", "rundll32.exe"},
            { "wav", "cmd.exe" }

        };
        public static void presentFile(DigisageFile file)
        {
            var extension = file.Name.Split('.')[1].ToLower();

            switch (extension)
            {
                case "txt":
                    DigisageFilePreparer.prepareTextFile(file, extension);
                    break;
                case "png":
                    DigisageFilePreparer.preparePortableNetworkGraphicFile(file, extension);
                    break;
                case "wav":
                    DigisageFilePreparer.prepareWaveFile(file, extension);
                    break;
            }

        }

        private class DigisageFilePreparer
        {
            public static void prepareTextFile(DigisageFile file, string extension)
            {
                File.WriteAllBytes(Directory.GetCurrentDirectory() + @$"\..\..\..\Temp\temp.{extension}", file.Filestream);

                using (Process notepad = new Process())
                {
                    notepad.StartInfo.FileName = extensionToProgram[extension];
                    notepad.StartInfo.Arguments = Directory.GetCurrentDirectory() + @$"\..\..\..\Temp\temp.{extension}";
                    notepad.Start();
                }
            }
            public static void preparePortableNetworkGraphicFile(DigisageFile file, string extension)
            {
                string photoViewer = $@"""C:\Program Files\Windows Photo Viewer\PhotoViewer.dll""";
                string selectedFile = $@"{getTempFolderPath()}Temp\temp.png";
                File.WriteAllBytes(Directory.GetCurrentDirectory() + @$"\..\..\..\Temp\temp.{extension}", file.Filestream);
                
                using (Process notepad = new Process())
                {
                    notepad.StartInfo.FileName = extensionToProgram[extension];
                    notepad.StartInfo.Arguments = $"{photoViewer} ImageView_Fullscreen {selectedFile}";
                    notepad.Start();
                }
            }
            public static void prepareWaveFile(DigisageFile file, string extension)
            {
                string grooveMusic = @"""explorer.exe shell:C:\Program Files\WindowsApps\Microsoft.ZuneMusic_3.6.25021.0_x64__8wekyb3d8bbwe!Microsoft.ZuneMusic""";
                string selectedFile = $@"""{getTempFolderPath()}Temp\temp.{extension}""";
                File.WriteAllBytes(Directory.GetCurrentDirectory() + @$"\..\..\..\Temp\temp.{extension}", file.Filestream);

                using (Process cmd = new Process())
                {
                    cmd.StartInfo.FileName = extensionToProgram[extension];
                    cmd.StartInfo.Arguments = $@"/c start {grooveMusic} {selectedFile}";
                    cmd.Start();
                }
            }

            private static string getTempFolderPath()
            {
                var result = Directory.GetCurrentDirectory().Split('\\');
                var targetPath = "";

                for (int i = 0; i < result.Length - 3; i++)
                {
                    targetPath += result[i] + '\\';
                }

                return targetPath;
            }
        }
    }
}
