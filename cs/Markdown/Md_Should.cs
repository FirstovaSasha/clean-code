﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    [TestFixture]
    public class Md_Should
    {

        [TestCase("", "<p></p>")]
        [TestCase("Текст, _текст текст_ текст", "<p>Текст, <em>текст текст</em> текст</p>")]
        [TestCase("__текст текст__ текст", "<p><strong>текст текст</strong> текст</p>")]
        [TestCase("__текст текст__", "<p><strong>текст текст</strong></p>")]
        [TestCase(@"\_Вот это\_", @"<p>_Вот это_</p>")]
        [TestCase(@"сим\волы экран\ \должны остаться.\", @"<p>сим\волы экран\ \должны остаться.\</p>")]
        [TestCase(@"\\_Вот это_", @"<p>\<em>Вот это</em></p>")]
        [TestCase(@"__текст текст _текст_ текст__", @"<p><strong>текст текст <em>текст</em> текст</strong></p>")]
        [TestCase(@"_текст текст __текст__ текст_", @"<p><em>текст текст __текст__ текст</em></p>")]
        [TestCase("цифрами_12_3", "<p>цифрами_12_3</p>")]
        [TestCase("_нач_але", "<p><em>нач</em>але</p>")]
        [TestCase("сер_еди_не", "<p>сер<em>еди</em>не</p>")]
        [TestCase("кон_це._", "<p>кон<em>це.</em></p>")]
        [TestCase("ра_зных сл_овах", "<p>ра_зных сл_овах</p>")]
        [TestCase("__Непарные_", "<p>__Непарные_</p>")]
        [TestCase("_Непарные", "<p>_Непарные</p>")]
        [TestCase("эти_ подчерки_ не считаются выделением", "<p>эти_ подчерки_ не считаются выделением</p>")]
        [TestCase("_подчерки _не считаются_", "<p><em>подчерки _не считаются</em></p>")]
        [TestCase("__пересечения _двойных__ и одинарных_", "<p>__пересечения _двойных__ и одинарных_</p>")]
        [TestCase("__ __", "<p>__ __</p>")]
        [TestCase("_ _", "<p>_ _</p>")]
        [TestCase("# Заголовок __с _разными_ символами__", "<p><h1>Заголовок <strong>с <em>разными</em> символами</strong></h1></p>")]
        [TestCase("#Заголовок __с _разными_ символами__", "<p>#Заголовок <strong>с <em>разными</em> символами</strong></p>")]

        public void Render_ShouldReturn(string input, string expected)
        {
            var md = new Md();
            var actual = md.Render(input);
            Assert.AreEqual(expected, actual);
        }

    }
}
