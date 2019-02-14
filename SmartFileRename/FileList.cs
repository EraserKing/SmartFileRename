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

        public string ParseLanguage()
        {
            foreach (string language in availableLanguages)
            {
                if (FileFullName.Contains($".{language}.") || FileFullName.Contains($"[{language}]"))
                {
                    return language;
                }
            }
            return null;
        }

        public FileDataInfo(string filePath)
        {
            FilePath = filePath;
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
        private string CommonPath { get; set; } = string.Empty;
        public bool AutoSort { get; set; } = false;
        public DisplayModeOption DisplayMode { get; set; }

        #region Common Path
        private void BreakCommonPath()
        {
            IsCommonPathReady = false;
        }

        private void CalculateCommonPath()
        {
            if (IsCommonPathReady)
            {
                return;
            }

            IsCommonPathReady = true;

            if (this.Count == 0)
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
                    CommonPath = pathBuilder.ToString();
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
                    CalculateCommonPath();
                    return fileDataInfo.FilePath.Substring(CommonPath.Length);

                default:
                    throw new ArgumentOutOfRangeException("Invalid Display Mode");
            }
        }

        #endregion Common Path

        #region Break operations
        public void Add(string item) => Add(new FileDataInfo(item));

        public void Add(FileDataInfo item)
        {
            if (!Contains(item))
            {
                this.fileDataInfoList.Add(item);
                if (AutoSort)
                {
                    this.fileDataInfoList.Sort();
                }
                BreakCommonPath();
            }
        }

        public void AddRange(IEnumerable<string> collection) => AddRange(collection.Select(x => new FileDataInfo(x)));

        public void AddRange(IEnumerable<FileDataInfo> collection)
        {
            this.fileDataInfoList.AddRange(collection.Where(x => !Contains(x)));
            if (AutoSort)
            {
                this.fileDataInfoList.Sort();
            }
            BreakCommonPath();
        }

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
                BreakCommonPath();
            }
        }

        public void InsertRange(int index, IEnumerable<FileDataInfo> collection)
        {
            this.fileDataInfoList.InsertRange(index, collection.Where(x => !Contains(x)));
            BreakCommonPath();
        }

        public void RemoveAt(int index)
        {
            this.fileDataInfoList.RemoveAt(index);
            BreakCommonPath();
        }

        public void RemoveAt(IList<int> indexes)
        {
            for (int i = indexes.Count - 1; i >= 0; i--)
            {
                this.RemoveAt(indexes[i]);
            }
            BreakCommonPath();
        }

        public int RemoveAll(IEnumerable<string> mustHaveKeys)
        {
            int result = this.fileDataInfoList.RemoveAll(x => mustHaveKeys.All(y => !x.FilePath.Contains(y)));
            BreakCommonPath();
            return result;
        }

        #endregion Break operations

        #region Non-break operations
        public void ClearSelection()
        {
            this.fileDataInfoList.ForEach(x => x.IsSelected = false);
        }

        public void MoveToIndex(int index, IList<int> selectedIndexes)
        {
            List<FileDataInfo> resortedItems = new List<FileDataInfo>();
            resortedItems.AddRange(selectedIndexes.Select(x => this.fileDataInfoList[x]));
            foreach (int i in selectedIndexes.Reverse())
            {
                this.fileDataInfoList.RemoveAt(i);
            }
            index = index - selectedIndexes.Count(x => x < index); // Recalculate the index to insert after the items above the insert position are removed
            this.fileDataInfoList.InsertRange(index, resortedItems);
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