﻿// Copyright 2013-2018 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests.Shared.Types
{
    public partial class MagickGeometryTests
    {
        [TestClass]
        public class TheToStringMethod
        {
            [TestMethod]
            public void ShouldOnlyReturnWidthAndHeight()
            {
                var geometry = new MagickGeometry(10, 5);

                Assert.AreEqual("10x5", geometry.ToString());
            }

            [TestMethod]
            public void ShouldReturnCorrectValueForPositiveValues()
            {
                var geometry = new MagickGeometry(1, 2, 10, 20);

                Assert.AreEqual("10x20+1+2", geometry.ToString());
            }

            [TestMethod]
            public void ShouldReturnCorrectValueForNegativeValues()
            {
                var geometry = new MagickGeometry(-1, -2, 20, 10);

                Assert.AreEqual("20x10-1-2", geometry.ToString());
            }

            [TestMethod]
            public void ShouldReturnCorrectValueForIgnoreAspectRatio()
            {
                var geometry = new MagickGeometry(5, 10);
                geometry.IgnoreAspectRatio = true;

                Assert.AreEqual("5x10!", geometry.ToString());
            }

            [TestMethod]
            public void ShouldSetLess()
            {
                var geometry = new MagickGeometry(2, 1, 10, 5);
                geometry.Less = true;

                Assert.AreEqual("10x5+2+1<", geometry.ToString());
            }

            [TestMethod]
            public void ShouldSetGreater()
            {
                var geometry = new MagickGeometry(5, 10);
                geometry.Greater = true;

                Assert.AreEqual(true, geometry.ToString());
            }

            [TestMethod]
            public void ShouldSetFillArea()
            {
                var geometry = new MagickGeometry(10, 15);
                geometry.FillArea = true;

                Assert.AreEqual("10x15^", geometry.ToString());
            }

            [TestMethod]
            public void ShouldSetLimitPixels()
            {
                var geometry = new MagickGeometry(10, 0);
                geometry.LimitPixels = true;

                Assert.AreEqual("10@", geometry.ToString());
            }

            [TestMethod]
            public void ShouldSetGreaterAndIsPercentage()
            {
                var geometry = new MagickGeometry("50%x0>");

                Assert.AreEqual(0, geometry.X);
                Assert.AreEqual(0, geometry.Y);
                Assert.AreEqual(50, geometry.Width);
                Assert.AreEqual(0, geometry.Height);
                Assert.AreEqual(true, geometry.IsPercentage);
                Assert.AreEqual(true, geometry.Greater);
            }
        }
    }
}
