using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartFileRename
{
    public class RenameInfo
    {
        public string MovieFileName { get; set; }
        public string SubtitleGroup { get; set; }
        public string Language { get; set; }
        public string Extension { get; set; }
    }

    public class RenameTemplate
    {
        private string template { get; set; }

        private Dictionary<string, RenameTemplateElement> templateElements = new Dictionary<string, RenameTemplateElement>();

        private bool IsInitialized { get; set; } = false;

        public enum ValidElementEntry
        {
            MovieFileName,
            SubtitleGroup,
            Language,
            Extension
        }

        public RenameTemplate(string template)
        {
            this.template = template;
        }

        public void InitializeTemplate()
        {
            bool validate = true;
            foreach (Match match in Regex.Matches(template, @"{\.?\??\w+}"))
            {
                string entryName = match.Value.Substring(1, match.Value.Length - 2);
                bool startWithDot = entryName.StartsWith(".");
                entryName = startWithDot ? entryName.TrimFirstChar() : entryName;

                bool required = !entryName.StartsWith("?");
                entryName = required ? entryName : entryName.TrimFirstChar();

                bool currentEntryValid = Enum.TryParse(entryName, out ValidElementEntry entry);
                validate = validate && currentEntryValid;

                // TODO: Duplicated entry?
                templateElements.Add(match.Value, new RenameTemplateElement
                {
                    Entry = entry,
                    StartWithDot = startWithDot,
                    Required = required
                });
            }

            if (!validate)
            {
                throw new ArgumentException($"The current template {template} is not valid");
            }

            IsInitialized = true;
        }

        public string FormatTemplate(RenameInfo renameInfo)
        {
            if (!IsInitialized)
            {
                InitializeTemplate();
            }

            string newName = template;

            foreach (var templateElement in templateElements)
            {
                string elementKey = templateElement.Key;
                RenameTemplateElement element = templateElement.Value;

                string value = null;
                switch (element.Entry)
                {
                    case ValidElementEntry.Extension:
                        value = renameInfo.Extension;
                        break;

                    case ValidElementEntry.Language:
                        value = renameInfo.Language;
                        break;

                    case ValidElementEntry.MovieFileName:
                        value = renameInfo.MovieFileName;
                        break;

                    case ValidElementEntry.SubtitleGroup:
                        value = renameInfo.SubtitleGroup;
                        break;
                }

                if (element.Required && string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"The template cannot be formated since required element {elementKey} is not specified");
                }

                if (!element.Required && string.IsNullOrEmpty(value))
                {
                    value = string.Empty;
                }
                else
                {
                    if (element.StartWithDot)
                    {
                        value = value.Insert(0, ".");
                    }
                }

                newName = newName.Replace(elementKey, value);
            }
            return newName;
        }

        public class RenameTemplateElement
        {
            public ValidElementEntry Entry { get; set; }
            public bool StartWithDot { get; set; }
            public bool Required { get; set; }
        }
    }


    public static class StringExtension
    {
        public static string TrimFirstChar(this string original) => original.Substring(1);
    }
}
