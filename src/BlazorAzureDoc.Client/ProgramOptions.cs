using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAzureDoc.Client
{
    public class ProgramOptions
    {
        public ProgramOptions()
        {
            RepositoryName = "MicrosoftDocs";
        }

        public string RepositoryName { get; set; }
    }
}
