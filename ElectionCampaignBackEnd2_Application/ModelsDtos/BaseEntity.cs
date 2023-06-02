using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Globalization;
using ElectionCampaignBackEnd2_Domain.Common;
using System.ComponentModel;

namespace ElectionCampaignBackEnd2_Application.ModelsDtos
{
    public class BaseEntity
    {

        public string? CreatedBy { get; set; }

        //public DateTime? DateCreated { get; set; }
        public string? ModifiedBy { get; set; }
        //public DateTime? DateModified { get; set; }


        // Date Convert Utc to localDate and Time

        private DateTime? _dateCreated;
        public DateTime? DateCreated
        {
            get
            {
                if (_dateCreated != null)
                {
                    DateTime iKnowThisIsUtc = (DateTime)_dateCreated;
                    DateTime runtimeKnowsThisIsUtc = DateTime.SpecifyKind(
                        iKnowThisIsUtc,
                        DateTimeKind.Utc);
                    DateTime localVersion = runtimeKnowsThisIsUtc.ToLocalTime();

                    _dateCreated = localVersion;
                    return _dateCreated;
                }
                else
                {
                    return null;
                }

            }
            set
            {

                if (value?.Kind == DateTimeKind.Utc)
                    _dateCreated = DateTime.UtcNow;


                #region comment code DateTime

                //else if (value.Kind == DateTimeKind.Local)
                //    _dateCreated = value.ToUniversalTime();
                //else
                //    _dateCreated = DateTime.SpecifyKind(value, DateTimeKind.Utc);


                //_dateCreated=DateTime.Now;

                //if (_dateCreated != null)
                //{
                //    DateTime iKnowThisIsUtc = _dateCreated;
                //    DateTime runtimeKnowsThisIsUtc = DateTime.SpecifyKind(
                //        iKnowThisIsUtc,
                //        DateTimeKind.Utc);
                //    DateTime localVersion = runtimeKnowsThisIsUtc.ToLocalTime();

                //    _dateCreated = localVersion;

                //}
                #endregion
            }
        }


        private DateTime? _dateModified;
        public DateTime? DateModified
        {
            get
            {
                if (_dateModified != null)
                {
                    DateTime iKnowThisIsUtc = (DateTime)_dateModified;
                    DateTime runtimeKnowsThisIsUtc = DateTime.SpecifyKind(
                        iKnowThisIsUtc,
                        DateTimeKind.Utc);
                    DateTime localVersion = runtimeKnowsThisIsUtc.ToLocalTime();

                    _dateModified = localVersion;
                    return _dateModified;
                }
                else
                {
                    return null;
                }

            }
            set
            {
                if (value?.Kind == DateTimeKind.Utc)
                    _dateModified = DateTime.UtcNow;
                else if (value?.Kind == DateTimeKind.Local)
                    _dateModified = DateTime.UtcNow;

            }
        }

    }


}
