using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SmartFileRename
{
    public struct RenameOptions
    {
        public FileList SubtitleFileList;
        public FileList MovieFileList;

        public string Template { get; set; }

        public bool SpecifySubtitleGroup { get; set; }
        public string SubtitleGroup { get; set; }

        public bool SpecifyLanguage { get; set; }
        public string Language { get; set; }

        public bool SpecifyExtension { get; set; }
        public string Extension { get; set; }

        public bool MoveToMovieFolder;
    }

    public class RenameOperations
    {
        public static FileList GenerateRenameList(RenameOptions renameOptions)
        {
            FileList finalFileList = new FileList();

            if (renameOptions.SubtitleFileList.Count == 0 || renameOptions.MovieFileList.Count == 0)
            {
                throw new InvalidOperationException("Both list cannot be blank");
            }

            if (renameOptions.SubtitleFileList.Count % renameOptions.MovieFileList.Count != 0 || renameOptions.SubtitleFileList.Count < renameOptions.MovieFileList.Count)
            {
                throw new InvalidOperationException("File count error");
            }

            RenameTemplate renameTemplate = new RenameTemplate(renameOptions.Template);
            renameTemplate.InitializeTemplate();

            // Create list
            int ratio = renameOptions.SubtitleFileList.Count / renameOptions.MovieFileList.Count;
            for (int i = 0; i < renameOptions.MovieFileList.Count; i++)
            {
                FileDataInfo movieFile = renameOptions.MovieFileList[i];
                for (int j = 0; j < ratio; j++)
                {
                    FileDataInfo subtitleFile = renameOptions.SubtitleFileList[i * ratio + j];
                    RenameInfo renameInfo = new RenameInfo()
                    {
                        MovieFileName = movieFile.FileName,
                        SubtitleGroup = renameOptions.SpecifySubtitleGroup ? renameOptions.SubtitleGroup : subtitleFile.ParseSubtitleGroup(),
                        Language = renameOptions.SpecifyLanguage ? renameOptions.Language : subtitleFile.ParseLanguage(),
                        Extension = renameOptions.SpecifyExtension ? renameOptions.Extension : subtitleFile.FileExtension
                    };

                    // Set folder to movie folder or original folder
                    string finalFilePath =
                        Path.Combine(
                            renameOptions.MoveToMovieFolder ? movieFile.FileFolder : subtitleFile.FileFolder,
                            renameTemplate.FormatTemplate(renameInfo));

                    if (finalFileList.Contains(finalFilePath))
                    {
                        throw new InvalidOperationException($"Duplicated final file path {subtitleFile.FileFullName} TO {finalFilePath}");
                    }
                    finalFileList.AddVirtualItem(finalFilePath);
                }
            }

            return finalFileList;
        }

        public static List<string> RenameFiles(FileList oldNames, FileList newNames)
        {
            List<string> errorList = new List<string>();
            if (oldNames.Count != newNames.Count)
            {
                throw new InvalidOperationException("File count doesn't match");
            }

            if (!oldNames.AllFileExists())
            {
                throw new InvalidOperationException($"At least one file cannot be found:\n{string.Join("\n", oldNames.Where(x => !x.Exists))}");
            }

            if (!newNames.NoFileExists())
            {
                throw new InvalidOperationException($"At least one new file is already existing:\n{string.Join("\n", newNames.Where(x => x.Exists))}");
            }

            for (int i = 0; i < oldNames.Count; i++)
            {
                string oldName = oldNames[i].FilePath;
                string newName = newNames[i].FilePath;

                try
                {
                    File.Move(oldName, newName);
                }
                catch (Exception)
                {
                    errorList.Add(oldName);
                }
            }
            return errorList;
        }
    }
}
