using IntegrationSpecs.TestHelpers;
using NUnit.Framework;
using SpecsFor.Configuration;
using System;

namespace IntegrationSpecs
{
    [SetUpFixture]
    public class SpecsForConfig : SpecsForConfiguration
    {
        public SpecsForConfig()
        {
            AppDomain.CurrentDomain.SetData("isUsedForSpecs", true);
            WhenTesting<INeedDatabase>().EnrichWith<EFDatabaseCreator>();
            WhenTesting<INeedDatabase>().EnrichWith<TransactionScopeWrapper>();
            WhenTesting<INeedDatabase>().EnrichWith<EFContextFactory>();
        }
    }
}
