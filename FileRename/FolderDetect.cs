using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FileRename
{
    public class FolderDetect
    {
        public Regex EpisodeNumberWithoutBracket = new Regex(@"\b\d{0,2}(\.\d)?(v\d)?\b", RegexOptions.Compiled);
        public Regex EpisodeNumberWithBracket = new Regex(@"\[\d{0,2}(\.\d)?(v\d)?\]", RegexOptions.Compiled);
        public Regex EpisodeNumberJapaneseType = new Regex(@"第\d{0,2}(\.\d)?(v\d)?話", RegexOptions.Compiled);

        public static List<string> ListVideoInFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new IOException();
            }

            List<string> fileList = new List<string>();
            fileList.AddRange(Directory.EnumerateFiles("*.mkv"));
            fileList.AddRange(Directory.EnumerateFiles("*.mp4"));
            fileList.AddRange(Directory.EnumerateFiles("*.avi"));
            fileList.AddRange(Directory.EnumerateFiles("*.wmv"));

            return fileList;
        }

        public static List<string> ListSubtitleInFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new IOException();
            }

            List<string> fileList = new List<string>();
            fileList.AddRange(Directory.EnumerateFiles("*.ass"));
            fileList.AddRange(Directory.EnumerateFiles("*.ssa"));
            fileList.AddRange(Directory.EnumerateFiles("*.srt"));

            return fileList;
        }

        public static void DetermineFolderType(List<string> videoFiles)
        {
            foreach (string videoFileName in videoFiles)
            {

            }
        }

        public EnumFileNameMethod AnalyzeFile(string fileName)
        {
            if (EpisodeNumberJapaneseType.IsMatch(fileName))
            {
                // [DVD] 魔法少女隊アルス 第25話 「疑惑／バラバラな心」 [704x396 WMV9].wmv
                return EnumFileNameMethod.JapaneseRaw;
            }

            // Over two [ and ]
            if (fileName.Count(x => x == '[') > 2 && fileName.Count(x => x == ']') > 2 && fileName.Count(x => x == '[') == fileName.Count(x => x == ']'))
            {
                // If all ] follows [
                bool rightBracketAfterLeftBracket = !fileName.Where((t, i) => t == '[' && fileName[i + 1] == ']').Any();

                if (rightBracketAfterLeftBracket)
                {
                    // [DmzJ][Eve_no_Jikan][04v2][DVDRip][x264_AC3][F51F8ADC].mkv
                    return EnumFileNameMethod.ChineseGroup;
                }

                if (EpisodeNumberWithBracket.IsMatch(fileName))
                {
                    // [VCB-Studio] Darker Than Black-Kuro no Keiyakusha [03][Hi10p_1080p][x264_flac].mkv
                    return EnumFileNameMethod.ChineseGroupWithoutBrackets;
                }

                if (EpisodeNumberWithoutBracket.IsMatch(fileName))
                {
                    // [Yousei-raws] Baka to Test to Shoukanjuu 03 [BDrip 1920x1080 x264 FLAC].mkv
                    return EnumFileNameMethod.EnglishGroupType;
                }
            }

            if (fileName.All(x => x != '[') && fileName.All(x => x != ']'))
            {
                if (EpisodeNumberWithoutBracket.IsMatch(fileName))
                {
                    return EnumFileNameMethod.Simple;
                }
            }
            
            return EnumFileNameMethod.Unknown;
        }
        /*
        public FileNameType SplitFileName(string fileName, EnumFileNameMethod fileNameMethod)
        {
            
        }

        public FileNameType SplitFileNameJapaneseRaw(string fileName)
        {
            FileNameType fileNameType = new FileNameType();
            fileNameType.FileName = fileName;

        }
        */
        public class FileNameType
        {
            public string FileName;

            public string SubtitleGroup;

            public string VideoName;

            public string EpisodeNumber;

            public string EpisodeName;

            public string Format;

            public string CRC;

            public EnumFileNameMethod FileNameMethod;

            public EnumEpisodeType EpisodeType;
        }

        public enum EnumEpisodeType
        {
            MainEpisode,
            Special,
            Other,
        }

        public enum EnumFileNameMethod
        {
            ChineseGroup,
            ChineseGroupWithoutBrackets,
            EnglishGroupType,
            JapaneseRaw,
            Simple,
            Unknown,
        }
    }
}
