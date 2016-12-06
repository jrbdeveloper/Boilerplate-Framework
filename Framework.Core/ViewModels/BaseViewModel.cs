using System;

namespace Framework.Core.ViewModels
{
    public abstract class BaseViewModel
    {
        #region Properties
        public string CreatedBy { get; set; }

        public string UpdateBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
        #endregion

        #region Methods
        protected string DetermineSubjectTransferStatus(string context)
        {
            switch (context)
            {
                case "C":
                    return "Complete";

                case "I":
                    return "Incomplete";

                case "N":
                    return "No";
            }

            return string.Empty;
        }

        protected string DetermineYesNoResponse(string context)
        {
            switch (context)
            {
                case "Y":
                    return "Yes";

                case "N":
                    return "No";

                default:
                    return "No";
            }
        }

        protected string DetermineYesNoResponse(int context)
        {
            switch (context)
            {
                case 1:
                    return "Yes";

                case 0:
                    return "No";

                default:
                    return "No";
            }
        }

        public string BuildVersion { get; set; }
        #endregion
    }
}
