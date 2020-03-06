﻿using FluentAssertions;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Toggl.Networking.Tests.Integration.BaseTests
{
    public abstract class AuthenticatedGetAllEndpointBaseTests<T> : AuthenticatedGetEndpointBaseTests<List<T>>
    {
        [Fact, LogTestInfo]
        public async Task ReturnsAnEmptyListWhenThereIsNoTimeEntryOnTheServer()
        {
            var (togglClient, user) = await SetupTestUser();

            var timeEntries = await CallEndpointWith(togglClient);

            timeEntries.Should().NotBeNull();
            timeEntries.Should().BeEmpty();
        }

        [Fact, LogTestInfo]
        public override async Task FetchesTheExactSameEntityWhenFetchingTwice()
        {
            var (validApi, user) = await SetupTestUser();

            var firstEntity = await CallEndpointWith(validApi);
            await Task.Delay(500).ConfigureAwait(false);
            var secondEntity = await CallEndpointWith(validApi);

            firstEntity.Should().BeEquivalentTo(secondEntity);
        }
    }
}
