using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.Eventing;

namespace Microsoft.WindowsAzure.MobileServices.Files.Sync
{
    internal sealed class DefaultFileSyncTriggerFactory : IFileSyncTriggerFactory
    {
        private readonly bool autoUpdateRecords;
        private readonly IMobileServiceClient mobileServiceClient;

        public DefaultFileSyncTriggerFactory(IMobileServiceClient mobileServiceClient, bool autoUpdateParentRecords)
        {
            if (mobileServiceClient == null)
            {
                throw new ArgumentNullException("mobileServiceClient");
            }

            this.mobileServiceClient = mobileServiceClient;
            this.autoUpdateRecords = autoUpdateParentRecords;
        }

        public IList<IFileSyncTrigger> CreateTriggers(IFileSyncContext fileSyncContext)
        {
            return new List<IFileSyncTrigger> { new EntityData.EntityDataFileSyncTrigger(fileSyncContext, this.mobileServiceClient, this.autoUpdateRecords) };
        }
    }
}
