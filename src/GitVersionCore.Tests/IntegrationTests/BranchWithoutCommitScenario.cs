﻿using GitTools.Testing;
using GitVersionCore.Tests;
using LibGit2Sharp;
using NUnit.Framework;

[TestFixture]
public class BranchWithoutCommitScenario
{
    [Test]
    public void CanTakeVersionFromReleaseBranch()
    {
        using (var fixture = new EmptyRepositoryFixture())
        {
            fixture.Repository.MakeATaggedCommit("1.0.3");
            var commit = fixture.Repository.MakeACommit();
            fixture.Repository.CreateBranch("release-4.0.123");
            fixture.Checkout(commit.Sha);

            fixture.AssertFullSemver("4.0.123-beta.1+0", fixture.Repository, commit.Sha, false, "release-4.0.123");
        }
    }
}