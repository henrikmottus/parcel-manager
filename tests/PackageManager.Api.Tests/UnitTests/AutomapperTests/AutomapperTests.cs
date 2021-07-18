using AutoMapper;
using NUnit.Framework;
using ParcelManager.API.Automapper.Profiles;
using ParcelManager.Core.Entities;
using ParcelManager.DTO.Shipments;
using System;

namespace PackageManager.API.Tests
{
    public class AutomapperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldPassConfigurationValidation()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<BaseProfile>());
            config.AssertConfigurationIsValid();
        }
    }
}