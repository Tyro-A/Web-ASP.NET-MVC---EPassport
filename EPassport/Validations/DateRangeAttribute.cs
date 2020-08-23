using System;
using System.ComponentModel.DataAnnotations;

namespace EPassport.Validations
{
    public class DateRangeAttribute :RangeAttribute
    {
        public DateRangeAttribute(string minimumValue) 
            : base(typeof(DateTime), minimumValue, DateTime.Now.ToLongDateString())
        {

        }
    }
}