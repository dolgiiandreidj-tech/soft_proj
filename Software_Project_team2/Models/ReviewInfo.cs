using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvertimeScraper.Models
{
    /// <summary>
    /// Represents a single course review.
    /// </summary>
    public record ReviewInfo(
        double Rating,
        string Semester,
        string Text
    );
}