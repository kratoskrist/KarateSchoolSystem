using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Represents a karate belt rank.
    /// </summary>
    public class Belt : IReportable
    {
        public int BeltId { get; }
        public string BeltColor { get; }
        public int RankOrder { get; }
        public string Requirements { get; }

        public Belt(
            int beltId,
            string beltColor,
            int rankOrder,
            string requirements)
        {
            if (beltId <= 0)
            {
                throw new ArgumentException("Belt ID must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(beltColor))
            {
                throw new ArgumentException("Belt color is required.");
            }

            if (rankOrder < 0)
            {
                throw new ArgumentException("Rank order cannot be negative.");
            }

            if (string.IsNullOrWhiteSpace(requirements))
            {
                throw new ArgumentException("Belt requirements are required.");
            }

            BeltId = beltId;
            BeltColor = beltColor.Trim();
            RankOrder = rankOrder;
            Requirements = requirements.Trim();
        }

        public string GenerateReport()
        {
            return $"Belt Report: {BeltColor}, Rank {RankOrder}, Requirements: {Requirements}";
        }

        public override string ToString()
        {
            return $"{BeltColor} Belt - Rank {RankOrder}";
        }
    }
}
