﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AluPlast.Models;
using AluPlast.Models.Validators;

namespace AluPlast.UnitTests
{
    [TestClass]
    public class VehicleValidatorTests
    {
        [TestMethod]
        public void DriverNameTest()
        {
            var vehicle = new Vehicle { VehicleId = 1, DriverName = "" };

            var validator = new VehicleValidator();

            var results = validator.Validate(vehicle);

            Assert.IsFalse(results.IsValid);
        }
    }
}
