using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionCampaignBackEnd2_Domain.Common
{
    public static class ConvertExtensions
    {
        public static DateTime SafeUniversal(this DateTime inTime)
        {
            return (DateTimeKind.Unspecified == inTime.Kind)
                ? new DateTime(inTime.Ticks, DateTimeKind.Utc)
                : inTime.ToLocalTime();
        }


        public static DateTime GetTimeInEasternStandardTime(DateTime dateCreated)
        {
            if (dateCreated != null)
            {
                DateTime iKnowThisIsUtc = dateCreated;
                DateTime runtimeKnowsThisIsUtc = DateTime.SpecifyKind(
                    iKnowThisIsUtc,
                    DateTimeKind.Utc);
                DateTime localVersion = runtimeKnowsThisIsUtc.ToLocalTime();

                return localVersion;

            }
            return dateCreated;
        }

        public static DateTime ToKindUtc(this DateTime value)
        {
            return KindUtc(value);
        }
        public static DateTime? ToKindUtc(this DateTime? value)
        {
            return KindUtc(value);
        }
        public static DateTime ToKindLocal(this DateTime value)
        {
            return KindLocal(value);
        }
        public static DateTime? ToKindLocal(this DateTime? value)
        {
            return KindLocal(value);
        }
        public static DateTime SpecifyKind(this DateTime value, DateTimeKind kind)
        {
            if (value.Kind != kind)
            {
                return DateTime.SpecifyKind(value, kind);
            }
            return value;
        }
        public static DateTime? SpecifyKind(this DateTime? value, DateTimeKind kind)
        {
            if (value.HasValue)
            {
                return DateTime.SpecifyKind(value.Value, kind);
            }
            return value;
        }
        public static DateTime KindUtc(DateTime value)
        {
            if (value.Kind == DateTimeKind.Unspecified)
            {
                return DateTime.SpecifyKind(value, DateTimeKind.Utc);
            }
            else if (value.Kind == DateTimeKind.Local)
            {
                return value.ToUniversalTime();
            }
            return value;
        }
        public static DateTime? KindUtc(DateTime? value)
        {
            if (value.HasValue)
            {
                return KindUtc(value.Value);
            }
            return value;
        }
        public static DateTime KindLocal(DateTime value)
        {
            if (value.Kind == DateTimeKind.Unspecified)
            {
                return DateTime.SpecifyKind(value, DateTimeKind.Local);
            }
            else if (value.Kind == DateTimeKind.Utc)
            {
                return value.ToLocalTime();
            }
            return value;
        }
        public static DateTime? KindLocal(DateTime? value)
        {
            if (value.HasValue)
            {
                return KindLocal(value.Value);
            }
            return value;
        }

        public static DateTime AsUTC(this DateTime dt)
        {
            switch (dt.Kind)
            {
                case DateTimeKind.Unspecified:
                    return new DateTime(dt.Ticks, DateTimeKind.Utc);
                case DateTimeKind.Utc:
                    return dt;
                case DateTimeKind.Local:
                    return dt.ToUniversalTime();
                default:
                    throw new NotSupportedException($"The provided {dt.Kind} did not exist when delivering this model, please update to latest version to support this date time type");
            }
        }

    }
}
