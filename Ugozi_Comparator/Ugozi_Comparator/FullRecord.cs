using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ugozi_Comparator
{
    public class FullRecord
    {
        public string UBI_ID { get; set; }   
        public string UBI_Name { get; set; }
        public string Description { get; set; }
        public string SourceOfThreat { get; set; }
        public string ObjectOfImpact { get; set; }
        public bool PrivacyViolation { get; set; }
        public bool IntegrityViolation { get; set; }
        public bool AccessViolation { get; set; }

        public FullRecord() { }

        public FullRecord(string id, string name, string description, string source, string objectOfImpact, bool privacyViolation, bool integrityViolation, bool accessViolation)
        {
            UBI_ID = id;
            UBI_Name = name;
            Description = description;
            SourceOfThreat = source;
            ObjectOfImpact = objectOfImpact;
            PrivacyViolation = privacyViolation;
            IntegrityViolation = integrityViolation;
            AccessViolation = accessViolation;
        }

        public static explicit operator SmallRecord (FullRecord a)
        {
            return new SmallRecord() { UBI_ID = "УБИ." + a.UBI_ID, UBI_Name = a.UBI_Name };
        }
    }
}
