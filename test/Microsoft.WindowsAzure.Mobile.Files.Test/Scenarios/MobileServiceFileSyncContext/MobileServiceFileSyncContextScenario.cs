using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Eventing;
using Microsoft.WindowsAzure.MobileServices.Files;
using Microsoft.WindowsAzure.MobileServices.Files.Metadata;
using Microsoft.WindowsAzure.MobileServices.Files.Operations;
using Microsoft.WindowsAzure.MobileServices.Files.Sync;
using Moq;

namespace Microsoft.WindowsAzure.Mobile.Files.Test.Scenarios
{
    public abstract class MobileServiceFileSyncContextScenario
    {
        private readonly Mock<IFileMetadataStore> fileMetadataStore;
        private readonly Mock<IFileOperationQueue> fileOperationsQueue;
        private readonly Mock<IMobileServiceClient> mobileServiceClientMock;
        private readonly Mock<IFileSyncHandler> syncHandler;
        private readonly Mock<IFileSyncTriggerFactory> triggerFactory;
        private readonly MobileServiceFileSyncContext syncContext;
        private readonly Mock<IMobileServiceEventManager> eventManager;

        public MobileServiceFileSyncContextScenario()
        {
            this.mobileServiceClientMock = new Mock<IMobileServiceClient>();
            this.fileMetadataStore = new Mock<IFileMetadataStore>();
            this.fileOperationsQueue = new Mock<IFileOperationQueue>();
            this.triggerFactory = new Mock<IFileSyncTriggerFactory>();
            this.syncHandler = new Mock<IFileSyncHandler>();
            this.eventManager = new Mock<IMobileServiceEventManager>();

            this.mobileServiceClientMock.Setup(m => m.EventManager)
                .Returns(this.eventManager.Object);

            this.syncContext = new MobileServiceFileSyncContext(mobileServiceClientMock.Object, fileMetadataStore.Object,
                fileOperationsQueue.Object, triggerFactory.Object, syncHandler.Object);

        }

        public Mock<IFileOperationQueue> FileOperationQueueMock => fileOperationsQueue;

        public Mock<IMobileServiceEventManager> EventManagerMock => eventManager;

        public Mock<IFileMetadataStore> FileMetadataStoreMock => fileMetadataStore;

        public MobileServiceFileSyncContext SyncContext => syncContext;
    }
}
