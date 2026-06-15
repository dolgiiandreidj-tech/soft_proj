using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvertimeScraper.Models
{
    /// <summary>
    /// Represents a single lecture from 내 강의.
    /// </summary>
    public record LectureInfo(
        string Name,
        string Professor,
        string Url,
        int LectureId = 0,
        string Code = "",
        string SubjectId = ""   // Everytime XML id attribute = KLAS selectSubj (e.g. U202610969I030023)
    );
}