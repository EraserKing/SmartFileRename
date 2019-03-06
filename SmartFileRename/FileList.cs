using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFileRename
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
            "eng", "ENG"
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

    public class FileList : IEnumerable, IEnumerable<FileDataInfo>
    {
        private List<FileDataInfo> fileDataInfoList = new List<FileDataInfo>();

        private bool IsCommonPathReady { get; set; } = false;
        private string _commonPath { get; set; } = string.Empty;
        private string CommonPath
        {
            get
            {
                if (!IsCommonPathReady)
                {
                    CalculateCommonPath();
                }
                return _commonPath;
            }
        }
        public bool AutoSort { get; set; } = false;
        public DisplayModeOption DisplayMode { get; set; }

        #region Common Path
        private void BreakCommonPath()
        {
            IsCommonPathReady = false;
        }

        private void CalculateCommonPath()
        {
            IsCommonPathReady = true;

            if (this.fileDataInfoList.Count == 0)
            {
                return;
            }

            string[] pathElements = this.fileDataInfoList[0].FilePath.Split(Path.DirectorySeparatorChar);
            StringBuilder pathBuilder = new StringBuilder();

            for (int i = 0; i < pathElements.Length; i++)
            {
                pathBuilder.Append(pathElements[i]);
                pathBuilder.Append(Path.DirectorySeparatorChar);
                if (this.fileDataInfoList.All(x => x.FilePath.StartsWith(pathBuilder.ToString())))
                {
                    _commonPath = pathBuilder.ToString();
                    continue;
                }
                else
                {
                    return;
                }
            }
        }

        private string CalculateDisplayValue(FileDataInfo fileDataInfo)
        {
            switch (DisplayMode)
            {
                case DisplayModeOption.Full:
                    return fileDataInfo.FilePath;

                case DisplayModeOption.NameOnly:
                    return fileDataInfo.FileFullName;

                case DisplayModeOption.DiscrepancyOnly:
                    return fileDataInfo.FilePath.Substring(CommonPath.Length);

                default:
                    throw new ArgumentOutOfRangeException("Invalid Display Mode");
            }
        }

        #endregion Common Path

        #region Break operations
        public void Add(string item)
        {
            if (File.Exists(item))
            {
                AddFile(item);
            }
            else if (Directory.Exists(item))
            {
                AddFolder(item);
            }
        }

        public void AddVirtualItem(string item)
        {
            if (!Contains(item))
            {
                AddFile(item);
            }
        }

        public void Add(FileDataInfo item) => AddFile(item);

        public void AddRange(IEnumerable<string> collection)
        {
            foreach (string item in collection)
            {
                Add(item);
            }
        }

        public void AddRange(IEnumerable<FileDataInfo> collection) => AddFiles(collection);

        private void AddFile(string item) => AddFile(new FileDataInfo(item));

        private void AddFile(FileDataInfo item)
        {
            if (!Contains(item))
            {
                this.fileDataInfoList.Add(item);
                if (AutoSort)
                {
                    this.Sort();
                }
                BreakCommonPath();
            }
        }

        private void AddFiles(IEnumerable<string> collection) => AddFiles(collection.Select(x => new FileDataInfo(x)));

        private void AddFiles(IEnumerable<FileDataInfo> collection)
        {
            int originalCount = this.fileDataInfoList.Count;
            this.fileDataInfoList.AddRange(collection.Where(x => !Contains(x)));
            if (AutoSort)
            {
                this.Sort();
            }
            if (originalCount != this.fileDataInfoList.Count)
            {
                BreakCommonPath();
            }
        }

        private void AddFolder(string item) => AddFiles(Directory.EnumerateFiles(item));

        public void ClearAll()
        {
            this.fileDataInfoList.Clear();
            BreakCommonPath();
        }

        public void Insert(int index, FileDataInfo item)
        {
            if (!Contains(item))
            {
                this.fileDataInfoList.Insert(index, item);
                if (AutoSort)
                {
                    this.Sort();
                }
                BreakCommonPath();
            }
        }

        public void InsertRange(int index, IEnumerable<FileDataInfo> collection)
        {
            int originalCount = this.fileDataInfoList.Count;
            this.fileDataInfoList.InsertRange(index, collection.Where(x => !Contains(x)));
            if (AutoSort)
            {
                this.Sort();
            }
            if (originalCount != this.fileDataInfoList.Count)
            {
                BreakCommonPath();
            }
        }

        public void InsertRange(int index, IEnumerable<string> collection)
        {
            int originalCount = this.fileDataInfoList.Count;
            foreach (string item in collection.Reverse())
            {
                if (File.Exists(item) )
                {
                    this.fileDataInfoList.Insert(index, new FileDataInfo(item));
                }
                else if (Directory.Exists(item))
                {
                    this.fileDataInfoList.InsertRange(index, Directory.EnumerateFiles(item).Where(x => !Contains(x)).Select(x => new FileDataInfo(x)));
                }
            }
            if (AutoSort)
            {
                this.Sort();
            }
            if (originalCount != this.fileDataInfoList.Count)
            {
                BreakCommonPath();
            }
        }

        public void RemoveAt(int index)
        {
            this.fileDataInfoList.RemoveAt(index);
            BreakCommonPath();
        }

        public void RemoveAt(IEnumerable<int> indexes)
        {
            foreach (int i in indexes.Reverse())
            {
                this.RemoveAt(i);
            }
            BreakCommonPath();
        }

        public int RemoveAll(IEnumerable<string> mustHaveKeys)
        {
            int originalCount = this.fileDataInfoList.Count;
            int result = this.fileDataInfoList.RemoveAll(x => mustHaveKeys.All(y => !x.FilePath.Contains(y)));
            if (originalCount != this.fileDataInfoList.Count)
            {
                BreakCommonPath();
            }
            return result;
        }

        public int RemoveAll(Predicate<FileDataInfo> match)
        {
            int originalCount = this.fileDataInfoList.Count;
            int result = this.fileDataInfoList.RemoveAll(x => match(x));
            if (originalCount != this.fileDataInfoList.Count)
            {
                BreakCommonPath();
            }
            return result;
        }

        #endregion Break operations

        #region Non-break operations
        public void Sort()
        {
            this.fileDataInfoList.Sort();
        }

        public void ClearSelection()
        {
            this.fileDataInfoList.ForEach(x => x.IsSelected = false);
        }

        public void MoveToIndex(int index, IList<int> selectedIndexes)
        {
            List<FileDataInfo> resortedItems = selectedIndexes.Select(x => this.fileDataInfoList[x]).ToList();
            foreach (int i in selectedIndexes.Reverse())
            {
                this.fileDataInfoList.RemoveAt(i);
            }
            index = index - selectedIndexes.Count(x => x < index); // Recalculate the index to insert after the items above the insert position are removed
            this.fileDataInfoList.InsertRange(index, resortedItems);
        }

        public void MoveToBottom(IList<int> selectedIndexes)
        {
            List<FileDataInfo> resortedItems = selectedIndexes.Select(x => this.fileDataInfoList[x]).ToList();
            foreach (int i in selectedIndexes.Reverse())
            {
                this.fileDataInfoList.RemoveAt(i);
            }
            this.fileDataInfoList.AddRange(resortedItems);
        }

        public void MoveUp(IList<int> selectedIndexes)
        {
            ClearSelection();
            int minimumIndex = 0;
            for (int i = 0; i < selectedIndexes.Count; i++)
            {
                int currentPosition = selectedIndexes[i];
                int newPosition = currentPosition - 1;
                if (newPosition < minimumIndex)
                    newPosition = minimumIndex;
                var listEntry = this.fileDataInfoList[currentPosition];
                listEntry.IsSelected = true;
                this.fileDataInfoList.RemoveAt(currentPosition);
                this.fileDataInfoList.Insert(newPosition, listEntry);
                minimumIndex++;
            }
        }

        public void MoveDown(IList<int> selectedIndexes)
        {
            ClearSelection();
            int maximumIndex = this.Count - 1;
            for (int i = selectedIndexes.Count - 1; i >= 0; i--)
            {
                int currentPosition = selectedIndexes[i];
                int newPosition = currentPosition + 1;
                if (newPosition > maximumIndex)
                {
                    newPosition = maximumIndex;
                }
                var listEntry = this.fileDataInfoList[currentPosition];
                listEntry.IsSelected = true;
                this.fileDataInfoList.RemoveAt(currentPosition);
                this.fileDataInfoList.Insert(newPosition, listEntry);
                maximumIndex--;
            }
        }

        public void MoveTop(IList<int> selectedIndexes)
        {
            ClearSelection();
            int removedCount = 0;
            for (int i = selectedIndexes.Count - 1; i >= 0; i--)
            {
                int currentPosition = selectedIndexes[i];
                var listEntry = this.fileDataInfoList[currentPosition + removedCount];
                listEntry.IsSelected = true;
                this.fileDataInfoList.RemoveAt(currentPosition + removedCount);
                this.fileDataInfoList.Insert(0, listEntry);
                removedCount++;
            }
        }

        public void MoveBottom(IList<int> selectedIndexes)
        {
            ClearSelection();
            int removedCount = 0;
            for (int i = 0; i < selectedIndexes.Count; i++)
            {
                int currentPosition = selectedIndexes[i];
                var listEntry = this.fileDataInfoList[currentPosition - removedCount];
                listEntry.IsSelected = true;
                this.fileDataInfoList.RemoveAt(currentPosition - removedCount);
                this.fileDataInfoList.Add(listEntry);
                removedCount++;
            }
        }

        #endregion Non-break operations

        #region Informational methods
        public FileDataInfo this[int i] { get => fileDataInfoList[i]; }

        public int Count { get => fileDataInfoList.Count; }

        public bool Contains(string item)
        {
            return this.fileDataInfoList.Any(x => x.FilePath == item);
        }

        public bool Contains(FileDataInfo item)
        {
            return this.fileDataInfoList.Any(x => x.FilePath == item.FilePath);
        }

        public bool AllFileExists() => this.fileDataInfoList.All(x => x.Exists);

        public bool NoFileExists() => !this.fileDataInfoList.Any(x => x.Exists);

        public string GetDisplayValue(int index) => CalculateDisplayValue(this.fileDataInfoList[index]);

        public string GetFullPath(int index) => this.fileDataInfoList[index].FilePath;

        public IEnumerable<string> GetFullPaths() => this.fileDataInfoList.Select(x => x.FilePath);
        #endregion Informational methods

        #region Interface
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)fileDataInfoList).GetEnumerator();
        }

        IEnumerator<FileDataInfo> IEnumerable<FileDataInfo>.GetEnumerator()
        {
            return ((IEnumerable<FileDataInfo>)fileDataInfoList).GetEnumerator();
        }
        #endregion Interface
    }
}