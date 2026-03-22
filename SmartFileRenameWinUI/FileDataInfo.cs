using System;
using System.IO;

namespace SmartFileRenameWinUI
{
    public enum DisplayModeOption
    {
        Full,
        NameOnly,
        DiscrepancyOnly
    }

    public class FileDataInfo : IComparable
    {
        public enum FileTypeEnum
        {
            Movie,
            Subtitle,
            Audio,
            Unknown
        }

        private static string[] availableLanguages = new string[]
        {
            "gb", "GB",
            "sc", "SC",
            "chs", "CHS",
            "big5", "BIG5",
            "tc", "TC",
            "cht", "CHT",
            "jp", "JP",
            "jpn", "JPN",
            "en", "EN",
            "eng", "ENG",
            "uni_gb", "uni_big5"
        };

        public string FilePath { get; }

        public string FileFolder => Path.GetDirectoryName(FilePath);
        public string FileFullName => Path.GetFileName(FilePath);
        public string FileName => Path.GetFileNameWithoutExtension(FilePath);
        public string FileExtension => Path.GetExtension(FilePath).TrimStart('.');
        public bool Exists => File.Exists(FilePath);
        public FileTypeEnum FileType { get; private set; }

        public override string ToString() => FilePath;

        public static string ParseLanguage(string fileFullName)
        {
            foreach (string language in availableLanguages)
            {
                if (fileFullName.Contains($".{language}.") || fileFullName.Contains($"[{language}]"))
                {
                    return language;
                }
            }
            return null;
        }

        public string ParseLanguage() => ParseLanguage(this.FileFullName);

        public static string ParseSubtitleGroup(string fileFullName)
        {
            return null;
        }

        public string ParseSubtitleGroup() => ParseSubtitleGroup(this.FileFullName);

        public static FileTypeEnum ParseFileType(string filePath)
        {
            string extension = Path.GetExtension(filePath).TrimStart('.');
            FileTypeEnum type;

            if (extension == "ass" || extension == "ssa" || extension == "srt" || extension == "idx" || extension == "sub")
            {
                type = FileTypeEnum.Subtitle;
            }

            else if (extension == "mkv" || extension == "mp4" || extension == "avi" || extension == "wmv")
            {
                type = FileTypeEnum.Movie;
            }

            else if (extension == "mp3" || extension == "flac" || extension == "ape" || extension == "aac" || extension == "mka")
            {
                type = FileTypeEnum.Audio;
            }

            else
            {
                type = FileTypeEnum.Unknown;
            }
            return type;
        }

        public FileTypeEnum ParseFileType() => ParseFileType(this.FileFullName);

        public FileDataInfo(string filePath)
        {
            FilePath = filePath;
            FileType = ParseFileType(filePath);
        }
        public int CompareTo(object obj)
        {
            return FilePath.CompareTo(((FileDataInfo)obj).FilePath);
        }

        public bool IsSelected = false;
    }
}
